using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace EntityFramework_CodeFirst_Web2
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //Modelde bir değişiklik olduğunda _MigrationHistory senkron çalışmasını sağlamak için kullanılır.
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //veritabanına CodeFirst ile veri eklemek için bu kodu yazdık.
            Database.SetInitializer(new SchoolDBContextSeeder());
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}