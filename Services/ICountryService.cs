using System;
using ApiVersioning.Models;
namespace ApiVersioning.Services
{
	public interface ICountryService
	{
		IEnumerable<CountryV1ResponseViewModel> CountryV1GetAsync();
		IEnumerable<CountryV2ResponseViewModel> CountryV2GetAsync();
    }
}

