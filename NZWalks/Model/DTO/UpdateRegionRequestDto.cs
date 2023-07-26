using System;
namespace NZWalks.Model.DTO
{
	public class UpdateRegionRequestDto
	{
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageURL { get; set; }
    }
}

