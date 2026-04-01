/*using System;

class TrafficLight
{
    private ColourState state;
    public void SetState(ColourState state) => this.state = state;
    public TrafficLight() => state = new RedState();
    public void Green() => state.Green(this);
    public void Yellow() => state.Yellow(this);
    public void Red() => state.Red(this);
}

class ColourState
{
    public virtual void Green(TrafficLight trafficLight) { }
    public virtual void Yellow(TrafficLight trafficLight) { }
    public virtual void Red(TrafficLight trafficLight) { }
}

class GreenState : ColourState
{
    public override void Green(TrafficLight trafficLight)
    {
        Console.WriteLine("зеленый свет уже горит");
    }

    public override void Yellow(TrafficLight trafficLight)
    {
        Console.WriteLine("желтый свет");
        trafficLight.SetState(new YellowState());
    }

    public override void Red(TrafficLight trafficLight)
    {
        Console.WriteLine("красный свет");
        trafficLight.SetState(new RedState());
    }
}

class YellowState : ColourState
{
    public override void Green(TrafficLight trafficLight)
    {
        Console.WriteLine("зеленый свет");
        trafficLight.SetState(new GreenState());
    }

    public override void Yellow(TrafficLight trafficLight)
    {
        Console.WriteLine("желтый свет уже горит");
    }

    public override void Red(TrafficLight trafficLight)
    {
        Console.WriteLine("красный свет");
        trafficLight.SetState(new RedState());
    }
}
class RedState : ColourState
{
    public override void Green(TrafficLight trafficLight)
    {
        Console.WriteLine("зеленый свет");
        trafficLight.SetState(new GreenState());
    }

    public override void Yellow(TrafficLight trafficLight)
    {
        Console.WriteLine("желтый свет");
        trafficLight.SetState(new YellowState());
    }

    public override void Red(TrafficLight trafficLight)
    {
        Console.WriteLine("красный свет уже горит");
    }
}

class Program
{
    static void Main()
    {
        TrafficLight trafficLight = new TrafficLight();
        trafficLight.Yellow();  
        trafficLight.Green();   
        trafficLight.Green();   
        trafficLight.Red();     
    }
}*/