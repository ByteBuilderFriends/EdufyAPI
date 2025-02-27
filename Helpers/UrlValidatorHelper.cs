namespace EdufyAPI.Helpers
{
    // A helper class for validating URLs, including format checks and reachability tests
    public static class UrlValidatorHelper
    {
        // Basic Format Check
        // Checks if the URL is in a well-formed format (e.g., includes scheme like http or https) 
        public static bool IsValidUrlFormat(string url)
        {
            // Uses built-in Uri method to validate the URL format 
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }

        // Checks if the URL is reachable by sending an HTTP GET request and verifying the status code
        public static async Task<bool> IsUrlReachableAsync(string url)
        {
            try
            {
                // Initialize HttpClient for sending the request
                using var httpClient = new HttpClient();
                // Send a GET request to the URL and wait for the response
                var response = await httpClient.GetAsync(url);
                // Return true if the response indicates success (status code 2xx [200:299])
                return response.IsSuccessStatusCode;
            }
            catch
            {
                // If there's an exception (e.g., network issue)
                return false;
            }
        }
    }
}
