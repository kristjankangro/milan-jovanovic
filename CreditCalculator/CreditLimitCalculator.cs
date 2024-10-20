namespace CreditCalculator.Before;

public class CreditLimitCalculator
{
    public static (bool HasCeditLimit, decimal? creditLimit) Calculate(CustomerCreditServiceClient creditService, Company company, Customer customer)
    {
        if (company.Type == "VeryImportantClient")
            return (false, null);

        if (company.Type == "ImportantClient")
        {

            var creditLimit = creditService.GetCreditLimit(
                customer.FirstName,
                customer.LastName,
                customer.DateOfBirth);

            creditLimit *= 2;
            return (true, creditLimit);
        }
        else
        {
            var creditLimit = creditService.GetCreditLimit(
                customer.FirstName,
                customer.LastName,
                customer.DateOfBirth);

            return (true, creditLimit);
        }
    }
}