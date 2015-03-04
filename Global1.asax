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
        
        routes.MapPageRoute("HomeRoute", "Home", "~/Default.aspx");
        routes.MapPageRoute("HomeTab", "TabHome-{id}", "~/Default.aspx");
        routes.MapPageRoute("cityhome", "C_Home-{city}", "~/Default.aspx");
        routes.MapPageRoute("Aboutjcalluz", "AboutJustCalluz", "~/Aboutus.aspx");
        routes.MapPageRoute("LifeStyle", "LifeStyle", "~/lifestyle.aspx");
        routes.MapPageRoute("LifeStyle_Sub", "CategoriesofLifeStyle-{cat}", "~/Lifestylesub.aspx");
        routes.MapPageRoute("LifeStyle_home", "LifeStyleHome-{cat}-{cname}", "~/Lifestylehome.aspx");
        routes.MapPageRoute("Life_link", "LifeStyles-{Lcatname}-{cname}", "~/LifeStyle_Link.aspx");      
        routes.MapPageRoute("PostLife", "PostLifeStyle-{cname}", "~/post_lifestyle.aspx");
        routes.MapPageRoute("viewLife", "ViewLifeStyle", "~/view_lifestyle_brief.aspx");//28
        routes.MapPageRoute("More", "Categories-{catname}", "~/More.aspx");
        routes.MapPageRoute("Events", "Events-{cname}", "~/Events.aspx");
       // routes.MapPageRoute("Movies", "Movie_Details-{mname}-{mlang}", "~/Movies.aspx");
        routes.MapPageRoute("Movies", "Movie_Details", "~/MoviePage.aspx");
        routes.MapPageRoute("Link", "LinkDetails-{cname}", "~/linkcontroller.aspx");
        routes.MapPageRoute("discounts", "Discounts-{cname}", "~/Discounts.aspx");
        routes.MapPageRoute("ViewDiscountDetails", "ViewDiscount-{id}", "~/view_BriefDiscounts.aspx");
        routes.MapPageRoute("sessionstore", "sessionstoreS-{id}-{cname}", "~/sessionstore.aspx");//28-02-2013
        routes.MapPageRoute("CareersFeedback", "CareersFeedback", "~/career_feedback.aspx");
        routes.MapPageRoute("Reverse", "Reverse-Auction", "~/jc_reverse_auction.aspx");
        routes.MapPageRoute("ReverseAuction", "ReverseAuction-{Tcity}", "~/jc_reverse_auction.aspx");//04-03-2013
        routes.MapPageRoute("ReverseDetails", "Reverse-{cate}-{city}-{name}-{mobile}", "~/jc_reverse_thankyouForm.aspx");
        routes.MapPageRoute("ReverseMail", "mails-{cate}-{city}-{name}", "~/jc_reverseauctionMail.aspx");
        routes.MapPageRoute("WhitePage", "WhitePage", "~/White_Page.aspx");      
        routes.MapPageRoute("WhitePageDetails", "WhitePage-{city}", "~/White_page_details.aspx");
        routes.MapPageRoute("PostResume1", "SubmitResume", "~/careers_postresume.aspx");
        routes.MapPageRoute("CareersForm", "ResumeForm", "~/careers_resumeform.aspx");
        routes.MapPageRoute("CareersDepartment", "CareersDepartment", "~/careers_Department.aspx");
        routes.MapPageRoute("register", "Register", "~/Register.aspx");
        routes.MapPageRoute("Password", "Password", "~/forgetpwd.aspx");
        routes.MapPageRoute("logout", "Logout", "~/Logout.aspx");
        routes.MapPageRoute("ThankYou", "ThankYou-{Msg}", "~/ThankYou.aspx");
        routes.MapPageRoute("ActivateAccount", "ActivateAccount-{UserId}-{ActiveId}", "~/ActivateAccount.aspx");
        routes.MapPageRoute("AdvertiseEdit", "Advertise-{DID}", "~/Advertise_Edit.aspx");
       
        //latest
        routes.MapPageRoute("rgt_Events", "SearchEvents-{city}-{cname}", "~/Events.aspx");//Events
        routes.MapPageRoute("event_lnk", "Eventlink-{Ecname}-{cname}", "~/Eventslink.aspx");//Events
        routes.MapPageRoute("Link_rest", "Details-{rcname}", "~/linkcontroller.aspx");
        routes.MapPageRoute("Link_a", "AdvanceDetails-{acname}", "~/linkcontroller.aspx");
       // routes.MapPageRoute("Link_s", "SearchDetails-{scname}", "~/linkcontroller.aspx");//22-10-2014 original
        routes.MapPageRoute("Link_s", "SearchDetails-{scname}-{pcname}-{cattype}", "~/linkcontroller.aspx");  
        routes.MapPageRoute("Event_links", "Events-{cname}", "~/Eventslink.aspx");
        routes.MapPageRoute("Moreb2b", "B2BCatogories-{catname}-{type}", "~/More.aspx");
        routes.MapPageRoute("job_link", "Particular-Jobs-{catname}-{cname}", "~/joblinks.aspx");
        routes.MapPageRoute("jobs", "Jobs-{cname}", "~/jobs.aspx");
        routes.MapPageRoute("rgt_jobs", "SearchJobs-{city}-{cname}", "~/jobs.aspx");//Jobs
        routes.MapPageRoute("jobdetails", "Job-{id}-{cname}", "~/jobdetails.aspx");
        routes.MapPageRoute("PostJob", "PostJob-{cname}", "~/post_job.aspx");
        routes.MapPageRoute("EditJob", "EditJob-{id}-{cname}", "~/edit_job.aspx");
        routes.MapPageRoute("archieve", "Jobs in archieve-{cname}", "~/job_archieve.aspx");
        routes.MapPageRoute("Viewjob", "viewjob", "~/view_jobs.aspx");
        routes.MapPageRoute("rgt_discounts", "SearchDiscounts-{city}-{cname}", "~/Discounts.aspx");//Discounts
        routes.MapPageRoute("DiscountDetails", "Discount-{id}-{cname}", "~/Discount_details.aspx");//m
        routes.MapPageRoute("Discountcat_link", "DiscountCategories-{Dcname}-{cname}", "~/Discountlink.aspx");//m
        routes.MapPageRoute("Discountsubcat_link", "DiscountSubCategories-{Dscname}-{cname}", "~/Discountlink.aspx");//m
        routes.MapPageRoute("PostDiscount", "PostDiscount-{cname}", "~/post_discount.aspx");
        routes.MapPageRoute("ViewDiscount", "ViewDiscount", "~/view_discounts.aspx");
        routes.MapPageRoute("EditDiscount", "EditDiscount-{id}-{cname}", "~/Edit_discounts.aspx");
        routes.MapPageRoute("PostReviewCat", "PostReviewCat-{DataId}-{mod}", "~/PostReviewCat.aspx");
        routes.MapPageRoute("SearchResultPage", "SearchNotFound-{cname}-{city}", "~/Search-Not-Found.aspx");
        routes.MapPageRoute("Signin", "signinForm-{Qname}", "~/signin.aspx");//signin
        routes.MapPageRoute("usignin", "signin", "~/signin.aspx");
        routes.MapPageRoute("AuthenticationMsg", "AuthenticationMsg-{msg}", "~/AuthenticationMsg.aspx");
        routes.MapPageRoute("Hotels", "Hotels-{pageid}", "~/Hotels.aspx");
        routes.MapPageRoute("Builders", "Builders-{cname}", "~/Builders.aspx");
        routes.MapPageRoute("Travels", "Travels-{cname}", "~/Travels.aspx");
        routes.MapPageRoute("Computers", "Computers-{cname}", "~/computers.aspx");
        routes.MapPageRoute("Education", "Education-{cname}", "~/Education.aspx");
        routes.MapPageRoute("csr", "Corporate-Social-Responsibility", "~/Corporate_social.aspx");
        routes.MapPageRoute("Ads", "Justcalluz-Ads", "~/tv_ads.aspx");
        routes.MapPageRoute("tvads", "Justcalluz-Ads-{subad}", "~/tv_ads.aspx");
        routes.MapPageRoute("Test", "Justcalluz-Testimonials", "~/testimonials.aspx");
        routes.MapPageRoute("Share", "Share-your-views", "~/testimonials.aspx#shareViews");
        routes.MapPageRoute("medialang", "Medialang-{lang}", "~/media.aspx");
        routes.MapPageRoute("media", "MediaHome", "~/media.aspx");
        routes.MapPageRoute("media_det", "MediaDetails-{id}", "~/media_details.aspx");
        routes.MapPageRoute("Restaurants", "Restaurants-{cname}", "~/Restaurants.aspx");
        routes.MapPageRoute("Mobile", "Justcalluz-On-Mobile", "~/JC_OnMobile.aspx");
        routes.MapPageRoute("private", "Privacypolicy", "~/privacypolicy.aspx");
        routes.MapPageRoute("Free", "Justcalluz-FreeListing", "~/Freelisting.aspx");
        routes.MapPageRoute("Advertise", "Advertise", "~/Advertise.aspx");
        routes.MapPageRoute("reseller", "Reseller", "~/reseller.html");
        routes.MapPageRoute("tag", "Tag-Your-Friend", "~/tag_friend.aspx");
        routes.MapPageRoute("White", "justcalluz-Whitepages", "~/White_Page.aspx");
        routes.MapPageRoute("success", "Client-Success-Stories", "~/success_stories.aspx");
        routes.MapPageRoute("successVideos", "Client-Success-Videos", "~/success_videos.aspx");
        routes.MapPageRoute("Citytrendzmain", "CityTrendz", "~/City trends_Main.aspx");
        routes.MapPageRoute("searchtips", "Search-Tips", "~/search_tips.aspx");
        routes.MapPageRoute("careersloc", "Careers", "~/Careers_Location.aspx");
        routes.MapPageRoute("contact", "Contact", "~/contactus.aspx");
        routes.MapPageRoute("search", "Search-Not-Found", "~/Search-Not-Found.aspx");
        routes.MapPageRoute("customer", "Customer", "~/Customer_Care.aspx");
        routes.MapPageRoute("desclaimer", "Disclaimer", "~/Disclaimer.aspx");
        routes.MapPageRoute("CityTrendDetails", "CityTrend-{CtId}", "~/City_TrendsDetails.aspx");
        //routes.MapPageRoute("citytrendz_title", "CityTrends-{title}", "~/City_trends.aspx");//City_TrendsDetails.aspx
        routes.MapPageRoute("citytrendz_title", "CityTrends-{ctid}", "~/City_trends.aspx");
        routes.MapPageRoute("tocheck", "Your-Postings-{cname}-{id}", "~/ToCheckPostings.aspx");
        routes.MapPageRoute("checkposting", "Postings-{id}", "~/ToCheckPostings.aspx");
        routes.MapPageRoute("sessionstore_movies", "sessionstoreDetails-{id}-{tname}", "~/sessionstore.aspx");//sessionstore
        routes.MapPageRoute("CT_sessionstore", "S_sessionstore-{id}", "~/sessionstore.aspx");//sessionstore
        routes.MapPageRoute("Careers", "Careers-{cityname}", "~/Careers_Location.aspx");
        routes.MapPageRoute("CareersJobInfo", "CareersJobsInfo-{jobid}", "~/careersjobinfo.aspx");//CareersJobInfo
        routes.MapPageRoute("Careers_ResumesForm", "CareersResumesForm-{jobid}-{cate}-{Subcat}", "~/careers_resumeform.aspx");//CareersResumeForm
        routes.MapPageRoute("CareersRForm", "CareersResumeForm-{id}", "~/careers_resumeform.aspx");
        routes.MapPageRoute("CareersViewJob", "CareersViewJob-{id}", "~/careers_viewjob.aspx");
        routes.MapPageRoute("CareersCategories", "JobCategorieslist-in-Careers-{cat}", "~/careers_jobcategorylist.aspx");
        routes.MapPageRoute("CityTrends_Home", "CityTrendsHome-{city}", "~/City_trends.aspx");
        routes.MapPageRoute("CityTrends_Categories", "PopularCategories-{category}", "~/City_trends.aspx");//-in-CityTrends
        routes.MapPageRoute("CityTrends_PopularCompanies", "Popularcompanies-in-CityTrends", "~/CityTrends_PopularCompanies.aspx");
        routes.MapPageRoute("CityTrends_PopularBusinesses", "PopularBusinesses-in-CityTrends", "~/CityTrends_PopBusinesses.aspx");
        routes.MapPageRoute("CT_Movies", "MovieDetails-{mname}-{mlang}-{mcity}", "~/Movies.aspx");
        //routes.MapPageRoute("CT_Link", "RestaurantDetails-{rcname}", "~/linkcontroller.aspx");
        routes.MapPageRoute("Rest_Link", "RestaurantDetails-{rcname}-{rname}", "~/linkcontroller.aspx");//additional param for restaurants
        routes.MapPageRoute("viewEvents", "EventsView", "~/view_events.aspx");
        routes.MapPageRoute("citycattrends", "CityTrendCategories-{category}-{city}", "~/City_trends.aspx");//CityTrends
        routes.MapPageRoute("feedback", "FeedBack", "~/Feedback.aspx");
        routes.MapPageRoute("editlife", "LifeStyle-{id}-{cname}", "~/edit_LifeStyle.aspx");
        routes.MapPageRoute("edituser", "UserDetails-{id}-{cname}", "~/User_Edit.aspx");
        routes.MapPageRoute("rgtmovies", "Movies-{mname}-{mlang}-{movid}", "~/Movies.aspx");
        routes.MapPageRoute("advanced", "AdvancedSearch-{city}", "~/Advanced_Search.aspx");
        routes.MapPageRoute("lnkresults", "{pcname}-Result in-{city}", "~/linkresults.aspx");
        routes.MapPageRoute("profile", "Profile-{uid}", "~/MyProfile.aspx");
        routes.MapPageRoute("printads", "Justcalluz-PrintAds", "~/Tv_Printads.aspx");
        routes.MapPageRoute("Radioads", "Justcalluz-RadioAds", "~/Radioads.aspx");
        routes.MapPageRoute("careerhr", "Contact-HR", "~/careers_Contact HR.aspx");
        routes.MapPageRoute("Ad_lnkresults", "AdvancedResult-{pageid}-{compname}-{city}-{cnctper}-{phone}", "~/linkresults.aspx");//12-03-2013//result
        routes.MapPageRoute("MailMessage", "Mail-{name}-{cat}-{city}", "~/SendEmail.aspx");
        routes.MapPageRoute("CommonPostReviewCat", "PostReviewCat-{DataId}", "~/PostReviewCat.aspx");
        routes.MapPageRoute("careershr", "Contact-HR-{cityname}", "~/careers_Contact HR.aspx");
        routes.MapPageRoute("ChangePassword", "ChangePassword", "~/ChangePassword.aspx");
        routes.MapPageRoute("ProfileEdit", "ProfileEdit-{id}", "~/ProfileEdit.aspx");
        routes.MapPageRoute("customercare", "CustomerDetails-{cmpname}-{area}-{city}", "~/customercare_details.aspx");//Details
        routes.MapPageRoute("Event_Details", "EventDetails-{id}-{cname}", "~/eventdetails.aspx");//Details
        routes.MapPageRoute("postEvent", "Event-{cname}", "~/post_event.aspx");
        routes.MapPageRoute("FreeListingEdit", "FreeListing-{did}", "~/FreeListing_Edit.aspx");
        routes.MapPageRoute("H_linkresults", "Results-{compname}-{pageid}-{city}-{area}", "~/linkresults.aspx");
        routes.MapPageRoute("LifestyleDetails", "LifestyleDetails-{id}", "~/LifeStyle_details.aspx");
        routes.MapPageRoute("eventDetails", "EventDetails-{id}-{cname}", "~/eventdetails.aspx");
        routes.MapPageRoute("EditEvents", "EditEvent-{id}-{cname}", "~/edit_events.aspx");
        routes.MapPageRoute("commingsoon", "commingsoon", "~/commingsoon.aspx");
        routes.MapPageRoute("PostReview", "PostReviews-{mname}-{mlang}", "~/Postreview1.aspx");//Reviews
        routes.MapPageRoute("MovieReview", "MovieReviews-{mname}-{mlang}-{mcity}", "~/Movie_ReadReviews.aspx");//Reviews
       //routes.MapPageRoute("ViewLifeStyle", "ViewLifeStyle", "~/view_lifestyle_brief.aspx");//m
        routes.MapPageRoute("N_Search", "NationalSearch", "~/national_search.aspx");
        routes.MapPageRoute("MovieMails", "MovieMail-{moviename}-{movielanguage}-{name}", "~/Movie_mails.aspx");
        routes.MapPageRoute("Sessionstoreedu", "sessionstoreedu-details-{id}", "~/sessionstore.aspx");//16-4-14
        routes.MapPageRoute("Sessionstorebuild", "sessionstorebuilder-details-{id}", "~/sessionstore.aspx");//17-04-2014
        routes.MapPageRoute("sessionrestaurant", "sessionrestaurant-details-{id}", "~/sessionstore.aspx");
        routes.MapPageRoute("tocheckFreelisting", "YourPostings-{id}-{cname}", "~/ToCheckPostings.aspx");
        routes.MapPageRoute("checkFreelisting", "FreelistingPostings-{cname}", "~/ToCheckPostings.aspx");
        routes.MapPageRoute("sessionstorecomputer", "sessionstoreScom-details-{id}", "~/sessionstore.aspx");
        //routes.MapPageRoute("Jobdetailss", "jobd-{cname}", "~/jobdetails.aspx");//27-6-14(changed doubt)
       //routes.MapPageRoute("", "{address}", "~/{address}.aspx");
       // routes.MapPageRoute("", "{address}/{resource}", "~/{address}/{resource}.aspx");
       //routes.MapPageRoute("MovieReview", "Reviews-{mname}-{mlang}-{mcity}", "~/Movie_ReadReviews.aspx", true, new System.Web.Routing.RouteValueDictionary { { "mname", "" }, { "mlang", "" }, { "mcity", "" } });
        routes.MapPageRoute("SearchMore", "MoreCategories-{maincat}-{cat1}-{cat2}-{cat3}", "~/SearchMore.aspx");
        routes.MapPageRoute("B2bcatageories", "Catageories-{catname}", "~/More.aspx");//10-7-14
        routes.MapPageRoute("Mobile_verification", "Verification-{MobVCode}", "~/MobileConfirmation.aspx");
        routes.MapPageRoute("sessionstores_movies", "sessionstoressDetails-{id}", "~/sessionstore.aspx");//26-7-14
        routes.MapPageRoute("mailsessionstore", "CompanydDetails-{id}-{cname}", "~/sessionstore.aspx");
        routes.MapPageRoute("mailRating", "Companyratings-{DataId}", "~/PostReviewCat.aspx");
        routes.MapPageRoute("sessionstoretravels", "sessionstoretraveldetails-{id}", "~/sessionstore.aspx");//28-07-2014

        routes.MapPageRoute("NewMoviesdata", "NewMovies-{location}-{day}-{time}-{sort}-{mid}-{MovId}", "~/MovieDetails.aspx");  
        routes.MapPageRoute("justcallterms", "Terms-Of-Use", "~/TurmsOfUse.aspx");
        routes.MapPageRoute("tag_friends", "Tagmorefriends-{tagid}", "~/Tag-morefriends.aspx");
        routes.MapPageRoute("tag_friendsRatings", "Tagfriendsratings-{reg_rateid}-{loginid}", "~/Taggedfriends-Ratingdetails.aspx");
        routes.MapPageRoute("Show_more", "Showmorefriends-{loginid}", "~/Show-moreTaggedfriends.aspx");
        routes.MapPageRoute("Link_popcate", "PopularCategoryDetails-{pcname}-{popcate}-{cattype}", "~/linkcontroller.aspx");
        routes.MapPageRoute("lnkresultss", "{pcname}-result in-{city}", "~/linkresults.aspx");//26-12-14      
               
    }

       
</script>
