using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;


namespace Integration.Salesforce.Context
{
    public class SalesforceContext
    {
        // SalesForceConfig contains all necessary information to connect to Salesforce API and retrieve data.
        protected readonly Dictionary<string, string> SalesforceConfig;

        // SalesForceUrls contains all the URLs required for all HTTP requests
        protected readonly Dictionary<string, string> SalesforceUrls;

        private string oauthToken;
        private string instanceUrl;

        //(for test purposes)
        //saves salesforce response here
        public string sfResponse { get; private set;}
        
        public SalesforceContext(IOptions<Settings> settings)
        {
            SalesforceConfig = new Dictionary<string, string>();
            SalesforceUrls = new Dictionary<string, string>();

            // Group the salesforce request key-value pairs into dictionary
            SalesforceConfig.Add("grant_type", "password");
            SalesforceConfig.Add("client_id", settings.Value.ClientId);
            SalesforceConfig.Add("client_secret", settings.Value.ClientSecret);
            SalesforceConfig.Add("username", settings.Value.Username);
            SalesforceConfig.Add("password", settings.Value.Password);

            // Group the URLs together
            SalesforceUrls.Add("login", settings.Value.LoginUrl);
            SalesforceUrls.Add("resource_base", settings.Value.ResourceUrlExtension);

            // Update the salesforce database asynchronously only once, during
            // the startup of the program.
            // TODO: Automate this retrieval process, every 24 hours for example.
            Task.Run(() => RetrieveFromDataSource()).Wait();
        }

        private async Task RetrieveFromDataSource()
        {
            // Client used for login
            HttpClient authClient = new HttpClient();

            // Content contains all the key-value pairs needed in the request body
            HttpContent content = new FormUrlEncodedContent(SalesforceConfig);

            // Build the URL for login by concatenating the base URL for Salesforce and additional url for login purposes
            string loginURL = SalesforceUrls["login"];

            // POST to the login URL using the Content as the request body
            HttpResponseMessage message = await authClient.PostAsync(loginURL, content);

            string responseString = await message.Content.ReadAsStringAsync();

            // Request body for login will contain the access_token
            JObject obj = JObject.Parse(responseString);
            oauthToken = obj["access_token"].ToString();
            instanceUrl = obj["instance_url"].ToString();

            // Client used to GET the data from Salesforce
            HttpClient queryClient = new HttpClient();

            // Build the url using the URLs and URL extensions from appsettings.json
            string restQuery = instanceUrl + SalesforceUrls["resource_base"] + "SELECT Name FROM Contact";

            // Define headers for the GET request
            // Authorization header and Accept json header
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, restQuery);
            req.Headers.Add("Authorization", "Bearer " + oauthToken);
            req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await queryClient.SendAsync(req);

            // GET request returns a list of contacts from Salesforce
            // Parse the response into a JSON object.
            string jsonResponse = await response.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(jsonResponse);

            // Take records from json response
            JArray jsonResponseArray = JArray.Parse(jsonObject["records"].ToString());

            // Returns an IEnum of all contacts converted to object models
            //IEnumerable<string> allContacts = await GetAllContacts(jsonRecentItems, oauthToken);
            IEnumerable<string> allContacts = await GetAllContacts(jsonResponseArray, oauthToken);

            //save allContacts info to sfResponse (test purposes)
            foreach(var item in allContacts)
            {
                sfResponse += item;
            }


        }

        //TODO: this method should return an IEnumerable of Models instead of just strings
        private async Task<IEnumerable<string>> GetAllContacts(JArray contactList, string authToken)
        {
            HttpClient queryClient = new HttpClient();
            List<string> modelList = new List<string>();

            // Iterate through each contact in the JSON array
            // Each contact contains a URL pointing to its resource
            // The URL can be accessed through the url property of the attributes property within the contact
            foreach (var contact in contactList)
            {
                // Setup the base request for GET Http Request for each Contact
                // All requests need the Authorization header and all accepts json
                HttpRequestMessage contactRequest = new HttpRequestMessage();
                contactRequest.Method = HttpMethod.Get;
                contactRequest.Headers.Add("Authorization", "Bearer " + authToken);
                contactRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Build each contact url using the url found in the attributes property
                //string contactURL = SalesforceURLs["base"] + contact["attributes"]["url"];
                string contactURL = instanceUrl + contact["attributes"]["url"];

                contactRequest.RequestUri = new Uri(contactURL);

                // Send the request to the specific contact
                HttpResponseMessage response = await queryClient.SendAsync(contactRequest);
                string jsonContactAsString = await response.Content.ReadAsStringAsync();

                // Receive the contact as a JSON object and map it to object model
                // Add the mapped object to the list of mapped models
                //JObject jsonContact = JObject.Parse(jsonContactAsString);
                //modelList.Add(MapJsonToModel(jsonContact));

                
                //TODO: map contact from salesforce to object model

                modelList.Add(jsonContactAsString);
                modelList.Add("+++++");

            }

            return modelList;
        }

    }
}