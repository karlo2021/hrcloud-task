// PersonValidationService.cs
//
// © 2021

using Business.DataTransferObjects.Person;
using Business.Services.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace Business.Services.Implementation;

public class PersonValidationService : IPersonValidationService
{
    public void ValidatePerson(CreatePersonDto createPersonDto)
    {
        if (string.IsNullOrEmpty(createPersonDto.FirstName))
        {
            throw new ValidationException();
        }

        if (createPersonDto.FirstName.Length >= Domain.Person.MaxStringLength)
        {
            var message = $"First name is to long! First name must be less than ${Domain.Person.MaxStringLength}";
            throw new ValidationException(message);
        }

        if (createPersonDto.LastName.Length >= Domain.Person.MaxStringLength)
        {
            var message = $"Last name is to long! Last name must be less than ${Domain.Person.MaxStringLength}";
            throw new ValidationException(message);
        }

        if (createPersonDto.Address.Length >= Domain.Person.MaxStringLength)
        {
            var message = $"Address is to long! Address must be less than ${Domain.Person.MaxStringLength}";
            throw new ValidationException(message);
        }
    }
}
