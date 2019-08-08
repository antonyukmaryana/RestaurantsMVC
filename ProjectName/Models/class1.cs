using System.Collections.Generic;

namespace ProjectName.Models
{
    public class Class1
    {
        public int Class1Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public Class1()
        {
            this.Items = new HashSet<Item>();
        }
    }
}