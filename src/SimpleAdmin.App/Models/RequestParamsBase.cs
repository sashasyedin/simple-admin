using SimpleAdmin.App.Models.Abstractions;

namespace SimpleAdmin.App.Models
{
    public abstract class RequestParamsBase : IPaginationInfo
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
