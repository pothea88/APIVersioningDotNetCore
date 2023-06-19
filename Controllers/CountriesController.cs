using System;
using Microsoft.AspNetCore.Mvc;
using ApiVersioning.Services;
using ApiVersioning.Models;
namespace ApiVersioning.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	[ApiVersion("2.0")]
    public class CountriesController : ControllerBase
	{
		private readonly ICountryService _service;
		public CountriesController(ICountryService service)
		{
			_service = service;
		}

		[HttpGet]
		[MapToApiVersion("1.0")]
		public IEnumerable<CountryV1ResponseViewModel> GetAllV1Async()
		{
			var result = _service.CountryV1GetAsync();

			return result;
		}

        [HttpGet]
		[MapToApiVersion("2.0")]
        public IEnumerable<CountryV2ResponseViewModel> GetAllV2Async()
        {
            var result = _service.CountryV2GetAsync();

            return result;
        }
    }
}

