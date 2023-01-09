using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Owned]
    public class Insurance
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Inn { get; set; }
        public string PaymentAccount { get; set; }
        public string Bik { get; set; }
    }
    [Owned]
    public class Identity
    {
        public string Name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string Ip { get; set; }
    }

    public class Blood
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public int barcode { get; set; }
        public DateTime date { get; set; } 
    }

    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public Guid guid { get; set; }
        public Identity user { get; set; }
        public Insurance Company { get; set; }
        public int SocialSecNumber { get; set; }
        public string SocialSecType { get; set; }
        public string ein { get; set; }
        public string phone { get; set; }
        public int passportS { get; set; }
        public int passportN { get; set; }
        public DateTime Birthday { get; set; }
        public string country { get; set; }
        public string ua { get; set; }
    }

    public class Service
    {
        [Key]
        public int Code { get; set; }
        [Column("Service")]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class BloodService
    {
        public Blood Blood { get; set; }
        public Service service { get; set; }
        public double result { get; set; }
        public double finished { get; set; }
        public bool accepted { get; set; }
        public CompliteStatus status { get; set; }
        public analyzerType analyzer { get; set; }
        public User user { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public Identity identity { get; set; }
        public List<int> services { get; set; } 
        public Roles type { get; set; }
        public DateTime lastenter { get; set; }
    }

    public enum Roles
    {
        unknow,
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
