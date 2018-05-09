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
            Batch batch = md.Batch();
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
    }
}