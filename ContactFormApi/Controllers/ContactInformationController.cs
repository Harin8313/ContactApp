using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Web.Http.Cors;
using ContactFormApi.Data.Models;
using ContactFormApi.Data.Repository;

namespace ContactFormApi.Controllers
{
    [EnableCors(origins: "http://localhost:7855", headers: "*", methods: "*")]
    public class ContactInformationController : ApiController
    {
        private readonly IRepository repository;

        public ContactInformationController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IHttpActionResult GetContacts()
        {
            var contacts = repository.GetContactInformation();
            return Ok(contacts);
        }
       
        [HttpGet]
        public IHttpActionResult GetContact(int id)
        {
            var contact = repository.GetContactInformation(id);
            if (!string.IsNullOrEmpty(contact.FirstName))
            {
                return Ok(contact);
            }

            return NotFound();
        }

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
