using System;

namespace Model
{
    public abstract class People : Entity
    {
        public string Cpf { get; set; }
        public DateTime BornDate { get; set; }
    }
}
