// IPersonValidationService.cs
//
// © 2021

using Business.DataTransferObjects.Person;

namespace Business.Services.Abstraction;
public interface IPersonValidationService
{
    public void ValidatePerson(CreatePersonDto createPersonDto);
}
