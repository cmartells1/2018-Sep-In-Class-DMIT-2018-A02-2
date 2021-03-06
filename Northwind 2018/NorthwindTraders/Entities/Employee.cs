﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindTraders.Entities
{
    [Table("Employees")]
    public class Employee
    {
        #region Column Mappings

        [Key]
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoMimeType { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }
        public DateTime LastModified { get; set; }

        #endregion Column Mappings

        #region Navigation Properties

        // DEMO: Foreign Key for Self-Referencing Relationships shows what field the employee would report to inside the own table.
        [ForeignKey("ReportsTo")]
        public virtual Employee Manager { get; set; }

        public ICollection<Employee> Subbordinates { get; set; }
            = new HashSet<Employee>();

        // DEMO: Many-to-Many Relationships
        public virtual ICollection<Territory> Territories { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
            = new HashSet<Order>(); // This could have been set up in the constructor

        #endregion Navigation Properties

        #region Constructors

        public Employee()
        {
            // DEMO: Good practice for Entity Constructors
            // For each navigational property that is a collection,
            // initialize it to an empty hash-set.
            Territories = new HashSet<Territory>();
        }

        #endregion Constructors

        #region Not-Mapped Properties

        [NotMapped] // FullName -> First Last
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [NotMapped] // FormalName -> Last, First
        public string FormalName { get { return $"{LastName}, {FirstName}"; } }

        #endregion Not-Mapped Properties
    }
}