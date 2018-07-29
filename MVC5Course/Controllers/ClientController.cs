using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Omu.ValueInjecter;
using System.Net;

namespace MVC5Course.Controllers
{
    [RoutePrefix("client")]
    public class ClientController : BaseController
    {

        //private readonly FabricsEntities db = new FabricsEntities();
        //private readonly ClientRepository _repo = RepositoryHelper.GetClientRepository();

        [Route("ReadClients")]
        public ActionResult Read()
        {
            //    var data = db.Client
            //        .Take(10)
            //        .Select(x => new ViewModels.Client.ClientReadViewModel.ClientListItem
            //        {
            //            ClientId = x.ClientId,
            //            XCode = x.XCode,
            //            CreditRating = x.CreditRating,
            //            DateOfBirth = x.DateOfBirth,
            //            FirstName = x.FirstName,
            //            Gender = x.Gender,
            //            LastName = x.LastName,
            //            MiddleName = x.MiddleName,
            //            OccupationId = x.OccupationId,
            //            TelephoneNumber = x.TelephoneNumber,
            //        }).ToList();

            var data = _repo.All()
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

            ViewModels.Client.ClientReadViewModel viewModel = new ViewModels.Client.ClientReadViewModel
            {
                ClientList = data
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Read(ViewModels.Client.ClientReadViewModel viewModel)
        {
            var clientList = _repo.All();

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

        [Route("UpdateClient")]
        public ActionResult Update(int id)
        {
            var client = _repo.Find(id);

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

            var client = _repo.Find(viewModel.ClientId);

            if (null == client)
            {
                return new HttpNotFoundResult();
            }

            client.InjectFrom(viewModel);
            _repo.UnitOfWork.Commit();

            return RedirectToAction("Read");
        }

        public ActionResult Delete(int id)
        {
            var client = _repo.Find(id);

            if (null == client)
            {
                return new HttpNotFoundResult();
            }

            ViewModels.Client.ClientDeleteViewModel viewModel = new ViewModels.Client.ClientDeleteViewModel
            {
                City = client.City,
                ClientId = client.ClientId,
                Street1 = client.Street1,
                Street2 = client.Street2,
                CreditRating = client.CreditRating,
                DateOfBirth = client.DateOfBirth,
                FirstName = client.FirstName,
                Gender = client.Gender,
                IdNumber = client.IdNumber,
                LastName = client.LastName,
                Latitude = client.Latitude,
                Longitude = client.Longitude,
                MiddleName = client.MiddleName,
                Notes = client.Notes,
                OccupationId = client.OccupationId,
                TelephoneNumber = client.TelephoneNumber,
                XCode = client.XCode,
                ZipCode = client.ZipCode,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(ViewModels.Client.ClientDeleteViewModel viewModel)
        {
            var client = _repo.Find(viewModel.ClientId);

            if (null == client)
            {
                return new HttpNotFoundResult();
            }

            _repo.Delete(client);
            _repo.UnitOfWork.Commit();

            return RedirectToAction("Read");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client client = _repo.Find(id.Value);

            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }
    }
}