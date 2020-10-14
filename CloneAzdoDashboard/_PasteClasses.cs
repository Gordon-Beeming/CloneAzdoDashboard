﻿using System;

namespace CloneAzdoDashboard
{



















  public enum QueryExpand
  {
    /// <summary>
    /// Expands all properties
    /// </summary>
    all,

    /// <summary>
    /// Expands Columns, Links, ChangeInfo, WIQL text and clauses
    /// </summary>
    clauses,

    /// <summary>
    /// Displays minimal properties and the WIQL text
    /// </summary>
    minimal,

    /// <summary>
    /// Expands Columns, Links and ChangeInfo
    /// </summary>
    none,

    /// <summary>
    /// Expands Columns, Links, ChangeInfo and WIQL text
    /// </summary>
    wiql
  }

  public class CreateWorkItemQueryFolderRequest
  {
    public string name { get; set; }
    public bool isFolder { get; set; } = true;
  }

  public class WorkItemQuery
  {
    public string id { get; set; }
    public string name { get; set; }
    public string path { get; set; }
    public DateTime createdDate { get; set; }
    public WorkItemQuery_Lastmodifiedby lastModifiedBy { get; set; }
    public DateTime lastModifiedDate { get; set; }
    public bool isFolder { get; set; }
    public bool hasChildren { get; set; }
    public WorkItemQuery[] children { get; set; }
    public bool isPublic { get; set; }
    public string url { get; set; }
    public string queryType { get; set; }
    public WorkItemQuery_Column[] columns { get; set; }
    public string wiql { get; set; }
    public WorkItemQuery_Clauses clauses { get; set; }
  }

  public class WorkItemQuery_Lastmodifiedby
  {
    public string id { get; set; }
    public string name { get; set; }
    public string displayName { get; set; }
    public string url { get; set; }
    public string uniqueName { get; set; }
    public string imageUrl { get; set; }
    public string descriptor { get; set; }
  }

  public class WorkItemQuery_Clauses
  {
    public string logicalOperator { get; set; }
    public WorkItemQuery_Claus[] clauses { get; set; }
  }

  public class WorkItemQuery_Claus
  {
    public WorkItemQuery_Field field { get; set; }
    public WorkItemQuery_Operator _operator { get; set; }
    public string value { get; set; }
  }

  public class WorkItemQuery_Field
  {
    public string referenceName { get; set; }
    public string name { get; set; }
    public string url { get; set; }
  }

  public class WorkItemQuery_Operator
  {
    public string referenceName { get; set; }
    public string name { get; set; }
  }

  public class WorkItemQuery_Column
  {
    public string referenceName { get; set; }
    public string name { get; set; }
    public string url { get; set; }
  }












  public class WorkItemQueries
  {
    public int count { get; set; }
    public WorkItemQueries_Value[] value { get; set; }
  }

  public class WorkItemQueries_Value
  {
    public string id { get; set; }
    public string name { get; set; }
    public string path { get; set; }
    public DateTime createdDate { get; set; }
    public WorkItemQueries_Lastmodifiedby lastModifiedBy { get; set; }
    public DateTime lastModifiedDate { get; set; }
    public bool isFolder { get; set; }
    public bool hasChildren { get; set; }
    public bool isPublic { get; set; }
    public WorkItemQueries_Links1 _links { get; set; }
    public string url { get; set; }
    public WorkItemQueries_Createdby createdBy { get; set; }
  }

  public class WorkItemQueries_Lastmodifiedby
  {
    public string id { get; set; }
    public string name { get; set; }
    public string displayName { get; set; }
    public string url { get; set; }
    public WorkItemQueries_Links _links { get; set; }
    public string uniqueName { get; set; }
    public string imageUrl { get; set; }
    public string descriptor { get; set; }
  }

  public class WorkItemQueries_Links
  {
    public WorkItemQueries_Avatar avatar { get; set; }
  }

  public class WorkItemQueries_Avatar
  {
    public string href { get; set; }
  }

  public class WorkItemQueries_Links1
  {
    public WorkItemQueries_Self self { get; set; }
    public WorkItemQueries_Html html { get; set; }
  }

  public class WorkItemQueries_Self
  {
    public string href { get; set; }
  }

  public class WorkItemQueries_Html
  {
    public string href { get; set; }
  }

  public class WorkItemQueries_Createdby
  {
    public string id { get; set; }
    public string name { get; set; }
    public string displayName { get; set; }
    public string url { get; set; }
    public WorkItemQueries_Links2 _links { get; set; }
    public string uniqueName { get; set; }
    public string imageUrl { get; set; }
    public string descriptor { get; set; }
  }

