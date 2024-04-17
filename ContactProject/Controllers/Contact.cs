using ContactProject.Models;
using ContactProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
           try
            {
                if (ModelState.IsValid)
                {

                    _contactRepository.AddContact(contact);
                    TempData["SucessMessage"] = "Contact successfully registered";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (Exception error) 
            {
                TempData["ErrorMessage"] = $"An error occurred while registering the contact, error details:{error.Message}";
                return RedirectToAction("Index");
            }

        }
        public IActionResult EditContact(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.UpdateContact(contact);
                    TempData["SucessMessage"] = "Contact successfully edited";
                    return RedirectToAction("Index");
                }
                return View("EditContact", contact);
            }
            catch (Exception error) 
            {
                TempData["ErrorMessage"] = $"An error occurred while editing the contact, error details:{error.Message}";
                return RedirectToAction("Index");
            }

        }
        public IActionResult Delete(int id)
        {
            try
            {
                bool apagado =  _contactRepository.Delete(id);
                if(apagado)
                {
                     TempData["SucessMessage"] = "Contact successfully deleted";
                }
                else
                {
                    TempData["SucessMessage"] = "An error occurred while deleting the contact";
                }
                return RedirectToAction("index");
            }
            catch(Exception error)
            {
                TempData["SucessMessage"] = $"An error occurred while deleting the contact, error details: {error.Message}";
                return RedirectToAction("index");

            }


        }
        public IActionResult DeleteContact(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }
    }
}

 