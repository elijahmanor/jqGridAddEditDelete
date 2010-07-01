
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;

namespace jqGridAddEditDelete.Models
{
    public class ContactRepository: IContactRepository
    {
        public ContactViewModel Get(Guid id)
        {
            ContactViewModel viewModel = null;
            if (HttpContext.Current.Session["ContactList"] != null)
            {
                var list = HttpContext.Current.Session["ContactList"] as IList<ContactViewModel>;
                if (list != null) 
                {
                    viewModel = list.FirstOrDefault(x => x.ContactId == id);
                }
            }
            return viewModel;
        }

        public IList<ContactViewModel> GetAll()
        {
            IList<ContactViewModel> list = new List<ContactViewModel>(); 
            if (HttpContext.Current.Session["ContactList"] != null)
            {
                list = HttpContext.Current.Session["ContactList"] as IList<ContactViewModel>;
            } 
            else
            {
                list.Add(new ContactViewModel { ContactId = Guid.NewGuid(), DateOfBirth = DateTime.Now.Subtract(new TimeSpan(new Random().Next(123456789, 999999999))), Email = "elijah.manor@spam.com", IsMarried = true, Name = "Elijah Manor", PhoneNumber = "(615) 111-1111"});
                list.Add(new ContactViewModel { ContactId = Guid.NewGuid(), DateOfBirth = DateTime.Now.Subtract(new TimeSpan(new Random().Next(123456789, 999999999))), Email = "daniel.mohl@spam.com", IsMarried = true, Name = "Daniel Mohl", PhoneNumber = "(615) 222-2222" });
                list.Add(new ContactViewModel { ContactId = Guid.NewGuid(), DateOfBirth = DateTime.Now.Subtract(new TimeSpan(new Random().Next(123456789, 999999999))), Email = "alex.robson@spam.com", IsMarried = true, Name = "Alex Robson", PhoneNumber = "(615) 333-3333" });
                list.Add(new ContactViewModel { ContactId = Guid.NewGuid(), DateOfBirth = DateTime.Now.Subtract(new TimeSpan(new Random().Next(123456789, 999999999))), Email = "evan.hoff@spam.com", IsMarried = false, Name = "Evan Hoff", PhoneNumber = "(615) 444-4444" });
                list.Add(new ContactViewModel { ContactId = Guid.NewGuid(), DateOfBirth = DateTime.Now.Subtract(new TimeSpan(new Random().Next(123456789, 999999999))), Email = "jim.cowart@spam.com", IsMarried = true, Name = "Jim Cowart", PhoneNumber = "(615) 555-5555" });
                list.Add(new ContactViewModel { ContactId = Guid.NewGuid(), DateOfBirth = DateTime.Now.Subtract(new TimeSpan(new Random().Next(123456789, 999999999))), Email = "james.hagewood@spam.com", IsMarried = false, Name = "James Hagewood", PhoneNumber = "(615) 666-6666" });
                list.Add(new ContactViewModel { ContactId = Guid.NewGuid(), DateOfBirth = DateTime.Now.Subtract(new TimeSpan(new Random().Next(123456789, 999999999))), Email = "josh.bush@spam.com", IsMarried = true, Name = "Josh Bush", PhoneNumber = "(615) 777-7777" });
                HttpContext.Current.Session["ContactList"] = list;
            }

            return list;
        }

        public IList<ContactViewModel> FindAll(IDictionary<string, object> propertyValuePairs)
        {
            throw new NotImplementedException();
        }

        public ContactViewModel FindOne(IDictionary<string, object> propertyValuePairs)
        {
            throw new NotImplementedException();
        }

        public ContactViewModel SaveOrUpdate(ContactViewModel entity)
        {
            ContactViewModel viewModel = null;
            if (HttpContext.Current.Session["ContactList"] != null)
            {
                var list = HttpContext.Current.Session["ContactList"] as IList<ContactViewModel>;
                if (list != null)
                {
                    viewModel = list.FirstOrDefault(x => x.ContactId == entity.ContactId);
                    if (viewModel != null)
                    {
                        viewModel.DateOfBirth = entity.DateOfBirth;
                        viewModel.Email = entity.Email;
                        viewModel.IsMarried = entity.IsMarried;
                        viewModel.Name = entity.Name;
                        viewModel.PhoneNumber = entity.PhoneNumber;
                    }
                    else
                    {
                        entity.ContactId = Guid.NewGuid();
                        list.Add(entity);
                    }
                }
            }
            return viewModel;            
        }

        public void Delete(ContactViewModel entity)
        {
            if (HttpContext.Current.Session["ContactList"] != null)
            {
                var list = HttpContext.Current.Session["ContactList"] as IList<ContactViewModel>;
                if (list != null)
                {
                    var viewModel = list.FirstOrDefault(x => x.ContactId == entity.ContactId);
                    list.Remove(viewModel);
                }
            }
        }

        public IDbContext DbContext
        {
            get { throw new NotImplementedException(); }
        }

        public bool HasErrors { get; set; }

        public List<ErrorViewModel> Errors
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}