  public class WorkItemQueries_Links2
  {
    public WorkItemQueries_Avatar1 avatar { get; set; }
  }

  public class WorkItemQueries_Avatar1
  {
    public string href { get; set; }
  }








  public class DashboardInfo
  {
    public string name { get; set; }
    public int refreshInterval { get; set; }
    public int position { get; set; }
    public string eTag { get; set; }
    public DashboardInfo_Widget1[] widgets { get; set; }
    public string groupId { get; set; }
    public string ownerId { get; set; }
    public string dashboardScope { get; set; }
    public string url { get; set; }
    public DashboardInfo_Links _links { get; set; }
  }

  public class DashboardInfo_Links
  {
    public DashboardInfo_Self self { get; set; }
    public DashboardInfo_Group group { get; set; }
    public DashboardInfo_Widget[] widget { get; set; }
  }

  public class DashboardInfo_Self
  {
    public string href { get; set; }
  }

  public class DashboardInfo_Group
  {
    public string href { get; set; }
  }

  public class DashboardInfo_Widget
  {
    public string href { get; set; }
  }

  public class DashboardInfo_Widget1
  {
    public string id { get; set; }
    public string eTag { get; set; }
    public string name { get; set; }
    public DashboardInfo_Position position { get; set; }
    public DashboardInfo_Size size { get; set; }
    public string settings { get; set; }
    public DashboardInfo_SettingsVersion settingsVersion { get; set; }
    public string artifactId { get; set; }
    public string url { get; set; }
    public DashboardInfo_Links1 _links { get; set; }
    public bool isEnabled { get; set; }
    public object contentUri { get; set; }
    public string contributionId { get; set; }
    public string typeId { get; set; }
    public string configurationContributionId { get; set; }
    public string configurationContributionRelativeId { get; set; }
    public bool isNameConfigurable { get; set; }
    public string loadingImageUrl { get; set; }
    public DashboardInfo_Lightboxoptions lightboxOptions { get; set; }
  }

  public class DashboardInfo_Position
  {
    public int row { get; set; }
    public int column { get; set; }
  }

  public class DashboardInfo_Size
  {
    public int rowSpan { get; set; }
    public int columnSpan { get; set; }
  }

  public class DashboardInfo_SettingsVersion
  {
    public int major { get; set; }
    public int minor { get; set; }
    public int patch { get; set; }
  }

  public class DashboardInfo_Links1
  {
    public DashboardInfo_Self1 self { get; set; }
    public DashboardInfo_Group1 group { get; set; }
    public DashboardInfo_Dashboard dashboard { get; set; }
  }

  public class DashboardInfo_Self1
  {
    public string href { get; set; }
  }

  public class DashboardInfo_Group1
  {
    public string href { get; set; }
  }

  public class DashboardInfo_Dashboard
  {
    public string href { get; set; }
  }

  public class DashboardInfo_Lightboxoptions
  {
    public int width { get; set; }
    public int height { get; set; }
    public bool resizable { get; set; }
  }






  public class DashboardsList
  {
    public int count { get; set; }
    public DashboardsList_Value[] value { get; set; }
  }

  public class DashboardsList_Value
  {
    public string id { get; set; }
    public string name { get; set; }
    public int refreshInterval { get; set; }
    public int position { get; set; }
    public string eTag { get; set; }
    public string groupId { get; set; }
    public string ownerId { get; set; }
    public string dashboardScope { get; set; }
    public string url { get; set; }
    public DashboardsList_Value_Links _links { get; set; }
  }

  public class DashboardsList_Value_Links
  {
    public DashboardsList_Self self { get; set; }
    public DashboardsList_Group group { get; set; }
  }

  public class DashboardsList_Self
  {
    public string href { get; set; }
  }

  public class DashboardsList_Group
  {
    public string href { get; set; }
  }





  public class CreateImportRequestResponse
  {
    public int importRequestId { get; set; }
    public CreateImportRequestResponse_Repository repository { get; set; }
    public CreateImportRequestResponse_Parameters parameters { get; set; }
    public string status { get; set; }
    public CreateImportRequestResponse_Detailedstatus detailedStatus { get; set; }
    public string url { get; set; }
  }

  public class CreateImportRequestResponse_Repository
  {
    public string id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    public CreateImportRequestResponse_Project project { get; set; }
    public string remoteUrl { get; set; }
  }

