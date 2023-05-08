

using CustomersPortal.DataContracts_DTO;

namespace CustomersPortal.Entities
{
    public record Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Address { get; set; }

    }
}
