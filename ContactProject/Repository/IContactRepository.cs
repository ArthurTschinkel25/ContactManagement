using ContactProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactProject.Repository
{
    public interface IContactRepository
    {
        ContactModel ListById(int id);
        List<ContactModel> searchContacts();
        ContactModel AddContact(ContactModel contact);
        ContactModel UpdateContact(ContactModel contact);
        bool Delete(int id);
    }
}
