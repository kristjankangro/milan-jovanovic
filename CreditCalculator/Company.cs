
namespace CreditCalculator;

public class Company
{
    public int Id { get; set; }
    public CompanyType Type { get; set; }
}



public enum CompanyType
{
    Regular,
    Important,
    VeryImportant
}