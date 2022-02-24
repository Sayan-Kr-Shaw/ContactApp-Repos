using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactServices.ContactsDb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ContactServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : Controller
    {
       List<Contacts> Cont = new List<Contacts>();

        [HttpGet]
        public IActionResult Gets()
        {
            if (Cont.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(Cont);
        }

        [HttpGet]
        public JsonResult GetContact(string ContactId)
        {
            var contact = Cont.SingleOrDefault(x=>x.ContactId == ContactId);
            //if(contact == null)
            //{
            //    return NotFound("No Contact Found");
            //}
            return Json(contact);
        }

        [HttpPost]
        public IActionResult Save(Contacts contact)
        {
            Cont.Add(contact);
            if (Cont.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(Cont);
        }

        [HttpPut]
        public IActionResult Update(ContactsDb.Contacts contacts)
        {
           // bool status = false;

            try
            {

                Contacts prodObj = new Contacts();
                prodObj.ContactId = contacts.ContactId;
                prodObj.Name = contacts.Name;
                prodObj.Birthday = contacts.Birthday;
                prodObj.Marriage_Anniversary = contacts.Marriage_Anniversary;
                prodObj.Notes = contacts.Notes;
                
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
               // status = false;
            }
            return Ok(contacts);
        }

        [HttpDelete]
        public IActionResult DeleteContact(string ContactId)
        {
            var contact = Cont.SingleOrDefault(x => x.ContactId == ContactId);
            if (contact == null)
            {
                return NotFound("No Contact Found");
            }
            Cont.Remove(contact);
            if(Cont.Count == 0)
            {
                return NotFound("No list found");
            }
            return Ok(contact);
        }

    }
}
