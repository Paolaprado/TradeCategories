using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.Trades;
using TradeCategory.Risk;
using System.Reflection;

namespace TradeCategory.Risk
{
    public enum TypeRisk { Expired, HighRisk, MediumRisk, None}
    
    class RiskAssessment
    {
        private List<ITrade> trades;
         

        public RiskAssessment(List<ITrade> trades)
        {
            this.trades = trades;
        }

        public List<string> TradesRisks()
        {
            string riskEvaluated = null;

            List<string> tradesEvaluated = new List<string>();

            foreach (Trade trade in trades)
            {
                
                if(new Risks().EvaluateExpiredRisk(trade) != "None")
                {
                    riskEvaluated = new Risks().EvaluateExpiredRisk(trade);
                }
                else if (new Risks().EvaluateHighRisk(trade) != "None")
                {
                    riskEvaluated = new Risks().EvaluateHighRisk(trade);
                }
                else if (new Risks().EvaluateMediumRisk(trade) != "None")
                {
                    riskEvaluated = new Risks().EvaluateMediumRisk(trade);
                }
                //else if (new Risks().EvaluatePEPRisk(trade) != "None")
                //{
                //    riskEvaluated = new Risks().EvaluatePEPRisk(trade);
                //}
                else
                {
                    riskEvaluated = "None";
                }

                tradesEvaluated.Add(riskEvaluated);

            }
            return tradesEvaluated;
        }
    }
}
