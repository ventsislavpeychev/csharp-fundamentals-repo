﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity, double airConParam)
            : base(fuelQuantity, litersPerKm, tankCapacity, airConParam)
        {
        }

        
    }
}
