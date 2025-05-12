# patterns
update on design patterns
**🎨 1. Decorator Pattern**
🔧 What is it?
Allows you to add new features to an object without changing its structure.

🧍‍♂️ Real-world example:
You buy a plain coffee ☕. Then you ask to add milk 🥛 or sugar 🍬. You are “decorating” the original object.

✅ Simple C# Example:
csharp
Copy
Edit
// Component
interface ICoffee
{
    string GetDescription();
    double GetCost();
}

// Concrete Component
class PlainCoffee : ICoffee
{
    public string GetDescription() => "Plain Coffee";
    public double GetCost() => 20;
}

// Decorator Base
abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;
    public CoffeeDecorator(ICoffee coffee) => _coffee = coffee;
    public virtual string GetDescription() => _coffee.GetDescription();
    public virtual double GetCost() => _coffee.GetCost();
}

// Concrete Decorator
class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }
    public override string GetDescription() => _coffee.GetDescription() + ", Milk";
    public override double GetCost() => _coffee.GetCost() + 5;
}

// Usage
class Program
{
    static void Main()
    {
        ICoffee coffee = new PlainCoffee();
        coffee = new MilkDecorator(coffee);
        Console.WriteLine(coffee.GetDescription());  // Plain Coffee, Milk
        Console.WriteLine("R" + coffee.GetCost());   // R25
    }
}
🧠 Key Idea:
Keep wrapping objects to add more behavior.

You don’t touch the original code (PlainCoffee), just add layers.

**🧵 2. Threading (Multithreading)**
🧧 What is it?
Threading allows your app to do multiple things at once (run in parallel).

🧍‍♂️ Real-world example:
You are cooking and washing dishes at the same time. That’s multitasking, just like threads.

✅ Simple C# Example:
csharp
Copy
Edit
using System;
using System.Threading;

class Program
{
    static void DoWork()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Working...");
            Thread.Sleep(500); // wait for 0.5 second
        }
    }

    static void Main()
    {
        Thread thread = new Thread(DoWork); // create thread
        thread.Start(); // run in parallel

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Main thread running...");
            Thread.Sleep(500);
        }
    }
}
🧠 Key Idea:
Use Thread or Task to run methods in the background.

Good for long tasks (file loading, network).

**✅ 3. What is a Singleton?**
A Singleton is a class where only one object (instance) is allowed to exist, and everyone shares that one object.

🧍‍♂️ Real-world example:
Imagine your school only has one printer. No matter who prints, everyone must use that same printer.

You don’t want everyone creating their own printer.

You create one and everyone shares it.

That’s a Singleton.

🔧 What makes a class a Singleton in C#?
csharp
Copy
Edit
class MySingleton
{
    private static MySingleton _instance = null;
    private static readonly object _lock = new object();

    private MySingleton() { } // ❌ Can't create this object from outside

    public static MySingleton GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new MySingleton();
            }
        }
        return _instance;
    }
}
🧠 Easy Way to Remember:
"Make the constructor private, and create one object using a method."

💻 What does your exam mark example do?
Let’s break it down visually:

plaintext
Copy
Edit
Program
   |
   +--> Gets Singleton object (MarksManager)
          |
          +--> Adds marks (if not in calc mode)
          |
          +--> Switches to calc mode
          |
          +--> Calculates average per student
✅ Here's a simple version of your code:
csharp
Copy
Edit
class ExamMark
{
    public string StudentNumber;
    public double Percentage;

    public ExamMark(string number, double percentage)
    {
        StudentNumber = number;
        Percentage = percentage;
    }
}

class MarksManager
{
    private static MarksManager instance = null;
    private static readonly object myLock = new object();
    private List<ExamMark> marks = new List<ExamMark>();
    private bool isCalculating = false;

    private MarksManager() { }

    public static MarksManager GetInstance()
    {
        if (instance == null)
        {
            lock (myLock)
            {
                if (instance == null)
                    instance = new MarksManager();
            }
        }
        return instance;
    }

    public void AddMark(ExamMark mark)
    {
        if (!isCalculating)
            marks.Add(mark);
    }

    public void StartCalculating()
    {
        isCalculating = true;
    }

    public double GetAverage(string studentNo)
    {
        if (!isCalculating) return -1;

        var studentMarks = marks.Where(m => m.StudentNumber == studentNo);
        if (!studentMarks.Any()) return 0;

        return studentMarks.Average(m => m.Percentage);
    }
}

**🎮 1. Command Pattern**
🔧 What is it?
The Command Pattern turns a request (like “save”, “open”, “undo”) into a standalone object, so you can pass it around, store it, or undo it later.

🧍‍♂️ Real-world example:
A TV remote (Invoker) has buttons (commands). Each button sends a command to the TV (Receiver) like "Turn On", "Turn Off".

✅ Simple C# Example:
csharp
Copy
Edit
// Command interface
interface ICommand
{
    void Execute();
}

// Receiver
class Light
{
    public void TurnOn() => Console.WriteLine("Light is ON");
}

// Command
class TurnOnCommand : ICommand
{
    private Light _light;
    public TurnOnCommand(Light light) => _light = light;
    public void Execute() => _light.TurnOn();
}

// Invoker
class RemoteControl
{
    public void PressButton(ICommand command) => command.Execute();
}

// Usage
class Program
{
    static void Main()
    {
        Light livingRoomLight = new Light();
        ICommand lightOn = new TurnOnCommand(livingRoomLight);
        RemoteControl remote = new RemoteControl();
        remote.PressButton(lightOn);
    }
}
🧠 Think of it as:
Command = an action (TurnOnCommand)

Receiver = the real doer (Light)

Invoker = trigger (Remote)
