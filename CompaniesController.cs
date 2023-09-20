using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 
[ApiController]
[Route("api/companies")]
public class CompaniesController : ControllerBase
{
    private readonly CompanyRepository _repository;

    public CompaniesController(CompanyRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _repository.GetCompaniesAsync();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(int id)
    {
        var company = await _repository.GetCompanyByIdAsync(id);
        if (company == null)
            return NotFound();
        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> AddCompany(Company company)
    {
        await _repository.AddCompanyAsync(company);
        return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
    }
}

