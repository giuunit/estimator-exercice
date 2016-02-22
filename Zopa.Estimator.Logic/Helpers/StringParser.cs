using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zopa.Estimator.Logic.Models;
using Zopa.Estimator.Logic.Properties;

namespace Zopa.Estimator.Logic.Helpers
{
    public static class StringParser
    {
        public static MarketDataItem ToMarketDataItem(string line)
        {
            var elements = line.Split(',');

            //we expect 3 arguments
            if (elements.Length != 3)
            {
                return null;
            }

            float rate;
            int available;

            var name = elements[0];
            var rateString = elements[1];
            var availableString = elements[2];

            //name expected
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            //we expect a float
            if (!float.TryParse(rateString, 
                System.Globalization.NumberStyles.Number |
                System.Globalization.NumberStyles.AllowDecimalPoint,
                System.Globalization.CultureInfo.CreateSpecificCulture("en-GB"),
                out rate))
            {
                return null;
            }

            //we expect an integer
            if (!int.TryParse(availableString, out available))
            {
                return null;
            }

            //no errors, we can send the object
            return new MarketDataItem()
            {
                Available = available,
                Name = name,
                Rate = rate
            };
        }

        public static ParsingResult<MarketData> ToMarketData(string content)
        {
            ParsingResult<MarketData> toReturn = new ParsingResult<MarketData>();
            toReturn.Result = new MarketData();

            // From textReaderText, create a continuous paragraph 
            // with two spaces between each sentence.
            // https://msdn.microsoft.com/en-us/library/system.io.stringreader.readline(v=vs.110).aspx

            string line;
            StringReader strReader = new StringReader(content);
            var lineIndex = 0;

            while (true)
            {
                line = strReader.ReadLine();
                if (line != null)
                {
                    var item = ToMarketDataItem(line);

                    if (item != null)
                        toReturn.Result.Add(item);

                    else
                        toReturn.Warnings.Add(string.Format(Resources.WarningMarketDataItemFormat, lineIndex));
                }

                else
                {
                    break;
                }

                lineIndex++;
            }

            return toReturn;
        }
    }
}
