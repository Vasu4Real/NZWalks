using System;
namespace NZWalks.Model.Domain
{
	public class Walks
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal LengthInKm { get; set; }
		public string? WalksImageUrl { get; set; }
		public Guid RegionId { get; set; }
		public Guid DifficultyId { get; set; }

		//Navigation Properties

		public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }

	}
}

