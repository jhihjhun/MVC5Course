﻿using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public abstract class BaseController : Controller
    {
        //private readonly FabricsEntities db = new FabricsEntities();
        protected ClientRepository _repo;
        protected ProductRepository _repo2;

        public BaseController()
        {
            _repo = RepositoryHelper.GetClientRepository();
            _repo2 = RepositoryHelper.GetProductRepository(_repo.UnitOfWork);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            RedirectToAction("Index").ExecuteResult(ControllerContext);
        }
    }
}