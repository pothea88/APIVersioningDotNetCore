using System;
using ApiVersioning.DAL.DbContexts;
using ApiVersioning.Models;
using ApiVersioning.DAL.Entities;
namespace ApiVersioning.Services
{
	public class CountryService : ICountryService
	{
		private readonly CountryDbContext _dbcontext;
		public CountryService(CountryDbContext dbContext)
		{
			_dbcontext = dbContext;
		}

		public IEnumerable<CountryV1ResponseViewModel> CountryV1GetAsync()
		{
			var countries = _dbcontext.Countries.ToList();
			if(countries == null)  throw new ApplicationException("Do not have data");

			var countryList = new List<CountryV1ResponseViewModel>();
			foreach(var item in countries)
			{
				countryList.Add(
					new CountryV1ResponseViewModel
					{
						Id = item.Id,
						Name = item.Name
					}
				);
			}
			return countryList;
		}

        public IEnumerable<CountryV2ResponseViewModel> CountryV2GetAsync()
        {
            var countries = _dbcontext.Countries.ToList();
            if (countries == null) throw new ApplicationException("Do not have data");

            var countryList = new List<CountryV2ResponseViewModel>();
            foreach (var item in countries)
            {
				countryList.Add(
					new CountryV2ResponseViewModel
					{
						Id = item.Id,
						CountryName = item.Name
					}
				);
            }
            return countryList;
        }
    }
}

