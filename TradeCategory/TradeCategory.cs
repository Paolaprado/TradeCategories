using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.Trades;
using TradeCategory.Risk;
using TradeCategory.Validation;

namespace TradeCategory
{
    class TradeCategory
    {
        static void Main(string[] args)
        {

            List<ITrade> trades = new List<ITrade> { };
            List<string> tradesEvaluated;

            double Value;
            string ClientSector, tryValidation = "";
            DateTime NextPaymentDate, refDate;
            int tradeQuantity;
            bool intChecker = false, dateChecker = false, tradeChecker = false;//, pep;
       
            while (!dateChecker)
            {
                Console.WriteLine("\nEnter the reference Date (in the format MM/dd/yyyy):");
                tryValidation = Console.ReadLine();
                dateChecker = new Validations().CheckDate(tryValidation);
            }           
            refDate = DateTime.ParseExact(tryValidation, "MM/dd/yyyy", null);            

            while (!intChecker)
            {
                Console.WriteLine("Enter the number of trades (Integer):\n");
                tryValidation = Console.ReadLine();
                intChecker = new Validations().CheckInt(tryValidation);                
            }
            tradeQuantity = Convert.ToInt16(tryValidation);
            
            while (!tradeChecker)
            {
                Console.WriteLine("Enter the trades information separated by a space: value (double), client sector(Public or Private) and date (in the format MM/dd/yyyy) "); // "and PEP(TRUE or FALSE)");
                for (int i = 1; i <= tradeQuantity; i++)
                {
                    tryValidation = Console.ReadLine();
                    tradeChecker = new Validations().CheckTrade(tryValidation);
                    if(tradeChecker)
                    {
                        string[] inputs = tryValidation.Split(' ');
                        Value = double.Parse(inputs[0]);
                        ClientSector = inputs[1].ToUpper();
                        NextPaymentDate = DateTime.ParseExact(inputs[2], "MM/dd/yyyy", null);
                        //pep = bool.Parse(inputs[3]);

                        Trade trade = new Trade(i, Value, ClientSector, NextPaymentDate, refDate);//, pep);
                        trades.Add(trade);
                    }
                    else
                    {                   
                        Console.WriteLine("\nPlease review the information provide for trade number " + i);
                        i--;
                    }                    
                }
            }

            tradesEvaluated = new RiskAssessment(trades).TradesRisks();
            Console.WriteLine("\nRisk Assessment: \n");
            foreach ( Trade t in trades )
            {
                Console.WriteLine(t.TradeInfo + " --> Risk Category: "+ tradesEvaluated[t.TradeNumber-1]);                
            }            
            Console.WriteLine("\nPress enter to close or R to restart\n");
            if(Console.ReadLine().ToUpper()=="R")
            {
                Main(args);
            }
            
        }
    }
}
