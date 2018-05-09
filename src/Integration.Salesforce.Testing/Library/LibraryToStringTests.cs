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
            Person trainer = md.Trainer();
            Address location = md.Location();
            EMail email = md.EMail();
            // act
            var response = trainer.ToString();
            var teststring = $"PERSON{{Name:{trainer.FirstName} {trainer.LastName};Phone:{trainer.Phone};Role:{trainer.Role};HasCar:{trainer.HasCar};BatchName:{trainer.BatchName};}}";
            teststring += location.ToString();
            teststring += email.ToString();
            // assert
            Assert.NotNull(response);
            Assert.Equal(teststring, response, true);
        }

        [Fact]
        public void LocationToString_ReturnsValidString_True()
        {
            // assemble
            Address location = md.Location();
            // act
            var response = location.ToString();
            var teststring = $"ADDRESS{{StreetAddress:{location.StreetAddress};City:{location.City};State:{location.State};Zip:{location.Zip};}}";
            // assert
            Assert.NotNull(response);
            Assert.Equal(teststring, response, true);
        }

        [Fact]
        public void EMailToString_ReturnsValidString_True()
        {
            // assemble
            EMail eMail = md.EMail();
            // act
            var response = eMail.ToString();
            var teststring = $"EMAIL{{EMail:{eMail.cEMail};}}";
            // assert
            Assert.NotNull(response);
            Assert.Equal(teststring, response, true);
        }
    }
}