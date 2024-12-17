using System.ComponentModel.DataAnnotations;

namespace API.Models
{
	public class achievement
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}