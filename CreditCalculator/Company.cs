using static CreditCalculator.Before.CompanyType;

namespace CreditCalculator.Before;

public class Company
{
    public static Company RegularClient = new() { Id = 1, Type = Regular };
    public static Company ImportantClient = new() { Id = 2, Type = Important };
    public static Company VeryImportantClient = new() { Id = 3, Type = VeryImportant };

    public int Id { get; set; }

    public CompanyType Type { get; set; }
}

public enum CompanyType
{
    Regular,
    Important,
    VeryImportant
}