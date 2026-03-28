namespace Core
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Type: {Type}";
        }
    }
}