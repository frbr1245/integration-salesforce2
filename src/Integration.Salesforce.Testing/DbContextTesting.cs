using System;
using Integration.Salesforce.Context;
using Xunit;
using MongoDB.Driver;
using Xunit.Abstractions;

namespace Integration.Salesforce.Testing
{
    
    public class DbContextTesting
    {
        private readonly IDisposable _logcapture;
        public ITestOutputHelper output; 
        public DbContextTesting(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void DatabaseConnection()
        {
            DbContext context = new DbContext();
        }
    }
}
