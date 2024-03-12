using Hepsi.Api.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsi.Api.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            
        }
        public Category(int parentID, string name, int priorty)
        {
            ParentID = parentID;
            Name = name;
            Priorty = priorty;
        }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public int Priorty { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
