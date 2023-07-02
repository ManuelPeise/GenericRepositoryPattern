using Shared.Http.Interfaces;

namespace Shared.Http.Models
{
    public class RequestModel: IRequestModel
    {
        public Guid RequestId { get; set; }
    }
}
