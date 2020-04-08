using System.Data.Entity;

namespace nwtf_mobile_api.Data
{
    public class nwtf_mobile_apidbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public nwtf_mobile_apidbContext() : base("name=nwtf_mobile_apidbContext")
        {
        }

        public System.Data.Entity.DbSet<nwtf_mobile_api.Models.vwRegistry> vwRegistries { get; set; }
    }
}
