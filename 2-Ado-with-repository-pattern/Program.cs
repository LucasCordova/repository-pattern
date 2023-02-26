// dotnet add package Microsoft.Extensions.Configuration
// dotnet add package Microsoft.Extensions.Configuration.Json
// dotnet add package Microsoft.Extensions.Configuration.FileExtensions

using Ado.Infrastructure;
using Ado.Model.Base;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
var configuration = builder.Build();

var connectionString = configuration.GetConnectionString("LukesConnection");

if (connectionString == null)
{
    Console.WriteLine("Connection string not found");
    return;
}

var customerRepository = new CustomerRepository(connectionString);

// Get all customers
Console.WriteLine("All customers:");
var customers = customerRepository.GetAll();
foreach (var customer in customers)
{
    Console.WriteLine($"{customer.Id} {customer.FirstName} {customer.LastName}");
}

// Get customer by Id
Console.WriteLine("\nCustomer with Id 1:");
var customerNumberOne = customerRepository.GetById(1);
Console.WriteLine($"{customerNumberOne.Id} {customerNumberOne.FirstName} {customerNumberOne.LastName}");

// Add customer
Console.WriteLine("\nAdd customer:");
var customerToAdd = new Customer
{
    FirstName = "Luke",
    LastName = "Skywalker",
    Phone = "555-555-5555",
    Email = "luke.skywalker@mail.com"
};
customerRepository.Add(customerToAdd);
var customerAfterAdd = customerRepository.GetAll().Single(customer => customer.Email == "luke.skywalker@mail.com");
Console.WriteLine($"Customer added: {customerAfterAdd.FirstName} {customerAfterAdd.LastName}");

// Update customer
Console.WriteLine("\nUpdate customer:");
customerAfterAdd.LastName = "Skywalker-Vader";
customerRepository.Update(customerAfterAdd);
customerAfterAdd = customerRepository.GetAll().Single(customer => customer.Email == "luke.skywalker@mail.com");
Console.WriteLine($"Customer's name changed to: {customerAfterAdd.FirstName} {customerAfterAdd.LastName}");


// Delete customer
Console.WriteLine("\nDelete customer:");
customerRepository.Delete(customerAfterAdd.Id);
var customersAfterDelete = customerRepository.GetAll().SingleOrDefault(customer => customer.Email == "luke.skywalker@mail.com");

Console.WriteLine(customersAfterDelete == null
    ? $"Customer deleted: {customerAfterAdd.FirstName} {customerAfterAdd.LastName}"
    : $"Customer not deleted: {customersAfterDelete.FirstName} {customersAfterDelete.LastName}");

