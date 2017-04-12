using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using ContactFormApi.Data.Models;
using ContactFormApi.Data.Repository;

namespace ContactFormApi.Controllers
{
    public class ContactInformationController : ApiController
    {
        private readonly IRepository repository;

        public ContactInformationController(IRepository repository)
        {
            this.repository = repository;
        }

        public IHttpActionResult Get()
        {
            var contacts = repository.GetContactInformation();
            return Ok(contacts);
        }

        //public IHttpActionResult Get(int id=0)
        //{
        //    var contact = repository.GetContactInformation(id);
        //    if (!string.IsNullOrEmpty(contact.FirstName))
        //    {
        //        return Ok(contact);
        //    }

        //    return NotFound();
        //}

        public IHttpActionResult Delete(int id)
        {
            bool result = repository.DeleteContactInformation(id);
            if (result)
            {
                return Ok(id);
            }

            return NotFound();
        }

        public IHttpActionResult Put([FromBody] ContactInformation contactInformation)
        {
            if (!IsModelValid(contactInformation)) return BadRequest();
            bool result = repository.EditContactInformation(contactInformation);
            if (result)
            {
                return Ok(contactInformation);
            }

            return NotFound();
        }

        public IHttpActionResult Post([FromBody] ContactInformation contactInformation)
        {
            if (!IsModelValid(contactInformation)) return BadRequest();
            bool result = repository.AddContactInformation(contactInformation);
            if (result)
            {
                return Ok(contactInformation);
            }

            return NotFound();
        }

        private static bool IsModelValid(ContactInformation contactInformation)
        {
            var context = new ValidationContext(contactInformation, null, null);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(contactInformation, context, results);
        }
    }
}
