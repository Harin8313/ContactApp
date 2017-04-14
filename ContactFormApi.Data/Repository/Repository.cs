using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ContactFormApi.Data.DataContext;
using ContactFormApi.Data.Models;

namespace ContactFormApi.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly ContactInformationDataContext context;

        public Repository(ContactInformationDataContext context)
        {
            this.context = context;                 
        }
        
        public IEnumerable<ContactInformation> GetContactInformation()
        {           
             return context.Contacts.ToList();            
        }

        public ContactInformation GetContactInformation(int id)
        {
            return context.Contacts.FirstOrDefault(m=>m.Id==id);
        }

        public bool AddContactInformation(ContactInformation contact)
        {            
            context.Contacts.Add(contact);
            int result = context.SaveChanges();

            return result==1;           
        }

        public bool EditContactInformation(ContactInformation contact)
        {
           
            context.Entry(contact).State = EntityState.Modified;

            int result = context.SaveChanges();

            return result == 1;          
        }

        public bool DeleteContactInformation(int id)
        {
            var contact = context.Contacts.FirstOrDefault(m => m.Id == id);
            if (contact != null)
                context.Contacts.Remove(contact);

            int result = context.SaveChanges();

            return result == 1;
        }
       
        private bool disposed = false;
       
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
