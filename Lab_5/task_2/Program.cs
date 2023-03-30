namespace Task_2
{
    class Program
    {
        static object _trafficLightLocker = new object();
        static SemaphoreSlim _semaphore = new SemaphoreSlim(2);
        static Dictionary<string, ManualResetEvent> _greenSignals = new Dictionary<string, ManualResetEvent>();

        static void Main(string[] args)
        {
            // Create 4 threads for traffic lights 
            Thread trafficLight1 = new Thread(() => TrafficLight("North"));
            Thread trafficLight2 = new Thread(() => TrafficLight("South"));
            Thread trafficLight3 = new Thread(() => TrafficLight("East"));
            Thread trafficLight4 = new Thread(() => TrafficLight("West"));

            // Create 4 threads for cars
            Thread car1 = new Thread(() => Car("North"));
            Thread car2 = new Thread(() => Car("South"));
            Thread car3 = new Thread(() => Car("East"));
            Thread car4 = new Thread(() => Car("West"));

            // Start threads
            trafficLight1.Start();
            trafficLight2.Start();
            trafficLight3.Start();
            trafficLight4.Start();

            car1.Start();
            car2.Start();
            car3.Start();
            car4.Start();

            // Wait for threads to finish
            trafficLight1.Join();
            trafficLight2.Join();
            trafficLight3.Join();
            trafficLight4.Join();
        }

        static void TrafficLight(string name)
        {
            while (true)
            {
                try
                {
                    Monitor.Enter(_trafficLightLocker);    // Lock the object
                    Console.WriteLine($"Traffic light is red: {name}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Traffic light is yellow: {name}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Traffic light is green: {name}");

                    if (!_greenSignals.ContainsKey(name))
                        _greenSignals.Add(name, new ManualResetEvent(false));
                    else
                        _greenSignals[name].Reset();

                    _greenSignals[name].Set();
                }
                finally
                {
                    Thread.Sleep(2000);
                    Monitor.Exit(_trafficLightLocker);    // Unlock the object
                }
            }
        }

        static void Car(string direction)
        {
            while (true)
            {
                Console.WriteLine("Car is waiting to move...");

                // Wait for the green signal
                if (!_greenSignals.ContainsKey(direction))
                    _greenSignals.Add(direction, new ManualResetEvent(false));
                _greenSignals[direction].WaitOne();

                _semaphore.Wait();
                Thread.Sleep(1000);
                Console.WriteLine($"Car is moving {direction}...");
                Thread.Sleep(1000);
                Console.WriteLine("Car is at destination point...");
                _semaphore.Release();
            }
        }
    }
}

