using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           
                // use document db client to get document and return response
                DocumentClient client = new DocumentClient(new Uri("https://alexa.documents.azure.com:443/"), 
                    "xxx==");

                IQueryable<Document> values = client.CreateDocumentQuery<Document>(UriFactory.CreateDocumentCollectionUri("myDb", "myCollection"), "SELECT * FROM c");
            
                Document latest= new Document();
                foreach (var y in values)
                {
                                             latest = y;
                                             break;
                }
                foreach (var x in values)
                {
                       if (x.GetPropertyValue<DateTime>("EventProcessedUtcTime")> latest.GetPropertyValue<DateTime>("EventProcessedUtcTime"))
                       {
                                             latest = x;
                       }
                }
            
            var z = latest.GetPropertyValue<float>("ActiveHeatingTime").ToString();
            Console.WriteLine(z);
            /* Console.WriteLine(latest.GetPropertyValue<float>("CycleTime").ToString());
             Console.WriteLine(latest.GetPropertyValue<String>("ActiveAxes").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("ActiveEnergyValue").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("BadJob").ToString());
             Console.WriteLine(latest.GetPropertyValue<String>("Bloch").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("ToolId").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("CumulativeJobs").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("Fovr").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("Frequency").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("GoodJob").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("LeftSideJobTemperature").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("Line").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("PartCount").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("PathFederate").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("Program").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("RightSideJobTemperature").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("SspeedOvr").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("TotalJob").ToString());
             Console.WriteLine(latest.GetPropertyValue<float>("Voltage").ToString());
             Console.WriteLine(latest.GetPropertyValue<String>("Mode").ToString());
             Console.WriteLine(latest.GetPropertyValue<String>("PathPosition").ToString());
             Console.WriteLine(latest.GetPropertyValue<String>("ProgramComment").ToString());*/

            Console.ReadLine();

        }
    }
}

