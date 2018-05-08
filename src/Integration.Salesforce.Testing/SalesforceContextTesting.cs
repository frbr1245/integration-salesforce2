using Integration.Salesforce.Context;
using Integration.Salesforce.Library.Abstract;
using Microsoft.Extensions.Options;
using Xunit;

namespace Integration.Salesforce.Testing
{
    public class SalesforceContextTesting
    {
        //private readonly SalesforceContext<AModel> _context;
        public SalesforceContextTesting(IOptions<Settings> settings)
        {
            // _context = new SalesforceContext<AModel>(settings);
        }


        // Retrieving config info from appsetting
        // Retrieve auth token from external Salesforce API
        // Send get request to Salesforce using auth token
        [Fact]
        public void getConfigData()
        {
            Assert.False(false);
        }
    }

}