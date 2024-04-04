using System;
using System.Collections.Generic;

// Encapsulation with Online Ordering
// In this program, I was able to write a program that has classes for Product, Customer, Address, and Order. The program 
// created three orders with a 2 products each. There was a call to the methods to get the packing label, the shipping label, 
// and the total price of the order, and display the results of these methods. Below is the output of one of the orders: 

// Packing Label:
// Smart Phone - W1
// Microwave Oven - G1

// Shipping Label:
// Customer: John Doe
// 123 Main St
// Anytown, CA
// USA
// Total Price: $42.47

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Smart Phone", "W1", 10.99, 2));
        order1.AddProduct(new Product("Microwave Oven", "G1", 15.49, 1));

        Address address2 = new Address("456 Elm St", "AnotherTown", "NY", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Vehicles", "T1", 8.75, 3));
        order2.AddProduct(new Product("Video games", "D1", 5.99, 2));

        Address address3 = new Address("789 Oak St", "SomeCity", "TX", "USA");
        Customer customer3 = new Customer("Bob Johnson", address3);
        Order order3 = new Order(customer3);
        order3.AddProduct(new Product("Jewelry", "W2", 12.99, 1));
        order3.AddProduct(new Product("Safety Equipment", "T2", 9.49, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost()}");

        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost()}");
        
        Console.WriteLine();

        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order3.CalculateTotalCost()}");

    }    
}