  public class CreateImportRequestResponse_Project
  {
    public string id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    public string state { get; set; }
    public int revision { get; set; }
    public string visibility { get; set; }
  }

  public class CreateImportRequestResponse_Parameters
  {
    public object tfvcSource { get; set; }
    public CreateImportRequestResponse_Gitsource gitSource { get; set; }
    public bool deleteServiceEndpointAfterImportIsDone { get; set; }
  }

  public class CreateImportRequestResponse_Gitsource
  {
    public string url { get; set; }
    public bool overwrite { get; set; }
  }

  public class CreateImportRequestResponse_Detailedstatus
  {
    public int currentStep { get; set; }
    public string[] allSteps { get; set; }
  }








  public class CreateImportRequestRequest
  {
    public CreateImportRequestRequest_Parameters parameters { get; set; }
  }

  public class CreateImportRequestRequest_Parameters
  {
    public CreateImportRequestRequest_Gitsource gitSource { get; set; }
    public string serviceEndpointId { get; set; }
    public bool deleteServiceEndpointAfterImportIsDone { get; set; }
  }

  public class CreateImportRequestRequest_Gitsource
  {
    public string url { get; set; }
  }













  public class CreateRepoResponse
  {
    public string id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    public CreateRepoResponse_Project project { get; set; }
    public string remoteUrl { get; set; }
  }

  public class CreateRepoResponse_Project
  {
    public string id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    public string state { get; set; }
    public int revision { get; set; }
    public string visibility { get; set; }
  }












  public class CreateRepoRequest
  {
    public string name { get; set; }
    public CreateRepoRequest_Project project { get; set; }
  }

  public class CreateRepoRequest_Project
  {
    public string id { get; set; }
  }
















  public class CreateServiceEndpointResponse
  {
    public CreateServiceEndpointResponse_Data data { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string url { get; set; }
    public CreateServiceEndpointResponse_Createdby createdBy { get; set; }
    public CreateServiceEndpointResponse_Authorization authorization { get; set; }
    public string groupScopeId { get; set; }
    public CreateServiceEndpointResponse_Administratorsgroup administratorsGroup { get; set; }
    public CreateServiceEndpointResponse_Readersgroup readersGroup { get; set; }
    public bool isReady { get; set; }
  }

  public class CreateServiceEndpointResponse_Data
  {
  }

  public class CreateServiceEndpointResponse_Createdby
  {
    public string id { get; set; }
    public string displayName { get; set; }
    public string uniqueName { get; set; }
  }

  public class CreateServiceEndpointResponse_Authorization
  {
    public CreateImportRequestRequest_Parameters parameters { get; set; }
    public string scheme { get; set; }
  }

  public class CreateServiceEndpointResponse_Parameters
  {
    public string username { get; set; }
    public string password { get; set; }
  }

  public class CreateServiceEndpointResponse_Administratorsgroup
  {
    public string id { get; set; }
  }

  public class CreateServiceEndpointResponse_Readersgroup
  {
    public string id { get; set; }
  }

















  public class CreateServiceEndpointRequest
  {
    public string name { get; set; }
    public string type { get; set; }
    public string url { get; set; }
    public CreateServiceEndpointRequest_Authorization authorization { get; set; }
  }

  public class CreateServiceEndpointRequest_Authorization
  {
    public string scheme { get; set; }
    public CreateServiceEndpointRequest_Parameters parameters { get; set; }
  }

  public class CreateServiceEndpointRequest_Parameters
  {
    public string username { get; set; }
    public string password { get; set; }
  }
















  public class repositories
  {
    public repositories_Value[] value { get; set; }
    public int count { get; set; }
  }

  public class repositories_Value
  {
    public string id { get; set; }
    public string name { get; set; }
    public string magic_repo_name => $"{project.name}-{name}".Replace(" ", "-");
    public string url { get; set; }
    public repositories_Project project { get; set; }
    public string defaultBranch { get; set; }
    public string remoteUrl { get; set; }
  }

  public class repositories_Project
  {
    public string id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    public string state { get; set; }
    public int revision { get; set; }
    public string visibility { get; set; }
  }











  public class GetProjects
  {
    public int count { get; set; }
    public GetProjects_Value[] value { get; set; }
  }

  public class GetProjects_Value
  {
    public string id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    public string state { get; set; }
    public int revision { get; set; }
    public string visibility { get; set; }
    public DateTime lastUpdateTime { get; set; }
  }

















}