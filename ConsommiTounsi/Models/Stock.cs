﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models
{
    public class Stock
    {

		public int Idstock { get; set; }
		public DateTime DateCreation { get; set; }
		public float Quantity { get; set; }

		public DateTime DateExpiration { get; set; }

		public virtual UserConsomi User { get; set; }
		public virtual List<Product> Products { get; set; }

        public Stock()
        {
        }

        public Stock(int idstock, DateTime dateCreation, float quantity, DateTime dateExpiration, UserConsomi user, List<Product> products)
        {
            Idstock = idstock;
            DateCreation = dateCreation;
            Quantity = quantity;
            DateExpiration = dateExpiration;
            User = user;
            Products = products;
        }
    }
}