using CustomersPortal.DataContracts_DTO;
using CustomersPortal.Entities;

namespace CustomersPortal.Repositories
{
    public static class Extensions
    {
        public static CustomersDTO AsDto(this Customer customer)
        {
            return new CustomersDTO()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Mobile = customer.Mobile,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender,
                Address = customer.Address
            };
        }
    }
}
