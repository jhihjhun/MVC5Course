﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels.Products
{
    public class ProductsReadViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public Nullable<decimal> Price { get; set; }

        public Nullable<decimal> Stock { get; set; }
    }
}