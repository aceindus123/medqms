using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cmm.DataAccessLayer;
/// <summary>
/// Summary description for Coordinatorproperties
/// </summary>
namespace cmm.coordinatorpop
{
public class Coordinatorproperties
{
	public Coordinatorproperties()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string coordComments;
    private string coordcrossfunreviwer;
    private string coordtgtcmpltndate;
    private string coordReviewer;
    private string coordTimeline;
    private string coordactnitmdesc;
    private string coordExecutor;
    private string coordchangeid;
    private string coordsubmit;
    private string coordReviewer1;
    private string coorddepartment;
    private string coorddepthod;
    private string coordTimeline1;
    private int coordstatus;
    private int coordCurstatus;
    private string coordpriority;
    private string coordactitmtree;
    private string coordfunreview;
    private string coordpcode;

    public string comments
    {
        get { return coordComments; }
        set { coordComments = value; }
    }

    public string crossfunreviwer
    {
        get { return coordcrossfunreviwer; }
        set { coordcrossfunreviwer = value; }
    }
    public string tgtcmpltndate
    {
        get { return coordtgtcmpltndate; }
        set { coordtgtcmpltndate = value; }
    }
    public string Reviewer
    {
        get { return coordReviewer; }
        set { coordReviewer = value; }
    }

    public string Timeline
    {
        get { return coordTimeline; }
        set { coordTimeline = value; }
    }
    public string actnitmdesc
    {
        get { return coordactnitmdesc; }
        set { coordactnitmdesc = value; }
    }

    public string Executor
    {
        get { return coordExecutor; }
        set { coordExecutor = value; }
    }
    public string changeid
    {
        get { return coordchangeid; }
        set { coordchangeid = value; }
    }

    public string submit
    {
        get { return coordsubmit; }
        set { coordsubmit = value; }
    }
    public string Reviewer1
    {
        get { return coordReviewer1; }
        set { coordReviewer1 = value; }
    }

    public string department
    {
        get { return coorddepartment; }
        set { coorddepartment = value; }
    }
    public string depthod
    {
        get { return coorddepthod; }
        set { coorddepthod = value; }
    }

    public string Timeline1
    {
        get { return coordTimeline1; }
        set { coordTimeline1 = value; }
    }
    public Int32 status
    {
        get { return coordstatus; }
        set { coordstatus = value; }
    }
    public Int32 Curstatus
    {
        get { return coordCurstatus; }
        set { coordCurstatus = value; }
    }
    public string priority
    {
        get { return coordpriority; }
        set { coordpriority = value; }
    }
    public string actitmtree
    {
        get { return coordactitmtree; }
        set { coordactitmtree = value; }
    }

    public string funreview
    {
        get { return coordfunreview; }
        set { coordfunreview = value; }
    }
    public string prioritycode
    {
        get { return coordpcode; }
        set { coordpcode = value; }
    }
}
}