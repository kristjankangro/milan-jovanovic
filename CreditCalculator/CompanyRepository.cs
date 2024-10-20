using static CreditCalculator.CompanyType;

namespace CreditCalculator.Before;

public class CompanyRepository
{
    private readonly List<Company> _companies =
    [
        new Company { Id = 1, Type = Regular },
        new Company { Id = 2, Type = Important },
        new Company { Id = 3, Type = VeryImportant }
    ];

    public Company GetById(int companyId)
    {
        return _companies.Single(c => c.Id == companyId);
    }
}