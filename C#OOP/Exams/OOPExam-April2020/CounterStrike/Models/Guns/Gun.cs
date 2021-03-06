﻿using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        public Gun(string name, int bulletCount)
        {
            Name = name;
            BulletsCount = bulletCount;
        }

        public string Name
        {
            get => name; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }
                name = value;
            }
        }

        public int BulletsCount
        {
            get => bulletsCount; protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);

                }
                bulletsCount = value;
            }
        }

        public abstract int Fire();
    }
}
