using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCategory.Validation
{
    class Validations
    {
        public enum ClientSector { PRIVATE, PUBLIC }
        bool formatChecker = false, pepChecked;
        int numberChecked;
        double doubleChecked;
        DateTime dateChecked;

        public bool CheckInt(string number)
        {
            formatChecker = int.TryParse(number, out numberChecked); 

            if (!formatChecker || numberChecked==0)
            {            
                Console.WriteLine("\nThe input expected is an Integer > 0, please try again.");
            }
            return formatChecker;
        }
        public bool CheckDate(string date)
        {
            formatChecker = DateTime.TryParseExact(date, "MM/dd/yyyy", null,DateTimeStyles.None, out dateChecked); 
            
            if (!formatChecker)
            {
                Console.WriteLine("\nThe input expected is a Date in the format MM/dd/yyyy, please try again.");
            }
            return formatChecker;
        }

        public bool CheckDouble(string number)
        {
            formatChecker = double.TryParse(number, out doubleChecked); 

            if (!formatChecker || doubleChecked == 0)
            {
                Console.WriteLine("\nThe input expected for a Trade Value is a Double > 0, please try again.");
            }
            return formatChecker;
        }

        public bool CheckClientSector(string sector)
        {
            formatChecker = Enum.IsDefined( typeof(ClientSector), sector.ToUpperInvariant()); 

            if (!formatChecker)
            {
                Console.WriteLine("\nThe input expected for a Trade Client Sector is Private or Public, please try again.");
            }
            return formatChecker;
        }

        public bool CheckTrade(string trade)
        {
            string[] inputs = trade.Split(' ');
            if(inputs.Count() ==3)//4)
            {
                bool doubleChecker = new Validations().CheckDouble(inputs[0]);
                bool sectorChecker = new Validations().CheckClientSector(inputs[1]);
                bool dateChecker = new Validations().CheckDate(inputs[2]);
                //bool pepChecker = new Validations().CheckPEP(inputs[3]);
                
                if(doubleChecker && sectorChecker && dateChecker)
                {
                    formatChecker = true;
                }
                else
                {
                    formatChecker = false;
                }                
            }
            else
            {
                Console.WriteLine("\nThe input expected for trades information should be separated by a space. \nExample: \n 1230415,80 PRIVATE 02/02/2020\nPlease try again."); // true \nPlease try again."); 
            }            
            return formatChecker;
        }
        public bool CheckPEP(string pep)
        {
            formatChecker = bool.TryParse(pep, out pepChecked);

            if (!formatChecker)
            {
                Console.WriteLine("\nThe input expected for PEP is boolean, please try again.");
            }
            return formatChecker;
        }
    }
}