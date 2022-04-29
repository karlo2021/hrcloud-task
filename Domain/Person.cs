// Person.cs
//
// © 2021

using Domain.Enumeration;

namespace Domain;

public class Person
{
    public int Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public Tag Tag { get; set; }
    public Person(int id, string firstName, string lastName, string address, Tag tag = Tag.Regular)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Tag = tag;
    }
    public const int MaxStringLength = 50;
}
