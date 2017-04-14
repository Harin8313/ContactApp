using System.Data.Entity;
using ContactFormApi.Data.Models;

namespace ContactFormApi.Data.DataContext
{
    public class ContactInformationDataContext : DbContext
    {
        public ContactInformationDataContext() : base("ContactInfoDB")
        {
            Database.SetInitializer(
                    new DropCreateDatabaseIfModelChanges<ContactInformationDataContext>());
        }

        public virtual DbSet<ContactInformation> Contacts { get; set; }


    }
}