using static CreditCalculator.CompanyType;

namespace CreditCalculator;

public class CreditLimitCalculator(CustomerCreditServiceClient creditService)
{
    public (bool HasCeditLimit, decimal? creditLimit) Calculate(Customer customer)
    {
        //todo strategy pattern > type calculators
        return customer.Company.Type switch
        {
            VeryImportant => (false, null),
            Important => (true, GetCreditLimit(customer) * 2),
            _ => (true, GetCreditLimit(customer))
        };
    }

    private decimal GetCreditLimit(Customer customer) =>
        creditService.GetCreditLimit(customer.FirstName, customer.LastName, customer.DateOfBirth);
}