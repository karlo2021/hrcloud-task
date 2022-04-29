// Program.cs
//
// © 2021

using Microsoft.EntityFrameworkCore;

using Domain;
using Persistence;
using Persistence.Infrastructure;

// See https://aka.ms/new-console-template for more information

var dbf = new DatabaseContextFactory();
var db = dbf.CreateDbContext(args: new string[] {});

// var person = new Person(
//     id: default,
//     firstName: "Jaimie",
//     lastName: "Vega",
//     address: "4200 Martin Luther King, Huston",
//     tag: Domain.Enumeration.Tag.Friend
// );
// var resultOfInsert = CreatePerson(db, person);

// Console.WriteLine($"result of insert: {resultOfInsert.Id}");

// var contact = new Contact(
//     id: default(int),
//     number: "003856465755",
//     personId: 3
// );
// var resultOfContactInsert = CreateContact(db, contact);
// Console.WriteLine($"result of insert: {resultOfContactInsert.Id}");

// var email = new EmailAddress(
//     id: default(int),
//     email: "John.Doe@outlook.com",
//     personId: 1
// );

// var resultOfEmailInsert = CreateEmail(db, email);
// Console.WriteLine($"result of insert: {resultOfEmailInsert.Id}");

var person = GetPerson(db, "John", "Doe");
Console.WriteLine($"Person id: {person.Id}");

static Person CreatePerson(DatabaseContext db, Person person)
{
    db.Persons.Add(person);
    db.SaveChanges();

    return person;
}

static Contact CreateContact(DatabaseContext db, Contact contact)
{
    db.Contacts.Add(contact);
    db.SaveChanges();

    return contact;
}

static EmailAddress CreateEmail(DatabaseContext db, EmailAddress email)
{
    db.EmailAddresses.Add(email);
    db.SaveChanges();

    return email;
}

static Person GetPerson(DatabaseContext db, string firstName, string lastName)
{
    var person = db.Persons
        .AsNoTracking()
        .Where(p => p.FirstName == firstName)
        .Where(p => p.LastName == lastName)
        .FirstOrDefault<Person>();

    return person ?? null;
}