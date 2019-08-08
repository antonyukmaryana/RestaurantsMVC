namespace ToDoList.Models
{
    public class Class2
    {
        public int Class2Id { get; set; }
        public string Description { get; set; }
        public int Class1Id { get; set; }
        public virtual Class1 Class1 { get; set; }
    }
}