using ContactControll.Controllers;
using ContactControll.Data;
using ContactProject.Models;
using Microsoft.IdentityModel.Tokens;
using System.Buffers.Text;

namespace ContactProject.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly BaseContext _baseContext;
        public ContactRepository(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }
        public List<ContactModel> searchContacts()
        {
            return _baseContext.Contacts.ToList();
        }
        public ContactModel AddContact(ContactModel contact)
        {
            _baseContext.Contacts.Add(contact);
            _baseContext.SaveChanges();
            return contact;
        }

        public ContactModel ListById(int id)
        {
            return _baseContext.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public ContactModel UpdateContact(ContactModel contact)
        {
            ContactModel contactDb = ListById(contact.Id);
            if (contactDb == null) throw new Exception("An error occurred while updating the contact");

            contactDb.Name = contact.Name;
            contactDb.Email = contact.Email;
            contactDb.Phone = contact.Phone;

            _baseContext.Contacts.Update(contactDb);    
            _baseContext.SaveChanges();

            return contactDb;
        }

        public bool Delete(int id)
        {
            ContactModel contactDb = ListById(id);
            if (contactDb == null) throw new Exception("An error occurred while deleting the contact");
            _baseContext.Contacts.Remove(contactDb);
            _baseContext.SaveChanges();
            return true;
        }
    }
}