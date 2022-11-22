using System.Net;
using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using SpecFlow.Internal.Json;
using SSYS.API.HCM.Resources;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace SSYS.API.Tests.Steps;

[Binding]
public class EmployeeServiceStepDefinitions : WebApplicationFactory<Program>
{
    private readonly WebApplicationFactory<Program> _factory;

    public EmployeeServiceStepDefinitions(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    
    private Task<HttpResponseMessage> Response { get; set; }
    
    // Checking the Endpoint

    [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/employees is available")]
    public void GivenTheEndpointHttpsLocalhostApiVEmployeesIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"http://localhost:{port}/api/v{version}/employees");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
    }
    
    // Adding An Employee

    [When(@"a Post Request is sent")]
    public void WhenAPostRequestIsSent(Table saveEmployeeResource)
    {
        var resource = saveEmployeeResource.CreateSet<SaveEmployeeResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }

    [Then(@"a Response is received with Status (.*)")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
        
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    // Deleting an Employee
    
    [When(@"a Delete Request is sent")]
    public void WhenADeleteRequestIsSent(Table deletedEmployeeResource)
    {
        var resource = deletedEmployeeResource.CreateSet<EmployeeResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.DeleteAsync(BaseUri);
    }

    [Then(@"a esponse is received with Status (.*)")]
    public void ThenAEsponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
        
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }
}