using System;

public class EventPublisher
{
    public event Action<string> MyEvent;

    private string name;

    public EventPublisher(string name)
    {
        this.name = name;
    }

    public void RaiseEvent()
    {
        MyEvent?.Invoke(name);
    }
}

public class EventHandler
{
    public void HandleEvent(string eventName)
    {
        Console.WriteLine($"{eventName}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        EventHandler handler = new EventHandler();

        EventPublisher publisher1 = new EventPublisher("1");
        EventPublisher publisher2 = new EventPublisher("2");

        publisher1.MyEvent += handler.HandleEvent;
        publisher2.MyEvent += handler.HandleEvent;

        publisher1.RaiseEvent();
        publisher2.RaiseEvent();
    }
}