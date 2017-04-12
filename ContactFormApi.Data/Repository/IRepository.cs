using System;
using System.Collections.Generic;
using ContactFormApi.Data.Models;

namespace ContactFormApi.Data.Repository
{
    public interface IRepository: IDisposable
    {
        IEnumerable<ContactInformation> GetContactInformation();

        ContactInformation GetContactInformation(int id);

        bool AddContactInformation(ContactInformation contact);

        bool EditContactInformation(ContactInformation contact);

        bool DeleteContactInformation(int id);
    }
}