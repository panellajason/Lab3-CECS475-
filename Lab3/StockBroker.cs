// Jason Panella
// John Bui
// CECS 475
// September 9, 2020
// Lab 3

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace Lab3
{
    public class StockBroker
    {
        public string BrokerName { get; set; }

        public List<Stock> StockLists = new List<Stock>();
        public static ReaderWriterLockSlim myLock = new ReaderWriterLockSlim();
        readonly string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string titles = "Broker".PadRight(10) + "Stock".PadRight(12) + "Value".PadRight(7) + "Changes";


        public StockBroker(string name)
        {
            BrokerName = name;
        }

        public void AddStock(Stock stock)
        {
            StockLists.Add(stock);
            stock.StockEvent += EventHandler;
        }

        /* EventHandler method
        *  Display broker name, stock name, current stock value, and number of changes)
        *  Note: name.PadRight(10) to align the column.
        */
        void EventHandler(Object sender, StockNotification e)
        {
            myLock.EnterWriteLock();
            Stock nStock = (Stock)sender;
            string output = BrokerName.PadRight(10) + nStock.StockName.PadRight(12) + nStock.CurrentValue.ToString().PadRight(7) + nStock.NumChanges;

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "output.txt"), true))
            {
                if (GlobalHelper.writeTitle)
                {
                    GlobalHelper.writeTitle = false;
                    Console.WriteLine(titles);
                    outputFile.WriteLine(titles);
                }
                outputFile.WriteLine(output);
            }
            Console.WriteLine(output);
            myLock.ExitWriteLock();
        }

    }


    /* GlobalHelper class
        *  This class acts as a way to declare global variables in C#
        *  so that every instance of the class can access one variable
        */
    public static class GlobalHelper
    {
        public static Boolean writeTitle = true;
    }
}
