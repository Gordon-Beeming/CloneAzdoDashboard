﻿using CloneAzdoDashboard.WidgetProcessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CloneAzdoDashboard
{
  class Program
  {
    static AppConfig _config = null;

    static List<BaseWidgetProcessor> WidgetProcessors => new List<BaseWidgetProcessor> {
      new QueryScalarWidgetProcessor(),
      new WitViewWidgetProcessor(),
      new WitChartWidgetProcessor(),
      new MarkdownWidgetProcessor(),
      new BuildHistogramWidgetProcessor(),
    };

    static void Main(string[] args)
    {
      if (!LoadConfig(args))
      {
        return;
      }

      MigrateDashboard();

      DoneDone();
    }

    private static void MigrateDashboard()
    {
      if (TargetDashboardExists() && !_config.DeleteTargetDashboardIfExists)
      {
        WriteLine($"Target dashboard '{_config.TargetDashboardName}' in the team '{_config.TargetTeamName}' already exists and DeleteTargetDashboardIfExists=false.", ConsoleColor.Red);
        return;
      }
      var output = string.Empty;
      var dashboards = TfsStatic.GetDashboards(true, _config.SourceTeamName, _config.SourceAsProject);
      var dashboard = dashboards.value.FirstOrDefault(o => o.name.Equals(_config.SourceDashboardName));
      if (dashboard == null)
      {
        WriteLine($"Unable to find the dashboard '{_config.SourceDashboardName}' in the team '{_config.SourceTeamName}'.", ConsoleColor.Red);
        return;
      }
      WriteLine($"Source Dashboard: {dashboard.name} ({dashboard.id})");
      WriteLine($"Target Dashboard: {_config.TargetDashboardName}");
      WriteLine($"Source Team Name: {_config.SourceTeamName}");
      WriteLine($"Target Team Name: {_config.TargetTeamName}");
      var dashboardInfo = TfsStatic.GetDashboard(true, _config.SourceTeamName, _config.SourceAsProject, dashboard.id);
      dashboardInfo.name = _config.TargetDashboardName;

      WriteLine($"Widgets: {dashboardInfo.widgets.Length}");
      foreach (var widget in dashboardInfo.widgets)
      {
        WriteLine($"[{GetWidgetPositionDisplay(widget)}] {widget.name}");
        foreach (var processor in WidgetProcessors)
        {
          if (widget.contributionId.Equals(processor.ContributionId, StringComparison.InvariantCultureIgnoreCase))
          {
            WriteLine($"\tprocessing");
            processor.Run(widget, _config);
            continue;
          }
        }
      }

      WriteLine();
      WriteLine();
      if (_config.UpdateQueriesOnly)
      {
        WriteLine($"Skipping dashboard creation, UpdateQueriesOnly=true.");
      }
      else
      {
        DeleteDashboardIfExists();
        Write($"Creating dashboard '{_config.TargetDashboardName}' in the team '{_config.TargetTeamName}'...");
        var newDashboardInfo = TfsStatic.CreateDashboard(false, _config.TargetTeamName, _config.TargetAsProject, dashboardInfo);
        var teamNameUrl = _config.TargetTeamName.Replace(" ", "%20");
        if (newDashboardInfo.url.IndexOf(teamNameUrl) > -1)
        {
          var url = newDashboardInfo.url.Remove(newDashboardInfo.url.IndexOf(teamNameUrl), teamNameUrl.Length + 1);
          url = url.Replace("_apis/Dashboard/Dashboards", "_dashboards/dashboard");
          WriteLine(url);
        }
        else if (newDashboardInfo.url.IndexOf("/") > -1)
        {
          WriteLine(newDashboardInfo.url.Remove(0, newDashboardInfo.url.LastIndexOf("/") + 1));
        }
        WriteLine("Done!", ConsoleColor.Green);
      }
    }

    private static void DeleteDashboardIfExists()
    {
      var dashboards = TfsStatic.GetDashboards(false, _config.TargetTeamName, _config.TargetAsProject);
      var dashboard = dashboards.value.FirstOrDefault(o => o.name.Equals(_config.TargetDashboardName));
      if (dashboard != null)
      {
        WriteLine($"Deleting dashboard: {dashboard.name} ({dashboard.id})", ConsoleColor.DarkYellow);
        TfsStatic.DeleteDashboard(false, _config.TargetTeamName, _config.TargetAsProject, dashboard.id);
        return;
      }
    }

    private static bool TargetDashboardExists()
    {
      var dashboards = TfsStatic.GetDashboards(false, _config.TargetTeamName, _config.TargetAsProject);
      var dashboard = dashboards.value.FirstOrDefault(o => o.name.Equals(_config.TargetDashboardName));
      return dashboard != null;
    }


    private static string GetWidgetPositionDisplay(DashboardInfo_Widget1 widget)
    {
      var display = widget.position.row.ToString();
      if (widget.size.rowSpan > 1)
      {
        display += $"-{widget.position.row + widget.size.rowSpan - 1 }";
      }
      display += $",{widget.position.column}";
      if (widget.size.columnSpan > 1)
      {
        display += $"-{widget.position.column + widget.size.columnSpan - 1 }";
      }
      return display;
    }

    #region fluff

    private static bool LoadConfig(string[] args)
    {
      var fileName = "config.json";
      if (args != null && args.Length > 0)
      {
        fileName = args[0].Trim('\"').Trim('\'');
      }
      SetConsoleThings();
      if (!File.Exists($".\\{fileName}"))
      {
        WriteLine($"{fileName} is missing!", ConsoleColor.Red);
        return false;
      }
      _config = JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText($".\\{fileName}"));

      TfsStatic.SourceTeamProjectBaseUri = _config.SourceTeamProjectBaseUri;
      TfsStatic.TargetTeamProjectBaseUri = _config.TargetTeamProjectBaseUri;
      TfsStatic.SourcePatKey = _config.SourcePatKey;
      TfsStatic.TargetPatKey = _config.TargetPatKey;

      if (!GetPatToken())
      {
        return false;
      }

      return true;
    }

    private static bool GetPatToken()
    {
      Console.WriteLine("PAT keys can be generated in TFS, keep this safe. With this key we are able to impersonate you using the TFS API's.");
      Console.WriteLine("Steps to create: https://www.visualstudio.com/en-us/docs/setup-admin/team-services/use-personal-access-tokens-to-authenticate");
      Console.WriteLine("TFS Uri: https://{account}/{tpc}/_details/security/tokens");
      Console.WriteLine();
      if (string.IsNullOrEmpty(TfsStatic.SourcePatKey))
      {
        Console.WriteLine($"Source: {TfsStatic.SourceTeamProjectBaseUri}");
        Console.Write("Enter you Source PAT key: ");
        TfsStatic.SourcePatKey = Console.ReadLine();
        if ((TfsStatic.SourcePatKey?.Trim() ?? string.Empty).Length == 0)
        {
          Console.WriteLine();
          Console.WriteLine("Seems you didn't supply a key.");
          Console.ReadLine();
          return false;
        }
      }
      if (string.IsNullOrEmpty(TfsStatic.TargetPatKey))
      {
        Console.WriteLine($"Target: {TfsStatic.TargetTeamProjectBaseUri}");
        Console.Write("Enter you Target PAT key: ");
        TfsStatic.TargetPatKey = Console.ReadLine();
        if ((TfsStatic.TargetPatKey?.Trim() ?? string.Empty).Length == 0)
        {
          Console.WriteLine();
          Console.WriteLine("Seems you didn't supply a key.");
          Console.ReadLine();
          return false;
        }
      }
      Console.Clear();
      return true;
    }

    private static void SetConsoleThings()
    {
      Console.ForegroundColor = ConsoleColor.White;
      Console.BackgroundColor = ConsoleColor.Black;
      Console.Clear();
    }

    private static void Write(string message = "", ConsoleColor colour = ConsoleColor.White)
    {
      Console.ForegroundColor = colour;
      Console.Write(message);
      Console.ForegroundColor = ConsoleColor.White;
    }

    private static void WriteLine(string message = "", ConsoleColor colour = ConsoleColor.White)
    {
      Console.ForegroundColor = colour;
      Console.WriteLine(message);
      Console.ForegroundColor = ConsoleColor.White;
    }

    private static void DoneDone()
    {
      WriteLine();
      WriteLine();
      WriteLine();
      WriteLine("Done!");
      //Console.ReadLine();
    }

    #endregion
  }
}
