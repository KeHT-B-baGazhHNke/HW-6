using System;
using System.Collections.Generic;
using System.IO;

namespace HW_6
{
    internal abstract class Tour
    {
        public string destination;
        public string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }

        public bool guide;
        public bool Guide
        {
            get
            {
                return guide;
            }
            set
            {
                guide = value;
            }
        }

        public double tour_price;
        public double TourPrice
        {
            get
            {
                return tour_price;
            }
            set
            {
                tour_price = value;
            }
        }

        public Tour(string destination, bool guide, double tour_price)
        {
            this.destination = destination;
            this.guide = guide;
            this.tour_price = tour_price;
        }

        public abstract void Print();
        public abstract void Start();
        public abstract void End();
        public abstract double CalculatePrice();
    }

    internal class WalkTour : Tour
    {
        public int tents;
        public int Tents
        {
            get
            {
                return tents;
            }
            set
            {
                tents = value;
            }
        }

        public WalkTour(string destination, bool guide, double tour_price, int tents)
            : base(destination, guide, tour_price)
        {
            this.tents = tents;
        }

        public override void Print()
        {
            Console.WriteLine($"Пункт назначения {destination}, наличие гида {guide}, кол - во палаток {tents}\n");
        }

        public override void Start()
        {

            Console.WriteLine($"Начали свой путь в {destination}, кол - во палаток {tents}\n");
        }

        public override void End()
        {
            Console.WriteLine($"Закончили свой путь в {destination}, кол - во палаток {tents}\n");
        }

        public override double CalculatePrice()
        {
            Console.Write("Сколько часов вы добирались до места назначения?: ");
            bool prs = Int32.TryParse(Console.ReadLine(), out int hours);
            if (!prs)
            {
                do
                {
                    Console.WriteLine("Вы не ввели число");
                    prs = Int32.TryParse(Console.ReadLine(), out hours);
                } while (!prs);
            }
            return hours * tour_price;
        }
    }

    internal class TransportTour : Tour
    {
        public string transport;
        public string Transport
        {
            get
            {
                return transport;
            }
            set
            {
                transport = value;
            }
        }

        public TransportTour(string destination, bool guide, double tour_price, string transport)
            : base(destination, guide, tour_price)
        {
            this.transport = transport;
        }

        public override void Print()
        {
            Console.WriteLine($"Место назначения {destination}, наличие гида {guide}, вид транспорта {transport}\n");
        }

        public override void Start()
        {

            Console.WriteLine($"Начали свой путь в {destination}, вид транспорта {transport}\n");
        }

        public override void End()
        {
            Console.WriteLine($"Закончили свой путь в {destination}, вид транспорта {transport}\n");
        }

        public override double CalculatePrice()
        {
            Console.Write("Сколько часов вы добирались до места назначения: ");
            bool prs = Int32.TryParse(Console.ReadLine(), out int hours);
            if (!prs)
            {
                do
                {
                    Console.WriteLine("Вы не ввели число\n");
                    prs = Int32.TryParse(Console.ReadLine(), out hours);
                } while (!prs);
            }
            return hours * tour_price;
        }


    }

    internal class TourInfo
    {
        public List<Tour> tours;

        public TourInfo()
        {
            tours = new List<Tour>();
        }

        public void AddTour(Tour tour)
        {
            tours.Add(tour);
        }

        public void ShowTour(int num)
        {
            tours[num].Print();
        }

        public Tour GetTour(int num)
        {
            return tours[num];
        }

        public void PrintAllTours()
        {
            Console.WriteLine("Доступные туры:\n");
            foreach (Tour tour in tours)
            {
                tour.Print();
            }
        }

        public int GetTourCount()
        {
            return tours.Count;
        }

    }

    internal class Program
    {
        static void Main(string[] link)
        {
            Console.WriteLine("");

            TourInfo shop = new TourInfo();

            string destination = "Amsterdam";
            bool guide = false;
            double tour_price = 500;
            int tents = 2;
            shop.AddTour(new WalkTour(destination, guide, tour_price, tents));

            string destination1 = "Armenia";
            bool guide1 = true;
            double tour_price1 = 1000000;
            int tents1 = 0;
            shop.AddTour(new WalkTour(destination1, guide1, tour_price1, tents1));

            string destination2 = "Sacramento";
            bool guide2 = false;
            double tour_price2 = 2349830;
            string transport2 = "Bus";
            shop.AddTour(new TransportTour(destination2, guide2, tour_price2, transport2));

            string destination3 = "Los-Santos";
            bool guide3 = true;
            double tour_price3 = 12093481512;
            string transport3 = "Helicopter";
            shop.AddTour(new TransportTour(destination3, guide3, tour_price3, transport3));

            shop.PrintAllTours();
            Console.WriteLine("Выберите тур - введите порядковый номер тура\n");
            bool choise_prs = Int32.TryParse(Console.ReadLine(), out int choise_num);
            if (!choise_prs || (choise_num < 1 || choise_num > shop.GetTourCount()))
            {
                do
                {
                    Console.WriteLine("Нет такого номера, повторите попытку\n");
                    choise_prs = Int32.TryParse(Console.ReadLine(), out choise_num);

                } while (!choise_prs || (choise_num < 1 || choise_num > shop.GetTourCount()));
            }
            switch (choise_num)
            {
                case 1:
                    shop.ShowTour(0);
                    Tour tour1 = shop.GetTour(0);
                    double price1 = tour1.CalculatePrice();
                    Console.WriteLine($"Вы должны заплатить {price1} рублей");
                    break;
                case 2:
                    shop.ShowTour(1);
                    Tour tour2 = shop.GetTour(1);
                    double price2 = tour2.CalculatePrice();
                    Console.WriteLine($"Вы должны заплатить {price2} рублей");
                    break;
                case 3:
                    shop.ShowTour(2);
                    Tour tour3 = shop.GetTour(2);
                    double price3 = tour3.CalculatePrice();
                    Console.WriteLine($"Вы должны заплатить {price3} рублей");
                    break;
                case 4:
                    shop.ShowTour(3);
                    Tour tour4 = shop.GetTour(3);
                    double price4 = tour4.CalculatePrice();
                    Console.WriteLine($"Вы должны заплатить {price4} рублей");
                    break;
                default:
                    Console.WriteLine("Такого номера нет");
                    break;
            }
            Console.ReadKey();
            Console.Write("Нажмите любую клавишу для продолжения...");
        }
    }
}
