using Base.Core.Paging;
using Base.Core.Results;
using MediatR;
using Sinaf.DTO.Responses;
using System.Collections.Generic;

namespace Sinaf.DTO.Requests
{
    public class GetAllClientRequestDTO : IRequest<ResultPaging<GetClienteResponseDTO>>
    {
        //public List<Order> Orders { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
    }
}
