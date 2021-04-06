﻿using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;

        private int capacity;
        private int numberOfPeople;
        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }
        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                capacity = value;
            }
        }
        public int TableNumber { get; private set; }
        public decimal PricePerPerson { get; private set; }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                numberOfPeople = value;
            }
        }


        public bool IsReserved { get; set; } = true;

        public decimal Price
        {
            get => PricePerPerson * NumberOfPeople;
        }

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            numberOfPeople = 0;
            IsReserved = false;           
        }

        public decimal GetBill()
        {
            decimal bill = 0;

            foreach (var item in foodOrders)
            {
                bill += item.Price;
            }
            foreach (var item in drinkOrders)
            {
                bill += item.Price;
            }

            return bill;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            string type = GetType().Name;
            sb.AppendLine($"Type: {type}");
            sb.AppendLine($"Capacity: {Capacity}");
         
            sb.AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
