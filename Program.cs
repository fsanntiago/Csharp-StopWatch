namespace StopWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Seconds => 10s = 10 seconds");
            Console.WriteLine("M = Minutes => 1m => 1 minutes");
            Console.WriteLine("0 = Exit");
            Console.WriteLine("How long do you want to count?");

            var data = Console.ReadLine()!.ToLower();
            var type = char.Parse(data.Substring(data.Length - 1, 1));
            var time = int.Parse(data.Substring(0, data.Length - 1));

            var multiplier = 1;

            if (time == 0)
            {
                Environment.Exit(0);
            }

            if (type == 'm')
            {
                multiplier = 60;
            }

            PreStart(time * multiplier);
        }

        static void PreStart(int time)
        {
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go...");
            Thread.Sleep(2500);

            Start(time);
        }

        static void Start(int time)
        {
            var currentTime = 0;

            while (currentTime != time)
            {
                Console.Clear();
                currentTime++;
                if (currentTime < 60)
                {
                    Console.WriteLine(currentTime);
                }
                else
                {
                    var minutes = currentTime / 60;
                    var seconds = currentTime - 60;
                    var timeFormatted = minutes > 10 ? $"{minutes}:{seconds}" : $"0{minutes}:{seconds}";
                    Console.WriteLine(timeFormatted);
                }

                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("StopWatch finished");
            Thread.Sleep(2500);

            Menu();
        }
    }
};