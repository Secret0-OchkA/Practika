using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Owned]
    public class Insurance : IValidatableObject
    {
        protected Insurance() { }
        public Insurance(string name, string address, string inn, string paymentAccount, string bik)
        {
            Name = name;
            Address = address;
            Inn = inn;
            PaymentAccount = paymentAccount;
            Bik = bik;
        }

        [Required, DisplayFormat(ConvertEmptyStringToNull = true )]
        public string Name { get; set; }
        [Required, DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Address { get; set; }
        [Required, DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Inn { get; set; }
        [Required, DisplayFormat(ConvertEmptyStringToNull = true)]
        public string PaymentAccount { get; set; }
        [Required, DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Bik { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            Validator.ValidateProperty(Name, new ValidationContext(this) { MemberName = nameof(Name)});
            Validator.ValidateProperty(Address, new ValidationContext(this) { MemberName = nameof(Address) });
            Validator.ValidateProperty(Inn, new ValidationContext(this) { MemberName = nameof(Inn) });
            Validator.ValidateProperty(PaymentAccount, new ValidationContext(this) { MemberName = nameof(Inn) });
            Validator.ValidateProperty(Bik, new ValidationContext(this) { MemberName = nameof(Bik) });

            return results;
        }
    }
    [Owned]
    public class Identity : IValidatableObject
    {
        protected Identity() { }
        public Identity(string name, string login, string password, string ip)
        {
            Name = name;
            this.login = login;
            this.password = password;
            Ip = ip;
        }

        [Required, DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Name { get; set; }
        [Required,EmailAddress]
        public string login { get; set; }
        [Required, DisplayFormat(ConvertEmptyStringToNull = true)]
        public string password { get; set; }
        [Required, DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Ip { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            Validator.ValidateProperty(Name, new ValidationContext(this) { MemberName = nameof(Name) });
            Validator.ValidateProperty(login, new ValidationContext(this) { MemberName = nameof(login) });
            Validator.ValidateProperty(password, new ValidationContext(this) { MemberName = nameof(password) });
            Validator.ValidateProperty(Ip, new ValidationContext(this) { MemberName = nameof(Ip) });

            return results;
        }
    }


    public class Blood : IValidatableObject
    {
        protected Blood() { }
        public Blood(Patient patient, int barcode, DateTime date)
        {
            Patient = patient;
            this.barcode = barcode;
            this.date = date;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public Patient Patient { get; set; }
        [Required]
        public int barcode { get; set; }
        [Required]
        public DateTime date { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            Validator.ValidateProperty(Id, new ValidationContext(this) { DisplayName = nameof(Id) });
            Validator.ValidateProperty(Patient, new ValidationContext(this) { DisplayName = nameof(Patient) });
            Validator.ValidateProperty(barcode, new ValidationContext(this) { DisplayName = nameof(barcode) });

            return errors;
        }
    }

    [Owned]
    public class Passport : IValidatableObject
    {
        protected Passport() { }
        public Passport(string serial, string number)
        {
            Serial = serial;
            Number = number;
        }

        [RegularExpression("^([0-9]{2}\\s{1}[0-9]{2})?$")]
        public string Serial { get; set; }
        [RegularExpression("^([0-9]{6})?$")]
        public string Number { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            Validator.ValidateProperty(Serial, new ValidationContext(this) { DisplayName = nameof(Serial) });
            Validator.ValidateProperty(Number, new ValidationContext(this) { DisplayName = nameof(Number) });

            return errors;
        }
    }
    [Owned]
    public class Person
    {
        protected Person() { }
        public Person(string name, DateTime birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class Patient : IValidatableObject 
    {
        protected Patient() { }
        public Patient(Identity user, Person person, Insurance company, int socialSecNumber, string socialSecType, string ein, string phone, Passport passport, string country, string ua)
        {
            this.user = user;
            this.person = person;
            Company = company;
            SocialSecNumber = socialSecNumber;
            SocialSecType = socialSecType;
            this.ein = ein;
            this.phone = phone;
            Passport = passport;
            this.country = country;
            this.ua = ua;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public Guid guid { get; set; }
        [Required]
        public Identity user { get; set; }
        [Required]
        public Person person{ get; set; }
        [Required]
        public Insurance Company { get; set; }
        [Required]
        public int SocialSecNumber { get; set; }
        [Required]
        public string SocialSecType { get; set; }
        [Required]
        public string ein { get; set; }
        [Required,Phone]
        public string phone { get; set; }
        [Required]
        public Passport Passport { get; set; }  
        [Required]
        public string country { get; set; }
        [Required]
        public string ua { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            Validator.ValidateProperty(user, new ValidationContext(this) { DisplayName = nameof(user) });
            Validator.ValidateProperty(Company, new ValidationContext(this) { DisplayName = nameof(Company) });
            Validator.ValidateProperty(SocialSecNumber, new ValidationContext(this) { DisplayName = nameof(SocialSecNumber) });
            Validator.ValidateProperty(SocialSecType, new ValidationContext(this) { DisplayName = nameof(SocialSecType) });
            Validator.ValidateProperty(ein, new ValidationContext(this) { DisplayName = nameof(ein) });
            Validator.ValidateProperty(phone, new ValidationContext(this) { DisplayName = nameof(phone) });
            Validator.ValidateProperty(country, new ValidationContext(this) { DisplayName = nameof(country) });
            Validator.ValidateProperty(ua, new ValidationContext(this) { DisplayName = nameof(ua) });

            return errors;
        }
    }

    public class Service
    {
        protected Service() { }
        public Service(int code, string name, decimal price)
        {
            Code = code;
            Name = name;
            Price = price;
        }

        [Required,Key]
        public int Code { get; set; }
        [Required,Column("Service")]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }

    public class BloodService
    {
        protected BloodService() { }
        public BloodService(Blood blood, Service service, double result, double finished, bool accepted, CompliteStatus status, analyzerType analyzer, User user)
        {
            Blood = blood;
            this.service = service;
            this.result = result;
            this.finished = finished;
            this.accepted = accepted;
            this.status = status;
            this.analyzer = analyzer;
            this.user = user;
        }

        [Required]
        public Blood Blood { get; set; }
        [Required]
        public Service service { get; set; }
        [Required]
        public double result { get; set; }
        [Required]
        public double finished { get; set; }
        [Required]
        public bool accepted { get; set; }
        [Required]
        public CompliteStatus status { get; set; }
        [Required]
        public analyzerType analyzer { get; set; }
        [Required]
        public User user { get; set; }
    }

    public class User
    {
        protected User() { }
        public User(Identity identity, List<int> services, Roles type, DateTime lastenter)
        {
            this.identity = identity;
            this.services = services;
            this.type = type;
            this.lastenter = lastenter;
        }

        public int Id { get; set; }
        [Required]
        public Identity identity { get; set; }
        [Required]
        public List<int> services { get; set; }
        [Required]
        public Roles type { get; set; }
        [Required]
        public DateTime lastenter { get; set; }
    }

    public enum Roles
    {
        unknow,
        patient,
        Admin,
        Assistant,
        Accountant,
    }
    public enum CompliteStatus
    {
        Unknown,
        Finished,
        Rejected,
    }
    public enum analyzerType
    {
        Unknown,
        Biorad,
        Ledetect
    }
}
