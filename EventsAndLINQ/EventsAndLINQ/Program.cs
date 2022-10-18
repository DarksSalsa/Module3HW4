public class Program
{
    public event Func<double, double, double> AddHandler;

    public static void Main(string[] args)
    {
        var program = new Program();
        program.AddHandlerTransformarion(() => program.Add(2, 3));
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