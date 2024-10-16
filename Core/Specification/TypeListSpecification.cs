using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class TypeListSpecification :BaseSpecification<Product, string>
    {
        public TypeListSpecification()
        {
            AddSelect(x => x.Type);
            ApplyDistinct();
        }
        
    }
}