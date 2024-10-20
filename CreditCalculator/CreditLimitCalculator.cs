using static CreditCalculator.Before.CompanyType;

namespace CreditCalculator.Before;

public class CreditLimitCalculator(CustomerCreditServiceClient creditService)
{
    public (bool HasCeditLimit, decimal? creditLimit) Calculate(Company company, Customer customer)
    {
        //todo strategy pattern > type calculators
        return company.Type switch
        {
            VeryImportant => (false, null),
            Important => (true, GetCreditLimit(customer) * 2),
            _ => (true, GetCreditLimit(customer))
        };
    }

    private decimal GetCreditLimit(Customer customer)
    {
        return creditService.GetCreditLimit(
            customer.FirstName,
            customer.LastName,
            customer.DateOfBirth);
    }
}