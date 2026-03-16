using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _persons = new();
        private int _nextId = 1;

        public PersonService()
        {
            _persons.Add(new Person
            {
                Id = _nextId++,
                Name = "Ahmed Ali",
                Email = "ahmed.ali@example.com",
                PhoneNumber = "+964 770 123 4567",
                Address = "123 Main St",
                City = "Baghdad",
                Website = "www.example.com",
                JobTitle = "Software Engineer",
                LogoPath = "/img/logo.png"
            });
        }
        public PersonResponse CreateCard(PersonRequest? request, string? logoPath)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Person person = request.ToPerson();
            person.Id = _nextId++;
            person.LogoPath = logoPath;
            _persons.Add(person);

            return ToPersonResponse(person);
        }
        public PersonResponse? GetPersonById(int id)
        {
            Person? person = _persons.FirstOrDefault(p => p.Id == id);
            return person != null ? ToPersonResponse(person) : null;
        }
        public List<PersonResponse> GetAllPersons()
        {
            return _persons.Select(p => ToPersonResponse(p)).ToList();
        }
        private static PersonResponse ToPersonResponse(Person person)
        {
            return new PersonResponse
            {
                Id = person.Id,
                Name = person.Name,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                Address = person.Address,
                City = person.City,
                Website = person.Website,
                JobTitle = person.JobTitle,
                LogoPath = person.LogoPath
            };
        }
    }
}
