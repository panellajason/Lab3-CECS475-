using System;

namespace Lab3
{
    public class StockNotification : EventArgs
    {
        public string StockName { get; set; }
        public int CurrentValue { get; set; }
        public int NumChanges { get; set; }

        public StockNotification(String stockName, int currentValue, int numChanges)
        {
            StockName = stockName;
            CurrentValue = currentValue;
            NumChanges = numChanges;
        }
    }
}
