namespace EdufyAPI.Helpers
{
    public static class UrlValidatorHelper
    {
        // Basic Format Check
        public static bool IsValidUrlFormat(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }

        // Check if URL is Reachable
        public static async Task<bool> IsUrlReachableAsync(string url)
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
