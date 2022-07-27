using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.Trades;

namespace TradeCategory.Risk
{
    interface IRisk
    {
        string Type { get; }
        string EvaluateExpiredRisk(ITrade trade);
        string EvaluateHighRisk(ITrade trade);
        string EvaluateMediumRisk(ITrade trade);
        //string EvaluatePEPRisk(ITrade trade);
    }
}
