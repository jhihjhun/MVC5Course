using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Omu.ValueInjecter;

namespace MVC5Course.Controllers
{
    public class ClientController : Controller
    {
        private readonly FabricsEntities db = new FabricsEntities();

        public ActionResult Read()
        {
            var data = db.Client
                .Take(10)
                .Select(x => new ViewModels.Client.ClientReadViewModel.ClientListItem
                {
                    ClientId = x.ClientId,
                    XCode = x.XCode,
                    CreditRating = x.CreditRating,
                    DateOfBirth = x.DateOfBirth,
                    FirstName = x.FirstName,
                    Gender = x.Gender,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    OccupationId = x.OccupationId,
                    TelephoneNumber = x.TelephoneNumber,
                }).ToList();

            ViewModels.Client.ClientReadViewModel viewModel = new ViewModels.Client.ClientReadViewModel();


            viewModel.ClientList = data;


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Read(ViewModels.Client.ClientReadViewModel viewModel)
        {
            var clientList = db.Client.AsQueryable();

            if (!string.IsNullOrEmpty(viewModel.Condiction.Keyword))
            {
                clientList = clientList.Where(x => x.FirstName.Contains(viewModel.Condiction.Keyword));
            }

            viewModel.ClientList = clientList
                .Take(10)
                .Select(x => new ViewModels.Client.ClientReadViewModel.ClientListItem
                {
                    ClientId = x.ClientId,
                    XCode = x.XCode,

                    CreditRating = x.CreditRating,
                    DateOfBirth = x.DateOfBirth,
                    FirstName = x.FirstName,
                    Gender = x.Gender,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    OccupationId = x.OccupationId,
                    TelephoneNumber = x.TelephoneNumber
                }).ToList();

            return View(viewModel);
        }

        public ActionResult Update(int id)
        {
            var client = db.Client.Find(id);

            if (null == client)
            {
                return new HttpNotFoundResult();
            }

            var viewModel = new ViewModels.Client.ClientUpdateViewModel
            {
                ClientId = client.ClientId,
                XCode = client.XCode,
                CreditRating = client.CreditRating,
                DateOfBirth = client.DateOfBirth,
                FirstName = client.FirstName,
                Gender = client.Gender,
                LastName = client.LastName,
                MiddleName = client.MiddleName,
                OccupationId = client.OccupationId,
                TelephoneNumber = client.TelephoneNumber,
                City = client.City,
                Latitude = client.Latitude,
                Street1 = client.Street1,
                Street2 = client.Street2,
                Longitude = client.Longitude,
                Notes = client.Notes,
                ZipCode = client.ZipCode,
                IdNumber = client.IdNumber
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(ViewModels.Client.ClientUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var client = db.Client.Find(viewModel.ClientId);

            if (null == client)
            {
                return new HttpNotFoundResult();
            }

            client.InjectFrom(viewModel);
            db.SaveChanges();

            return RedirectToAction("Read");
        }

    }
}