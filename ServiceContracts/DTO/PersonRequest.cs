using Entities;
using Microsoft.AspNetCore.Http;
using ServiceContracts.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class PersonRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can not be blank")]
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Address can not be blank")]
        public string? Address { get; set; }
        public string? City { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        [Website]
        public string? Website { get; set; }
        [Required(ErrorMessage = "Job Title can not be blank")]
        public string? JobTitle { get; set; }
        public IFormFile? Logo { get; set; }
        public string? LogoPath { get; set; }

        public Person ToPerson()
        {
            return new Person() { Id = Id, Name = Name, Email = Email, Address = Address, City = City, PhoneNumber = PhoneNumber, Website = Website, JobTitle = JobTitle, LogoPath = LogoPath };
        }
    }
}
