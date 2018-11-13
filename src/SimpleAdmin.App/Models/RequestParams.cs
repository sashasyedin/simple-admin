namespace SimpleAdmin.App.Models
{
    public class RequestParams : RequestParamsBase
    {
        public string Filter { get; set; }

        public long[] Ids { get; set; }
    }
}
