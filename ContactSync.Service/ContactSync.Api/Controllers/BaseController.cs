using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ContactSync.Api.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IMapper Mapper;

        public BaseController(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}