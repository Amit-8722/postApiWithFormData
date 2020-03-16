using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UnitTestProject3.TestSteps
{
        [Binding]
    class CreateFormSteps
    {

        HttpClient client;
        HttpResponseMessage response;

        [When(@"I request to create a form")]
        public void WhenIRequestToCreateAForm()
        {
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            var pathToFile = "C:\\Users\\amit.khandelwal\\source\\repos\\UnitTestProject3\\UnitTestProject3\\TestData\\FormData";
            FileStream fs = File.OpenRead(pathToFile);
            multipartFormDataContent.Add(new StreamContent(fs), "file", Path.GetFileName(pathToFile));
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("apikey", "a3e17820e58eb3608f728f038878e13c");
            response = client.PostAsync("https://api.jotform.com/form", multipartFormDataContent).Result;
        }

        [When(@"I request to create a form without file")]
        public void WhenIRequestToCreateAFormWithoutFile()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("questions[1][type]", "radio");
            dict.Add("questions[1][text]", "quesrad");
            dict.Add("questions[1][order]", "1");
            dict.Add("questions[1][name]", "quesname");
            dict.Add("properties[title]", "questitle");
            string data = JsonConvert.SerializeObject(dict, Formatting.Indented);
            var body = new StringContent(data);
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("apikey", "a3e17820e58eb3608f728f038878e13c");
            response = client.PostAsync("https://api.jotform.com/form", body).Result;
        }

        [Then(@"I get back (.*) response")]
        public void ThenIGetBackResponse(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)response.StatusCode);
        }

    }
}
