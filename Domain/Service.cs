using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public Identity(string name, string login, string password, string ip, Roles role)
        {
            Name = name;
            this.login = login;
            this.password = password;
            Ip = ip;
            this.role = role;
        }

        [Required, DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string login { get; set; }
        [Required, DisplayFormat(ConvertEmptyStringToNull = true)]
        public string password { get; set; }
        [Required, DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Ip { get; set; }
        [Required]
        public Roles role { get; set; }
        [Required]
        public DateTime lastenter { get; set; } = DateTime.Now;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            Validator.ValidateProperty(Name, new ValidationContext(this) { MemberName = nameof(Name) });
            Validator.ValidateProperty(login, new ValidationContext(this) { MemberName = nameof(login) });
            Validator.ValidateProperty(password, new ValidationContext(this) { MemberName = nameof(password) });
            Validator.ValidateProperty(Ip, new ValidationContext(this) { MemberName = nameof(Ip) });
            Validator.ValidateProperty(role, new ValidationContext(this) { MemberName = nameof(role) });

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

        [RegularExpression(@"^[0-9]{2}\s[0-9]{2}$")]
        public string Serial { get; set; }
        [RegularExpression("^[0-9]{6}$")]
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
    public class Person : IValidatableObject
    {
        protected Person() { }
        public Person(string name, DateTime birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        [Required, DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Name { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            Validator.ValidateProperty(Name, new ValidationContext(this) { DisplayName = nameof(Name) });
            Validator.ValidateProperty(Birthdate, new ValidationContext(this) { DisplayName = nameof(Birthdate) });

            if ((DateTime.Now - Birthdate).TotalDays / 356 <= 100) throw new ValidationException("age more than 100 years");

            return errors;
        }
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
        public Guid guid { get; set; } = Guid.NewGuid();
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

    public class Service : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            Validator.ValidateProperty(Code, new ValidationContext(this) { DisplayName = nameof(Code) });
            Validator.ValidateProperty(Name, new ValidationContext(this) { DisplayName = nameof(Name) });
            Validator.ValidateProperty(Price, new ValidationContext(this) { DisplayName = nameof(Price) });

            if (Price <= 0) throw new ValidationException("Price less 0");

            return errors; 
        }
    }

    public class BloodService : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            Validator.ValidateProperty(Blood, new ValidationContext(this) { DisplayName = nameof(Blood) });
            Validator.ValidateProperty(service, new ValidationContext(this) { DisplayName = nameof(service) });
            Validator.ValidateProperty(result, new ValidationContext(this) { DisplayName = nameof(result) });
            Validator.ValidateProperty(finished, new ValidationContext(this) { DisplayName = nameof(finished) });
            Validator.ValidateProperty(accepted, new ValidationContext(this) { DisplayName = nameof(accepted) });
            Validator.ValidateProperty(status, new ValidationContext(this) { DisplayName = nameof(status) });
            Validator.ValidateProperty(analyzer, new ValidationContext(this) { DisplayName = nameof(analyzer) });
            Validator.ValidateProperty(user, new ValidationContext(this) { DisplayName = nameof(user) });

            if (analyzer == analyzerType.Unknown) throw new ValidationException("Unknow type analyzer");
            if (status == CompliteStatus.Unknown) throw new ValidationException("Unknow complite status");

            return errors;
        }
    }

    public class User : IValidatableObject
    {
        protected User() { }
        public User(Identity identity, List<int> services)
        {
            this.identity = identity;
            this.services = services;
        }

        public int Id { get; set; }
        [Required]
        public Identity identity { get; set; }
        [Required]
        public List<int> services { get; set; }
        [Required]
        public DateTime lastenter { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            Validator.ValidateProperty(identity, new ValidationContext(this) { DisplayName = nameof(identity) });
            Validator.ValidateProperty(services, new ValidationContext(this) { DisplayName = nameof(services) });

            return errors;
        }
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

    public class Report : IValidatableObject
    {
        protected Report() { }
        public Report(string name, string data)
        {
            this.name = name;
            this.data = data;
        }
       
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Column(TypeName = "nvarchar(max)"), Required]
        public string data { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            Validator.ValidateProperty(name, new ValidationContext(this) { DisplayName = nameof(name)});
            Validator.ValidateProperty(data,new ValidationContext(this) { DisplayName = nameof(data)});

            return errors;
        }
    }

    public class HistoryRow
    {
        protected HistoryRow() { }
        public HistoryRow(string login, bool confirm, DateTime? enterTime, DateTime? exitTime)
        {
            this.login = login;
            this.confirmEnter = confirm;
            this.EnterTime = enterTime;
            this.exitTime = exitTime;
        }
        public int id { get; set; }
        public string login { get; set; }
        public DateTime? EnterTime { get; set; }
        public DateTime? exitTime { get; set; }
        public bool confirmEnter { get; set; }
    }
}
