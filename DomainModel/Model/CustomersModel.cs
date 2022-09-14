﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Model
{
    public class CustomersModel : BaseModel
    {
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
    }
}
