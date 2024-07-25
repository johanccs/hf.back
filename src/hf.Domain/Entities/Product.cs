﻿using hf.Domain.Abstractions;

namespace hf.Domain.Entities
{
    public class Product : Entity
    {
        #region properties

        public string ProductName { get; private set; }

        public string ProductDescription { get; private set; }
        
        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public string ImageUrl { get; private set; }

        #endregion

        #region ctor

        public Product():base(Guid.NewGuid())
        {

        }

        public Product(
            Guid productId,
            string productName, 
            string productDescription, 
            decimal price, 
            int quantity, 
            string imageUrl):base(productId)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            Price = price;
            Quantity = quantity;
            ImageUrl = imageUrl;
        }

        #endregion

        #region methods

        protected override bool Validate()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}


//public id: string,
//public productName: string,
//public productDescription: string,
//public price: number,
//public quantity: number,
//public imageList: string