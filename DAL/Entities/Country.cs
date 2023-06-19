using System;
using System.ComponentModel.DataAnnotations;

namespace ApiVersioning.DAL.Entities
{
	public class Country
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}

