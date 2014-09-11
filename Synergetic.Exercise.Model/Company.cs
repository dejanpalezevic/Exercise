using Synergetic.Exercise.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synergetic.Exercise.Model
{
    public class Company : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
