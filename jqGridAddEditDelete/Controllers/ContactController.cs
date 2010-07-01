
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using jqGridAddEditDelete.Models;

namespace jqGridAddEditDelete.Controllers
{
    public class ContactController : Controller
    {
        private IContactRepository repository;

        public ContactController()
        {
            repository = new ContactRepository();
        }

        public ContactController(IContactRepository repository)
        {
            this.repository = repository;
        }

        public virtual ActionResult List(string sidx, string sord, int page, int rows)
        {
            var contacts = repository.GetAll() as IEnumerable<ContactViewModel>;

            var pageIndex = Convert.ToInt32(page) - 1;
            var pageSize = rows;
            var totalRecords = contacts.Count();
            var totalPages = (int) Math.Ceiling((float) totalRecords / (float) pageSize);

            contacts = contacts.Skip(pageIndex * pageSize).Take(pageSize);

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = (
                    from contact in contacts
                    select new
                    {
                        i = contact.ContactId.ToString(),
                        cell = new string[] {
                            contact.ContactId.ToString(), 
                            contact.Name, 
                            contact.DateOfBirth.ToShortDateString(),
                            contact.Email,
                            contact.PhoneNumber,
                            contact.IsMarried.ToString()
                        }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(ContactViewModel viewModel, FormCollection formCollection)
        {
            var operation = formCollection["oper"];
            if (operation.Equals("add") || operation.Equals("edit"))
            {
                repository.SaveOrUpdate(new ContactViewModel
                {
                    ContactId = viewModel.ContactId,
                    DateOfBirth = viewModel.DateOfBirth,
                    Email = viewModel.Email,
                    IsMarried = viewModel.IsMarried,
                    Name = viewModel.Name,
                    PhoneNumber = viewModel.PhoneNumber
                });
            }
            else if (operation.Equals("del"))
            {
                repository.Delete(new ContactViewModel
                {
                    ContactId = viewModel.ContactId
                    //ContactId = new Guid(formCollection["id"])
                });
            }

            return Content(repository.HasErrors.ToString().ToLower()); 
        }
    }
}
