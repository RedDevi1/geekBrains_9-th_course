using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableReservation.Models
{
    public class Restaurant
    {
        private readonly List<Table> _tables = new();

        public Restaurant()
        {
            for (var i = 1; i <=10; i++)
            {
                _tables.Add(new Table(i));
            }
        }

        public void BookFreeTable(int countOfPersons)
        {
            Console.WriteLine("Добрый день! Подождите я подберу столик и подтвержу бронь, повисите");
            var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons && t.State == State.Free);
            Thread.Sleep(1000 * 5);
            table?.SetState(State.Booked);

            Console.WriteLine(table is null
                ? $"К сожалению, все занято"
                : $"Готово! Ваш столик номер {table.Id}");
        }

        public void BookFreeTableAsync(int countOfPersons)
        {
            Console.WriteLine("Добрый день! Подождите я подберу столик и подтвержу бронь, ждите уведомления");
            Task.Run(async () =>
            {
                var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons && t.State == State.Free);
                await Task.Delay(1000 * 5);
                table?.SetState(State.Booked);

                Console.WriteLine(table is null
                    ? $"Уведомление. К сожалению, все занято"
                    : $"Уведомление. Готово! Ваш столик номер {table.Id}");
            });
        }

        public void TableBookingCancellation(int tableId)
        {
            var table = _tables.FirstOrDefault(t => t.Id == tableId);
            Thread.Sleep(1000 * 5);

            if (table is not null)
            {
                table?.SetState(State.Free);
                Console.WriteLine($"Готово! Ваша бронь столика номер {tableId} отменена");
            }
            else
            {
                Console.WriteLine($"К сожалению, столик с номером {tableId} не найден");
            }
        }

        public void TableBookingCancellationAsync(int tableId)
        {           
            Task.Run(async () =>
            {
                var table = _tables.FirstOrDefault(t => t.Id == tableId);
                await Task.Delay(1000 * 5);
                if (table is not null)
                {
                    table?.SetState(State.Free);
                    Console.WriteLine($"Готово! Ваша бронь столика номер {tableId} отменена");
                }
                else
                {
                    Console.WriteLine($"К сожалению, столик с номером {tableId} не найден");
                }
            });
        }
    }
}
