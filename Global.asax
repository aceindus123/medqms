<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes); 
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    void RegisterRoutes(RouteCollection routes)
    {
        //RouteTable.Routes.Add(new System.Web.Routing.Route("{resource}.axd/{*pathInfo}", new System.Web.Routing.StopRoutingHandler()));
        routes.Ignore("{resource}.axd/{*pathInfo}");
        routes.MapPageRoute("logincms", "Login-Into-meqqms", "~/Default.aspx");
        routes.MapPageRoute("cmmhome", "medqms-Home", "~/Home.aspx");
        routes.MapPageRoute("cityhome", "C_Home-{city}", "~/Default.aspx");
        routes.MapPageRoute("changemanagement", "Change-Management-Home", "~/CMMHome.aspx");

        routes.MapPageRoute("cmmsop", "Change-Management-SOP", "~/cmmsop.aspx");
        routes.MapPageRoute("cmmflowchart", "Change-Management-FlowChart", "~/cmmflowchart.aspx");
        routes.MapPageRoute("cmmchpwd", "Change-Password-Into-CMM", "~/CMM ChangePwd.aspx");
        routes.MapPageRoute("cmmsettings", "Change-Management-Settings", "~/cmmsettings.aspx");
        routes.MapPageRoute("cmmnotifications", "CMM-Quality-Notifications", "~/cmmqualitynotifications.aspx");
        routes.MapPageRoute("cmmcomplaints", "Change-Management-Complaints", "~/cmm complaints.aspx");
        routes.MapPageRoute("cmmapreview", "Annual-Product-Review-CMM", "~/cmm annual pdtreview.aspx");
        routes.MapPageRoute("cmmcapa", "CMM-CAPA", "~/cmm capa.aspx");
        routes.MapPageRoute("cmmaudittrail", "CMM-Audit-Trail-Report-{parameter}", "~/CmsAuditTrail.aspx");
        routes.MapPageRoute("cmmforgetpwd", "Medqms-Forget-Password", "~/CMM forgetpwd.aspx");

        routes.MapPageRoute("initiator", "{parameter}-Home", "~/CMS_Initiator.aspx");
        routes.MapPageRoute("createinitiator", "Create-{param1}-Request", "~/CMS_Initiator.aspx");
        routes.MapPageRoute("changeowner", "Reviewer-{parameter}", "~/CMS_ChangeOwner.aspx");
        routes.MapPageRoute("cmmcft", "CMM-CFT-{parameter}", "~/CMS_Final QA.aspx");
        routes.MapPageRoute("cmmracg", "CMM-RACG-{parameter}", "~/CMS_racg.aspx");
        routes.MapPageRoute("cmmqareg", "CMM-Coordinator-{parameter}", "~/QAReg1.aspx");
        routes.MapPageRoute("cmmapprover", "CMM-Approver-{parameter}", "~/CMS_Cab Review.aspx");
    }
       
</script>
