using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vejrudsigten.Services
{
    public class WeatherMessageCreator
    {
        public string GetWeatherMessage(string todayInfoConditions, double todayInfoTemperature, string yesterdayInfoConditions, double yesterdayInfoTemperature)
        {
            /// Klart vejr
            /// Regn
            /// Sne
            /// Skyet
            /// Andet
            var resultTemp = "";
            if (todayInfoConditions == yesterdayInfoConditions)
            {
                resultTemp = String.Format("Det bliver igen {0}", todayInfoConditions);
            }
            else
            {
                resultTemp = String.Format("Vejret skifter fra {0} til {1}", yesterdayInfoConditions, todayInfoConditions);
            }

            if (todayInfoTemperature > yesterdayInfoTemperature)
            {
                resultTemp = String.Format("{0} med en stigning i temperatur fra {1} grader til {2} grader", resultTemp, yesterdayInfoTemperature, todayInfoTemperature);
            }
            else if (todayInfoTemperature < yesterdayInfoTemperature)
            {
                resultTemp = String.Format("{0} med en fald i temperatur fra {1} grader til {2} grader", resultTemp, yesterdayInfoTemperature, todayInfoTemperature);
            }
            else
            {
                resultTemp = String.Format("{0} med samme temperatur som i går på {1} grader", resultTemp, todayInfoTemperature);
            }

            if (todayInfoTemperature >= 40)
            {
                return "Det er alt for varmt";
            }
            else if (todayInfoTemperature <= -20)
            {
                return "Det er alt for koldt";
            }

            return resultTemp;
        }
    }
}
