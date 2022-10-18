using EventsAndLINQ;

public class Program
{
    public event Func<double, double, double> AddHandler;

    public static void Main(string[] args)
    {
        var program = new Program();
        program.AddHandlerTransformarion(() => program.Add(2, 3));
        var list = new List<Contact>() { new Contact("a", "1"), new Contact("b", "2"), new Contact("ca", "3") };
        var listEmpty = new List<Contact>() { new Contact("b", "2"), new Contact("d", "4") };
        Console.WriteLine(list.FirstOrDefault().Name);
        Console.WriteLine();
        var listWhere = list.Where(w => w.Name.Length < 2);
        Console.WriteLine("Where");
        foreach (var item in listWhere)
        {
            Console.WriteLine($"{item.Name} - {item.Number}");
        }

        Console.WriteLine();
        var listSelect = list.Select(s => "2");
        Console.WriteLine("Select");
        foreach (var item in listSelect)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("Any");
        Console.WriteLine(list.Any(a => a.Name.Length > 3));
        Console.WriteLine();
        Console.WriteLine("Union");
        var listUnion = list.Union(listEmpty);
        foreach (var item in listUnion)
        {
            Console.WriteLine(item.Name);
        }

        list.Reverse();
        Console.WriteLine("Reverse");
        foreach (var item in list)
        {
            Console.WriteLine(item.Name);
        }
    }

    public void AddHandlerTransformarion(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    public void Add(double a, double b)
    {
        var program = new Program();
        program.AddHandler += program.AddCore;
        program.AddHandler += program.AddCore;
        double sum = 0;
        var paramsList = program.AddHandler.GetInvocationList();
        foreach (var method in paramsList)
        {
            sum += Convert.ToDouble(method.DynamicInvoke(a, b));
        }

        Console.WriteLine($"Sum is {sum}");
    }

    private double AddCore(double a, double b) => a + b;
}