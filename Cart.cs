using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommence_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace MvcApplication1.Models
{/*
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        //Add item
        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine(){Product = product, Quantity = quantity});
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //Increase or decrease the item number
        public void IncreaseOrDecreaseOne(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            if (line != null)
            {
                line.Quantity = quantity;
            }
        }

        //Remove
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(p => p.Product.Id == product.Id);
        }

        //Compute the total price
        public decimal ComputeTotalPrice()
        {
            return lineCollection.Sum(p => p.Product.Price*p.Quantity);
        }

        //Clear
        public void Clear()
        {
            lineCollection.Clear();
        }

        //Get
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }*/
}