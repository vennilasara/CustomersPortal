﻿using System.ComponentModel.DataAnnotations;

namespace CustomersPortal.DataContracts_DTO
{
    public class CreateCustomerDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
