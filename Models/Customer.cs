using System;
using System.Collections.Generic;

namespace AdminDashboard.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public int? CustomerTypeId { get; set; }

    public virtual Customer? CustomerType { get; set; }

    public virtual ICollection<Customer> InverseCustomerType { get; set; } = new List<Customer>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
