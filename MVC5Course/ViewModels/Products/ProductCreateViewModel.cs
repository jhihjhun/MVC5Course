using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels.Products
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "請輸入產品名稱。")]
        [StringLength(10, ErrorMessage = "商品名稱不得超過10個字。")]
        public string ProductName { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        public Nullable<decimal> Stock { get; set; }
    }
}