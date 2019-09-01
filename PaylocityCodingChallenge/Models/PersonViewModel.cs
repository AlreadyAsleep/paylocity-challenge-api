using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaylocityCodingChallenge.Models
{
    public abstract class PersonViewModel
    {
        private const int _maxNameLength = 50;
        private const string _errorMessage = "The model provided has invalid data";

        [Required]
        [MaxLength(_maxNameLength, ErrorMessage = _errorMessage)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(_maxNameLength, ErrorMessage = _errorMessage)]
        public string LastName { get; set; }
        [Range(0.0, double.MaxValue, ErrorMessage = _errorMessage)]
        public decimal AnnualCost { get; set; }
        [Range(0.0, double.MaxValue, ErrorMessage =_errorMessage)]
        public decimal Discount { get; set; }
    }
}