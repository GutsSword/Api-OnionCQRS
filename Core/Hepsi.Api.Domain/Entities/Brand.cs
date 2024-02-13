﻿using Hepsi.Api.Domain.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsi.Api.Domain.Entities
{
    public class Brand : EntityBase
    {
        public Brand()
        {
            
        }
        public Brand(string name)
        {
            Name = name;
        }

        public required string Name { get; set; }
    }
}
