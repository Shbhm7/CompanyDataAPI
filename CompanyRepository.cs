public class CompanyRepository
{
    private List<Company> companies = new List<Company>();

    public async Task<IEnumerable<Company>> GetCompaniesAsync()
    {
        await Task.Delay(100);
        return companies;
    }

    public async Task<Company> GetCompanyByIdAsync(int id)
    {
        await Task.Delay(100);
        return companies.FirstOrDefault(c => c.Id == id);
    }

   
    public async Task AddCompanyAsync(Company company)
    {
        await Task.Delay(100);
        company.Id = companies.Count + 1;
        companies.Add(company);
    }
}