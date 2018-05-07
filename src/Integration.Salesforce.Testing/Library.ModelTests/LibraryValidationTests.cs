using Integration.Salesforce.Library.Validation;
using Xunit;

namespace Integration.Salesforce.Testing.Library.ModelTests
{
    public class LibraryValidationTests
    {
        // test date validation
        [Theory]
        [InlineData("1950-03-18")]
        public void DateValidation_IsValid_True(string value)
        {
            // arrange
            var attrib = new DateValidation();
            // act
            var result = attrib.IsValid(value);
            // assert
            Assert.True(result);
        }

        // test string validation
        [Theory]
        [InlineData("John doe")]
        public void StringValidation_IsValid_True(string value)
        {
            // arrange
            var attrib = new StringValidation();
            // act
            var result = attrib.IsValid(value);
            // assert
            Assert.True(result);
        }

        // test phone number validator
        [Theory]
        [InlineData("1231231234")]
        public void PhoneValidation_IsValid_True(string value)
        {
            // arrange
            var attrib = new PhoneValidation();
            // act
            var result = attrib.IsValid(value);
            // assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        public void BoolValidation_IsValid_True(bool value)
        {
            // arrange
            var attrib = new BoolValidation();

            // act
            var result = attrib.IsValid(value);

            // assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(94928)]
        public void NumberValidation_IsValid_True(object value)
        {
            // arrange
            var attrib = new NumberValidation();
            // act
            var result = attrib.IsValid(value);
            // assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("kamikani@hotmail.com")]
        public void EMailValidation_IsValid_True(string value)
        {
            // arrange
            var attrib = new EMailValidation();
            // act
            var result = attrib.IsValid(value);
            // assert
            Assert.True(result);
        }
    }
}