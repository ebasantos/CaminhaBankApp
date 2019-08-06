using System.ComponentModel.DataAnnotations;

namespace Model
{
    public abstract class  Entity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
