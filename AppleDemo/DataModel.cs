namespace AppleDemo
{
    internal class DataModel
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string[] Toppings { get; set; }

        public override string ToString()
        {
            var toppingsList = string.Join(",", Toppings);
            return $"{nameof(Name)}: {Name}, {nameof(Department)}: {Department}, {nameof(Toppings)}: [{toppingsList}]";
        }
    }
}