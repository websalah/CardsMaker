using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IPersonService
    {
        PersonResponse CreateCard(PersonRequest request, string? logoPath);
        PersonResponse? GetPersonById(int id);
        List<PersonResponse> GetAllPersons();
    }
}
