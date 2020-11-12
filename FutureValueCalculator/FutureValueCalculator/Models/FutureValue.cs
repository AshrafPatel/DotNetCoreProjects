using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutureValueCalculator.Models
{
    public class FutureValue
    {
        [Required(ErrorMessage = "Please enter monthly investment")]
        [Range(1, 500, ErrorMessage ="Monthly Investment must be between 1 and 500")]
        public decimal? MonthlyInvestment { get; set; }

        [Required(ErrorMessage = "Please enter yearly interest rate")]
        [Range(0.1, 10.0, ErrorMessage ="Yearly Interest Rate must be between 0.1 and 10.0")]
        public decimal? YearlyInterestRate { get; set; }

        [Required(ErrorMessage = "Please enter number of years")]
        [Range(1, 50, ErrorMessage ="Number Of Years mmust be between 1 and 50")]
        public int? NumberOfYears { get; set; }

        public decimal? CalculateValue()
        {
            int? months = NumberOfYears * 12;
            decimal? monthlyRate = (YearlyInterestRate / 12) / 100;
            decimal? futureValue = 0;

            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + MonthlyInvestment) * (1 + monthlyRate);
            }

            return futureValue;
        }
    }
}
