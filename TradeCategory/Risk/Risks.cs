using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.Trades;

namespace TradeCategory.Risk
{
    class Risks : IRisk
    {
        public string Type { get; set; } = "None";

        public string EvaluateExpiredRisk(ITrade trade)
        {
            if (trade.NextPaymentDate > trade.ReferenceDate)
            {
                this.Type = "Expired";
                return this.Type;
            }
            else
            {
                return this.Type;
            }
        }

        public string EvaluateHighRisk(ITrade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector == "PRIVATE")
            {
                this.Type = "High Risk";
                return this.Type;
            }
            else
            {
                return this.Type;
            }
        }

        public string EvaluateMediumRisk(ITrade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector == "PUBLIC")
            {
                this.Type = "Medium Risk";
                return this.Type;
            }
            else
            {
                return this.Type;
            }
        }
        //public string EvaluatePEPRisk(ITrade trade)
        //{
        //    if (trade.PEP)
        //    {
        //        this.Type = "PEP";
        //        return this.Type;
        //    }
        //    else
        //    {
        //        return this.Type;
        //    }
        //}
    }
}
