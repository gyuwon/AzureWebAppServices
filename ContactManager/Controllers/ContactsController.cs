using System.Web.Mvc;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactRepository _repository;

        public ContactsController()
        {
            _repository = new ContactRepository();
        }

        // GET: Contacts
        public ActionResult Index()
        {
            return View(_repository.GetAllContacts());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {
            Contact model = _repository.FindContact(id);
            return model == null ? HttpNotFound() : (ActionResult)View(model);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "FirstName, LastName, Email")] Contact contact)
        {
            try
            {
                _repository.InsertContact(contact);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            Contact model = _repository.FindContact(id);
            return model == null ? HttpNotFound() : (ActionResult)View(model);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(
            int id,
            [Bind(Include = "FirstName, LastName, Email")] Contact contact)
        {
            try
            {
                contact.Id = id;
                _repository.UpdateContact(contact);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            Contact model = _repository.FindContact(id);
            return model == null ? HttpNotFound() : (ActionResult)View(model);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Contact model = _repository.FindContact(id);
                _repository.DeleteContact(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
