using System;

namespace TLab_7
{
    enum BankType
    {
        Текущий,
        Сберегательный,
    }
    internal class BankAccount
    {
        private static uint unique_id = 1;
        private uint id;
        private double balance;
        private BankType type;

        public BankAccount(BankType type)
        {
            id = unique_id;
            unique_id++;
            balance = 0.0;
            this.type = type;
        }

        public void deposit_money(double money)
        {
            if (money > 0)
            {
                balance += money;
                Console.WriteLine($"\nСчёт пополнен на {money} р.\nТекущий баланс: {balance}");
            }
            else
            {
                Console.WriteLine("\nЗначение должно быть положительным");
            }
        }

        public void withdraw_money(double money)
        {
            if (money <= balance)
            {
                balance -= money;
                Console.WriteLine($"\nСо счёта снято {money} р.\nТекущий баланс: {balance}");
            }
            else
            {
                Console.WriteLine("\nНа вашем счёте недостаточно средств");
            }
        }

        public void Print()
        {
            Console.WriteLine($"\nНомер вашего счёта: {id}\nБаланс: {balance}\nТип счета: {type}");
        }
    }

    internal class Building
    {
        private static uint unique_id = 1;
        private uint id;
        private double height;
        private int levels;
        private int flats;
        private int entrances;

        public Building()
        {
            id = unique_id;
            unique_id++;
            height = 30;
            levels = 9;
            entrances = 6;
            flats = 162;
        }

        public void height_of_level(int level)
        {
            double level_height = (height / levels) * level;
            Console.WriteLine($"\nВысота {level} этажа {level_height} м.");
        }

        public void flats_in_entrance()
        {
            double room_in_enterance = flats / entrances;
            Console.WriteLine($"\nВ одном подьезде {room_in_enterance} квартир");
        }

        public void flats_on_floor()
        {
            double Flats_on_floor = (flats / entrances) / levels;
            Console.WriteLine($"\nНа одном этаже {Flats_on_floor} квартир");
        }

        public void Print()
        {
            Console.WriteLine($"\nНомер дома: {id}\nВысота: {height} м.\nКол-во этажей: {levels}\nКол-во подьездов: {entrances}\nКол-во квартир: {flats}");
        }
    }

        internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнения 7.1 - 7.3");
            BankAccount account = new BankAccount(BankType.Сберегательный);
            account.deposit_money(123);
            account.withdraw_money(23);
            account.Print();
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();

            Console.WriteLine("\nДомашнее задание 7.1");
            Building building = new Building();
            building.Print();
            building.height_of_level(3);
            building.flats_in_entrance();
            building.flats_on_floor();
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
