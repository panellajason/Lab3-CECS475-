// Jason Panella
// John Bui
// CECS 475
// September 9, 2020
// Lab 3

using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab3
{
    public class StockBroker
    {
        public string BrokerName { get; set; }
        public List<Stock> StockLists = new List<Stock>();

        public static ReaderWriterLockSlim myLock = new ReaderWriterLockSlim();
        readonly string docPath = @"C:\Lab3_output.txt";

        public string titles = "Broker".PadRight(10) + "Stock".PadRight(15) +
            "Value".PadRight(10) + "Changes".PadRight(10) + "Date and Time";

        public StockBroker(string name)
        {
            BrokerName = name;
        }

        public void AddStock(Stock stock)
        {
            StockLists.Add(stock);

            //This line doesn't trigger the EventHandler? 
            stock.StockEvent += EventHandler;
        }

        /* EventHandler(______________________________)
        *  Display broker name, stock name, current stock value, and number of changes)
        *  Note: name.PadRight(10) to align the column.
        */
        void EventHandler(Object sender, StockNotification e)
        {
           
                //Stock newStock = (Stock)sender;
                Console.WriteLine(this.BrokerName + e.StockName + e.CurrentValue + e.NumChanges);
            
        }
    }
}
