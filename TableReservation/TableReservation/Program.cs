using System.Diagnostics;
using TableReservation.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;
var rest = new Restaurant();
while (true)
{
    Console.WriteLine("привет. Желаете забронировать столик?\n" +
        "1 - уведомим по смс\n" +
        "2 - по линии");
    if (!int.TryParse(Console.ReadLine(), out var choice) && choice is not (1 or 2))
    {
        Console.WriteLine("Введите 1 или 2");
        continue;
    }

    Console.WriteLine("На сколько человек нужен столик?");
    if (!int.TryParse(Console.ReadLine(), out var countOfPersons))
    {
        Console.WriteLine("Введите количество гостей");
        continue;
    }
    
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    if (choice == 1)
    {
        rest.BookFreeTableAsync(countOfPersons);
    }
    else
    {
        rest.BookFreeTable(countOfPersons);
    }
    Console.WriteLine("Спасибо за обращение");
    stopWatch.Stop();
    var ts = stopWatch.Elapsed;
    Console.WriteLine($"{ts.Seconds}:{ts.Milliseconds}");
}
