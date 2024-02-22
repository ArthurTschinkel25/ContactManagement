using ContactProject.Models;
using ContactProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace ContactControll.Controllers
{
    public class Contact : Controller
    {
        private readonly IContactRepository _contactRepository;
        public Contact(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.searchContacts();
            return View(contacts);
        }
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateContact(ContactModel contact)
        {
            _contactRepository.AddContact(contact);
            return RedirectToAction("Index");
        }
        public IActionResult EditContact(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            _contactRepository.UpdateContact(contact);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id )
        {
            _contactRepository.Delete(id);
            return RedirectToAction("index");
        }
        public IActionResult DeleteContact(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }
    }
}

 