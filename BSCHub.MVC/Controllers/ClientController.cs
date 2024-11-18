using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BSCHub.Application;
using BSCHub.Application.Contracts.Persistence;
using BSCHub.Domain.Clients;
using BSCHub.MVC.ViewModels;
using BSCHub.Domain.Users;

namespace BSCHub.MVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IConsultantRepository _consultantRepository;
        public ClientController(IClientRepository clientRepository, IConsultantRepository consultantRepository) 
        {
            this._clientRepository = clientRepository;
            this._consultantRepository = consultantRepository;
        }
        [HttpGet("client/list")]
        public IActionResult List()
        {
            return View(new ClientListViewModel(
               _clientRepository.ListClientsWithConsultants().ToList()));
        }
        [HttpGet("client/list/{consultantId}")]
        public IActionResult ListByConsultant(int consultantId)
        {
            var consultant = _consultantRepository.GetConsultant(consultantId);
            if (consultant == null)
                return NotFound();
            return View("List", new ClientListViewModel(
                _clientRepository.ListClientsByConsultant(consultantId).ToList(),
                consultant));
        }
        

        public IActionResult Edit(int clientId)
        {
            ViewBag.Consultants = _consultantRepository.GetConsultants().Select(p => new SelectListItem
            {
                Value = p.UserId.ToString(),
                Text = p.FirstName + " " + p.LastName
            }).ToList();
            var client = _clientRepository.GetClient(clientId);
            if (client == null)
                return NotFound();
            return View(client);
        }

        [HttpPost]
        public IActionResult Update(Client client, int clientId)
        {
            if (ModelState.IsValid)
            {
                client.ClientId = clientId;
                _clientRepository.Update(client);
                ModelState.Clear();
                return RedirectToAction("List");
            }

            ViewBag.Consultants = _consultantRepository.GetConsultants().Select(p => new SelectListItem
            {
                Value = p.UserId.ToString(),
                Text = p.FirstName + " " + p.LastName
            }).ToList();
            return View("Edit", client);
        }



        public IActionResult Add(int? consultantId = null)
        {
            return View(GetAddData(consultantId));
        }





        [HttpPost]
        public IActionResult Add(Client client)
        {
            if (ModelState.IsValid)
            {
                _clientRepository.Add(client);
                ModelState.Clear();

                return RedirectToAction("List");

            }
            return View("Add", GetAddData());
        }

        private Client GetAddData(int? consultantId = null)
        {
            ViewBag.ConsultantId = consultantId;

            if (consultantId == null)
            {
                ViewBag.Consultants = _consultantRepository.GetConsultants().Select(p => new SelectListItem
                {
                    Value = p.UserId.ToString(),
                    Text = p.FirstName + " " + p.LastName
                }).ToList();
            }
            else
            {
                ViewBag.Consultants = _consultantRepository.GetConsultants().Select(p => new SelectListItem
                {
                    Value = p.UserId.ToString(),
                    Text = p.FirstName + " " + p.LastName
                }).OrderByDescending(p => p.Value == consultantId.ToString()).ToList();
            }


            return new Client();
        }
        [HttpPost]
        public IActionResult DeleteClient(int clientId)
        {


            if (ModelState.IsValid)
            {
                _clientRepository.Delete(clientId);

                return RedirectToAction("List");

            }
            return NoContent();
        }

    }
}
