using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zopa.Estimator.Logic.Helpers;
using Zopa.Estimator.Logic.Properties;

namespace Zopa.Estimator.UI
{
    class Program
    {
        const int NB_MONTHS_REFUND = 36;

        static void Main(string[] args)
        {
            switch (args.Length)
            {
                //no arguments
                case 0:
                    Console.WriteLine(Resources.ArgumentsErrorMessage);
                    break;

                //one argument: help or error
                case 1:

                    if (args[0].ToLowerInvariant() == "help")
                    {
                        Console.Write(Resources.HelpMessage);
                    }
                    else
                    {
                        Console.WriteLine(Resources.ArgumentsErrorMessage);
                    }

                    break;

                //2 arguments, test if format is ok
                case 2:

                    var csvFile = args[0];
                    var loanString = args[1];
                    int loan;

                    //test if loan is correct
                    if (!int.TryParse(loanString, out loan))
                    {
                        Console.WriteLine(Resources.ErrorLoanNotFloatMessage, loanString);
                    }

                    //loan rules
                    if (loan < 1000 || loan > 15000 || loan % 100 != 0)
                    {
                        Console.WriteLine(Resources.ErrorLoanNotCorrectMessage);
                        return;
                    }

                    //test if path is correct
                    if (!File.Exists(csvFile))
                    {
                        Console.WriteLine(Resources.ErrorFileNotFoundMessage, csvFile);
                    }
                    else
                    {
                        var marketDataString = File.ReadAllText(csvFile);
                        var marketDataRequest = StringParser.ToMarketData(marketDataString);

                        if (!marketDataRequest.Result.Items.Any())
                        {
                            Console.WriteLine(Resources.ErrorWrongData);
                            return;
                        }

                        if (marketDataRequest.Warnings.Any())
                        {
                            foreach (var message in marketDataRequest.Warnings)
                            {
                                Console.WriteLine(message);
                            }
                        }

                        var bestRateItem = EstimatorHelper.GetBestRate(marketDataRequest.Result, loan);

                        //noone has enough money
                        if (bestRateItem == null)
                        {
                            Console.WriteLine(Resources.NoOfferMessage);
                        }
                        else
                        {
                            var totalPayment = MathHelper.GetTotalRepayment(loan, bestRateItem.Rate, NB_MONTHS_REFUND);
                            var monthlyPayment = totalPayment / NB_MONTHS_REFUND;

                            Console.WriteLine(Resources.RequestedAmountMessage, loan);
                            Console.WriteLine(Resources.RateMessage, Math.Round(bestRateItem.Rate*100,1));
                            Console.WriteLine(Resources.MonthlyRepaymentMessage, Math.Round(monthlyPayment,2));
                            Console.WriteLine(Resources.TotalRepaymentMessage, Math.Round(totalPayment, 2));
                        }
                    }

                    break;

                //more than 2 arguments = error
                default:
                    Console.WriteLine(Resources.ArgumentsErrorMessage);
                    break;
            }
        }
    }
}
