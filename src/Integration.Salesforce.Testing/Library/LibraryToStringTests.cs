using System;
using Integration.Salesforce.Library.Models;
using Xunit;

namespace Integration.Salesforce.Testing.Library.ModelTests
{
    public class PersonToStringTests
    {
        ModelData md = new ModelData();

        [Fact]
        public void ContactToString_ReturnsValidString_True()
        {
            // assemble
            Person person = md.Person();
            Address location = md.Address();
            // act
            var response = person.ToString();
            var teststring = $"PERSON{{Name:{person.FirstName} {person.LastName};Phone:{person.Phone};EMail:{person.EMail};Role:{person.Role};HasCar:{person.HasCar};BatchName:{person.BatchName};}}";
            teststring += location.ToString();
            // assert
            Assert.NotNull(response);
            Assert.Equal(teststring, response, true);
        }

        [Fact]
        public void LocationToString_ReturnsValidString_True()
        {
            // assemble
            Address location = md.Address();
            // act
            var response = location.ToString();
            var teststring = $"ADDRESS{{StreetAddress:{location.StreetAddress};City:{location.City};State:{location.State};Zip:{location.Zip};}}";
            // assert
            Assert.NotNull(response);
            Assert.Equal(teststring, response, true);
        }
    }
}