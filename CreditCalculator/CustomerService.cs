namespace CreditCalculator.Before;

public class CustomerService( 
    CompanyRepository companyRepository, 
    CustomerRepository customerRepository, 
    CustomerCreditServiceClient creditService )
{
    public bool AddCustomer(
        string firstName,
        string lastName,
        string email,
        DateTime dateOfBirth,
        int companyId)
    {
        if (!IsValid(firstName, lastName, email, dateOfBirth)) return false;

        var company = companyRepository.GetById(companyId);

        var customer = new Customer
        {
            Company = company,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName
        };

        (customer.HasCreditLimit, customer.CreditLimit) = CreditLimitCalculator.Calculate(creditService, company, customer);

        if (customer.HasCreditLimit && customer.CreditLimit < 500)
        {
            return false;
        }

        var customerRepository = new CustomerRepository();
        customerRepository.AddCustomer(customer);

        return true;
    }

    private static bool IsValid(string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        const int minimumAge = 21;
        return !string.IsNullOrEmpty(firstName) && 
               !string.IsNullOrEmpty(lastName) && 
               email.Contains('@') &&
               email.Contains('.') &&
               CalculateAge(dateOfBirth, DateTime.Now) >= minimumAge;
    }

    private static int CalculateAge(DateTime dateOfBirth, DateTime now)
    {
        var age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month ||
            now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)
        {
            age--;
        }

        return age;
    }
}