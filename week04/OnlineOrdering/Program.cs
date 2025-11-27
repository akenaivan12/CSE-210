class Program
{
    static void Main(string[] args)
    {
        // ---------- ORDER 1 ----------
        Address address1 = new Address("123 Maple St", "Denver", "CO", "USA");
        Customer customer1 = new Customer("John Carter", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LP100", 899.99, 1));
        order1.AddProduct(new Product("HDMI Cable", "CB200", 12.50, 2));

        // ---------- ORDER 2 ----------
        Address address2 = new Address("45 Sato St", "Osaka", "Kansai", "Japan");
        Customer customer2 = new Customer("Ayumi Tanaka", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Camera", "CM900", 450.00, 1));
        order2.AddProduct(new Product("Tripod", "TP300", 35.99, 1));
        order2.AddProduct(new Product("Memory Card", "MC128", 19.99, 3));

        // ---------- DISPLAY RESULTS ----------
        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}");
            Console.WriteLine(new string('-', 40));
        }
    }
}
