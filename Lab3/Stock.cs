// Jason Panella
// John Bui
// CECS 475
// September 9, 2020
// Lab 3

using System;
using System.Threading;

namespace Lab3
{
    public class Stock
    {
        private readonly Thread _thread;

        public event EventHandler<StockNotification> StockEvent;

        public string StockName { get; set; }
        public int InitialValue { get; set; }
        public int MaxChange { get; set; }
        public int Threshold { get; set; }
        public int CurrentValue { get; set; }
        public int NumChanges { get; set; }


        public Stock(string name, int startingValue, int maxChange, int threshold)
        {
            StockName = name;
            InitialValue = startingValue;
            CurrentValue = InitialValue;
            MaxChange = maxChange;
            Threshold = threshold;

            _thread = new Thread(new ThreadStart(Activate));
            _thread.Start();
        }


        public void Activate()
        {

            for (int i = 0; i < 25; i++)
            {
                Thread.Sleep(500); //1/2 second
                ChangeStockValue();
            }
        }


        public void ChangeStockValue()
        {
            System.Random random = new System.Random();
            CurrentValue += random.Next(1,MaxChange - 1);
            NumChanges++;

            int valueDifference = CurrentValue - InitialValue;
            if(valueDifference > Threshold)

            {
                StockNotification cArgs = new StockNotification(StockName, CurrentValue, NumChanges);
                StockEvent?.Invoke(this, cArgs);

            }
        }

    }
}
