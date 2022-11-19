public enum Operation
{
    Sum,
    Subtract,
    Multiply
}
public class OperationManager
{
    private int _first;
    private int _second;
    private ExecutionManager executionManager;
    public OperationManager(int first, int second)
    {
        _first = first;
        _second = second;
        executionManager = new ExecutionManager();
        executionManager.PopulateFunctions(Sum, Subtract, Multiply);
        executionManager.PrepareExecution();
    }
    private int Sum()
    {
        return _first + _second;
    }
    private int Subtract()
    {
        return _first - _second;
    }
    private int Multiply()
    {
        return _first * _second;
    }
    public int Execute(Operation operation)
    {
        return executionManager.FuncExecute[operation].Invoke();
    }
}

//Implement functionality
public class ExecutionManager
{
    public Dictionary<Operation, Func<int>> FuncExecute { get; set; }
    //Add delegates for sum, substrat and multiply here
    Func<int> Sum;
    Func<int> Substract;
    Func<int> Multiply;

    public ExecutionManager()
    {
        FuncExecute = new Dictionary<Operation, Func<int>>();
    }

    public void PopulateFunctions(Func<int> sum, Func<int> substract, Func<int> multiply)//pass delegates and register)
    {
        Sum = sum;
        Substract = substract;
        Multiply = multiply;
    }
    public void PrepareExecution()
    {
        //fill dictionary here
        FuncExecute.Add(Operation.Sum, Sum);
        FuncExecute.Add(Operation.Subtract, Substract);
        FuncExecute.Add(Operation.Multiply, Multiply);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var opManager = new OperationManager(33, 17);
        var result1 = opManager.Execute(Operation.Subtract);
        var result2 = opManager.Execute(Operation.Multiply);
        var result3 = opManager.Execute(Operation.Sum);
        Console.WriteLine($"The result of the operation 1 is {result1}");
        Console.WriteLine($"The result of the operation 2 is {result2}");
        Console.WriteLine($"The result of the operation 3 is {result3}");
        Console.ReadKey();
    }
}
