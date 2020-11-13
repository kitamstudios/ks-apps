namespace KS.Applications.WebUI.Api
{
    using System;

    public class WebApiClientConfiguration
    {
        public Uri BaseUrl { get; set; }

        public string DeploymentEnvironmentName { get; set; }

        public string DeploymentReleaseNumber { get; set; }

        public string GeneratedIdToken { get; set; }

        public string SearchServiceName { get; set; }

        public string SearchApiKey { get; set; }
    }
}
