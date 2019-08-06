
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class City : Entity
    {
        public int StateId { get; set; }
        public virtual State State { get; set; }
    }
}
