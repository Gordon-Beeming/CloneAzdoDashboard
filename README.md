# Clone Azure DevOps Dashboards

Prototype project before adding the dashboards processor to [Azure DevOps Migration Tools](https://github.com/nkdAgility/azure-devops-migration-tools).

## Supported Widgets

Currently the tool has explicit processors for the following widgets. 

| contributionId |
| --- |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.QueryScalarWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.MarkdownWidget |
| ms.vss-mywork-web.Microsoft.VisualStudioOnline.MyWork.WitViewWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.WitChartWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.BuildHistogramWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.TeamMembersWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.CodeScalarWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.AssignedToMeWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.NewWorkItemWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.OtherLinksWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.WorkLinksWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.HowToLinksWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.IFrameWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.AnalyticsSprintBurndownWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.CumulativeFlowDiagramWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.CycleTimeWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.VelocityWidget |
| ms.vss-dashboards-web.Microsoft.VisualStudioOnline.Dashboards.LeadTimeWidget |

If no processor is found for a widget the tool will just apply the source widgets 
against the target dashboard. Some widgets like the AssignedToMeWidget doesn't have 
any settings so doesn't require an explicit processor but over time the goal would 
be to have a processor for each widget type including 3rd party widgets.


## Accidental migrate queries feature

Dashboards needs to be able to migrate queries as part of their implementation (at 
least how it's been done in the tool). With this base support was added to migrate 
queries only from a base path to a target without looking at the dashboards. 

A Queries mode was added to allow query migration only.

