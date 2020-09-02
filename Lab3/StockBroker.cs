// Jason Panella
// John Bui
// CECS 475
// September 9, 2020
// Lab 3

using System;
using System.Collections.Generic;

namespace Lab3
{
    public class StockBroker
    {
        public string BrokerName { get; set; }
        public List<Stock> StockLists = new List<Stock>();

        public StockBroker(string name)
        {
            BrokerName = name;
        }

        public void AddStock(Stock stock)
        {
            StockLists.Add(stock);

            //stock.stockEvent += EventHandler(___, ____, ___)
        }

        /* EventHandler(______________________________)
        *  Display broker name, stock name, current stock value, and number of changes)
        *  Note: name.PadRight(10) to align the column.
        */
    }
}
