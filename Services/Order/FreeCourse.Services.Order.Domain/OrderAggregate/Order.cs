﻿using FreeCourse.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        //EF Core Features
        // -- Owned Types
        // -- Shadow Property
        // -- Backing Field
        public DateTime CreatedTime { get; private set; }
        public Address Address { get; private set; }
        public string BuyerId { get; private set; }
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public Order() { }
        public Order(Address address, string buyerId)
        {
            _orderItems = new List<OrderItem>();
            CreatedTime = DateTime.Now;
            Address = address;
            BuyerId = buyerId;
        }
        public void AddOrderItem(string productId, string productName, decimal price, string pictureUrl)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);
            if (!existProduct)
            {
                _orderItems.Add(new OrderItem(productId, productName, pictureUrl, price));
            }
        }
        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }
}
