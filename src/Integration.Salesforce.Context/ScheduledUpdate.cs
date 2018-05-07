using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Integration.Salesforce.Library.Abstract;
using Integration.Salesforce.Library.Models;
using Microsoft.Extensions.Options;

namespace Integration.Salesforce.Context
{
    // helper class that retrieves data from salesforce and updates data in mongodb
    public class ScheduledUpdate
    {
        //private List<SalesforceContext<AModel>> _sfContextList;
        private DbContext _dbContext;

        //Dictionary holding names of tables to query from salesforce
        private Dictionary<string,string> categories = new Dictionary<string, string>(){
            {"Contacts","Contact"}, {"Training","Training__c"}, 
            {"HousingAssignments","HousingAssignment__c"}, {"HousingBeds","HousingBed__c"}, 
            {"HousingComplexes","HousingComplex__c"}, {"HousingUnits","HousingUnit__c"}
        };

        public ScheduledUpdate(IOptions<Settings> settings) 
        {
            // _sfContext = new SalesforceContext<AModel>(settings);
            _dbContext = new DbContext();

            // Update the mongo database asynchronously , during
            // the startup of the program.
            // TODO: Automate this retrieval process, every 24 hours for example.
            Task.Run(() => UpdateData(settings)).Wait();
        }

        public async Task UpdateData(IOptions<Settings> settings)
        {
            //TODO: do this for every type of model

            //retrieve IEnumerable of models from salesforce
            var personContext = new SalesforceContext<Person>(settings);
            IEnumerable<Person> modelList = await personContext.RetrieveFromSalesforce(categories["Contacts"]);
            
            
            //update mongodb with new information from salesforce
            //TODO: _dbContext.updateMongoDB();


        }

    }
}