﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities
{
    [Serializable]
    public class Item
    {
        public int ProductId { get; set; }
        public int Quantity {  get; set; }
    }
}
