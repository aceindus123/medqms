using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using cmm.DataAccessLayer;
/// <summary>
/// Summary description for Initiatorproperties
/// </summary>
namespace cmm.Initiatorproperties
{
    public class Initiatorproperties
    {
        public Initiatorproperties()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        private string Changeid;
        private string initdate;
        private string initby;
        private string typechange;
        private string  changeperiod;
        private string cclassification;
        private string Unit;
        private string Dept;
        private string csource;
        private string ccategory;
        private string Refid;
        private string Customer;
        private string Market;
        private string License;
        private string CDesc;
        private string existing;
        private string proposal;
        private string relchngs;
        private string reschnge;
        private string submit;

        private string Attachments;
        private string pimpact;
        private string simpact;
        private string rimpact;
        private string productname;
        private string dosfrom;
        private string safetyass;
        private string regimpdesc;
        private int status;
        private int cstatus;
        private string searchcc;
        private string updatedate;
        

        public string  initchangeid
        {
            get { return Changeid; }
            set { Changeid = value; }
        }

        public string initinitdate
        {
            get { return initdate; }
            set { initdate = value; }
        }
        public string initinitby
        {
            get { return initby; }
            set { initby = value; }
        }
        public string inittypechange
        {
            get { return typechange; }
            set { typechange = value; }
        }

        // vJobDesc
        public string initchangeperiod
        {
            get { return changeperiod; }
            set { changeperiod = value; }

        }

        public string  initcclassification
        {
            get { return cclassification; }
            set { cclassification = value; }
        }

        public string initUnit
        {
            get { return Unit; }
            set { Unit = value; }
        }

        public string initDept
        {
            get { return Dept; }
            set { Dept = value; }

        }

        public string initcsource
        {
            get { return csource; }
            set { csource = value; }
        }

        public string  initccategory
        {
            get { return ccategory; }
            set { ccategory = value; }
        }
        public string initRefid
        {
            get { return Refid; }
            set { Refid = value; }

        }

        public string initCustomer
        {
            get { return Customer; }
            set { Customer = value; }
        }
        public string initMarket
        {
            get { return Market; }
            set { Market  = value; }
        }

        public string initLicense
        {
            get { return License; }
            set { License = value; }
        }

        public string initCDesc
        {
            get { return CDesc; }
            set { CDesc = value; }

        }
        public string initexisting
        {
            get { return existing; }
            set { existing = value; }

        }

        public string initproposal
        {
            get { return proposal; }
            set { proposal = value; }
        }

        public string initrelchngs
        {
            get { return relchngs; }
            set { relchngs = value; }
        }
        public string initreschnge
        {
            get { return reschnge; }
            set { reschnge = value; }
        }

        public string initsubmit
        {
            get { return submit; }
            set { submit = value; }
        }

        public string initAttachments
        {
            get { return Attachments; }
            set { Attachments = value; }
        }
        public string initpimpact
        {
            get { return pimpact; }
            set { pimpact = value; }
        }
        public string initsimpact
        {
            get { return simpact; }
            set { simpact = value; }
        }

        public string initrimpact
        {
            get { return rimpact; }
            set { rimpact = value; }
        }
        public string initproductname
        {
            get { return productname; }
            set { productname = value; }
        }
        public string initdosfrom
        {
            get { return dosfrom; }
            set { dosfrom = value; }
        }
        public string initsafetyass
        {
            get { return safetyass; }
            set { safetyass = value; }
        }
        public string initregimpdesc
        {
            get { return regimpdesc; }
            set { regimpdesc = value; }
        }
        public Int32 initstatus
        {
            get { return status; }
            set { status = value; }
        }
        public Int32 initcstatus
        {
            get { return cstatus; }
            set { cstatus = value; }
        }
        public string initsearchcc
        {
            get { return searchcc; }
            set { searchcc = value; }
        }

        public string initupdatedate
        {
            get { return updatedate; }
            set { updatedate = value; }
        }

    }
}