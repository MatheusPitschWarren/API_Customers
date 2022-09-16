﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCustomers.Model
{
    public class CustomersModel : BaseModel
    {
        public CustomersModel(
            string fullName,
            string email,
            string emailConfirmation,
            string cpf,
            string cellphone,
            DateTime dateOfBirth,
            bool emailSms,
            bool whatsapp,
            string country,
            string city,
            string postalCode,
            string address,
            int number
            )
        {
            FullName = fullName;
            Email = email;
            EmailConfirmation = emailConfirmation;
            Cpf = CpfCorrect(cpf);
            Cellphone = cellphone;
            DateOfBirth = dateOfBirth;
            EmailSms = emailSms;
            Whatsapp = whatsapp;
            Country = country;
            City = city;
            PostalCode = postalCode;
            Address = address;
            Number = number;
        }
        public string FullName { get; set; }

        public string Email { get; set; }

        public string EmailConfirmation { get; set; }

        public string Cpf { get; set; }

        public string Cellphone { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool EmailSms { get; set; }

        public bool Whatsapp { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Address { get; set; }

        public int Number { get; set; }

        private string CpfCorrect(string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace("-", "");
        }
    }
}
