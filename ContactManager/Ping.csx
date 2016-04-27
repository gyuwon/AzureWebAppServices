#r "System.Net.Http"

using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

public async Task Main()
{
    Console.Write("URL: ");
    var url = Console.ReadLine();

    var httpClient = new HttpClient();

    ConsoleColor defaultBackground = Console.BackgroundColor;
    ConsoleColor defaultForeground = Console.ForegroundColor;

    while (true)
    {
        var stopwatch = Stopwatch.StartNew();
        var now = DateTime.Now;
        HttpResponseMessage response = await httpClient.GetAsync(url);
        stopwatch.Stop();

        var format = "[{0:HH:mm:ss.fffff}] Elapsed: {1:0.000}s, Status: {2}";
        double elapsed = stopwatch.ElapsedMilliseconds * 0.001;
        if (elapsed > 1.0)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Beep();
        }
        Console.WriteLine(format, now, elapsed, response.StatusCode);

        Console.BackgroundColor = defaultBackground;
        Console.ForegroundColor = defaultForeground;

        await Task.Delay(1000);
    }
}

Main().Wait();
