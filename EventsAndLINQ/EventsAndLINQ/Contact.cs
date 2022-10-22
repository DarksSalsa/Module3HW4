namespace EventsAndLINQ
{
    public class Contact
    {
        public Contact(string name, string number)
        {
            Name = name;
            Number = number;
        }

        public string Name { get; init; }

        public string Number { get; init; }
    }
}
