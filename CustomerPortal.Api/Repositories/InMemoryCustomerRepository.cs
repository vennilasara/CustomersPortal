using CustomersPortal.Entities;

namespace CustomersPortal.Repositories
{
    public class InMemoryCustomerRepository : ICustomerRepository   
    {
        private readonly List<Customer> customers = new()
        {
            new Customer {Id = Guid.NewGuid(), FirstName = "Gerard", LastName = "Buskermolen", DateOfBirth = new DateTime(1990, 12, 01), Email = "gerard.busker@kpn.com", Mobile = "1234567890", Gender = "Male", CreatedDate = DateTime.Now, Address ="Januaristraat 15, 1234AB" },
            new Customer {Id = Guid.NewGuid(), FirstName = "Hulya", LastName = "Berkhout", DateOfBirth = new DateTime(1965, 09, 30), Email = "hulya.bus@kpn.com", Mobile = "5678902314", Gender = "Female", CreatedDate = DateTime.Now, Address = "Februaristraat 30, 1345GH"},
            new Customer {Id = Guid.NewGuid(), FirstName = "Linda", LastName = "Bas", DateOfBirth = new DateTime(1975, 10, 01), Email = "linda.berk@kpn.com", Mobile = "2345678901", Gender = "Female", CreatedDate = DateTime.Now, Address ="Maartstraat 45,  1456YU" },
            new Customer {Id = Guid.NewGuid(), FirstName = "Bernard", LastName = "Barry", DateOfBirth = new DateTime(1982, 12, 01), Email = "barry.bernard@kpn.com", Mobile = "6789012345", Gender = "Other" , CreatedDate = DateTime.Now, Address="Aprilstraat 60, 1567RM"},
        };

        public IEnumerable<Customer> GetCustomers()
        {
            return  customers;
        }

        public Customer GetCustomer(Guid id)
        {
            return customers.Where(c => c.Id == id).SingleOrDefault();
        }

        public void CreateCustomer(Customer customer)
        {
            customers.Add(customer);    
        }

        public void UpdateCustomer(Customer customer)
        {
            var index = customers.FindIndex(c => c.Id == customer.Id);
            customers[index] = customer;

        }

        public void DeleteCustomer(Guid Id)
        {
            var index = customers.FindIndex(c => c.Id == Id);
            customers.RemoveAt(index);
        }
    }
}
