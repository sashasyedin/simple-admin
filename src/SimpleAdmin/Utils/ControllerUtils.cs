using Microsoft.AspNetCore.Http;

namespace SimpleAdmin.Utils
{
    public static class ControllerUtils
    {
        public static void AddContentRangeHeader(HttpResponse response, int count)
        {
            response.Headers.Add("Content-Range", $"{count}");
        }
    }
}
