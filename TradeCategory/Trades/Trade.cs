using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.Risk;

namespace TradeCategory.Trades
{
    class Trade : ITrade
    {
        public double Value { get; set; } 
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public DateTime ReferenceDate { get; set; }
        //public bool PEP { get; set; }
        public string TradeInfo;
        public int TradeNumber;

        public Trade( int TradeNumber, double Value, string ClientSector, DateTime NextPaymentDate, DateTime refDate)//, bool PEP)
        {
            this.Value = Value;
            this.ClientSector = ClientSector;
            this.NextPaymentDate = NextPaymentDate;
            this.ReferenceDate = refDate;
            this.TradeNumber = TradeNumber;
            //this.PEP = PEP;

            TradeInfo = "Trade " + TradeNumber + " - Value: " + Value + ", Client Sector: " + ClientSector + ", Next Payment Date: " + NextPaymentDate.ToString("MM/dd/yyyy");//+", PEP: "+PEP;  
        }
        public override string ToString()
        {
            return TradeInfo;
        }       
    }
}
