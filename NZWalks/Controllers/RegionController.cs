using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Data;
using NZWalks.Model.Domain;
using NZWalks.Model.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : Controller
    {
        private readonly NZWalksDBContext dBContext;

        public RegionController(NZWalksDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            // get Data from DB to Domain Model
            var regionsDomain = dBContext.Regions.ToList();
            // Map the data to DTO

            List<RegionDto> regionDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionDto.Add(
                    new RegionDto()
                    {
                        Id = regionDomain.Id,
                        Code = regionDomain.Code,
                        Name = regionDomain.Name,
                        RegionImageURL = regionDomain.RegionImageURL
                    }
                    );
            }
            //Return DTO
            return Ok(regionDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = dBContext.Regions.Find(id);

            if (region == null)
            {
                return NotFound();
            }
            else
            {
                var regionDto = new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageURL = region.RegionImageURL

                };
                return Ok(regionDto);
            }

        }
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map regioDTO to regionDomain
            Region regionDomainModel = new Region()
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageURL = addRegionRequestDto.RegionImageURL
            };
            // Add a DB record using DB context

            dBContext.Regions.Add(regionDomainModel);
            dBContext.SaveChanges();
            //Map again to Region DTO to pass the values to Client
            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageURL = regionDomainModel.RegionImageURL
            };

            return CreatedAtAction(nameof(GetById),new {id = regionDomainModel.Id}, regionDto);

        }
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //check if the id exisit
            var regionDomainModel = dBContext.Regions.FirstOrDefault(x => x.Id == id);
            if(regionDomainModel == null)
            {
                return NotFound();
            }
            //now update it
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageURL = updateRegionRequestDto.RegionImageURL;
            dBContext.SaveChanges();

            //map it to DTo

            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageURL = regionDomainModel.RegionImageURL
            };
            return Ok(regionDto);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute]Guid id)
        {
            var regionDomainmodel = dBContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomainmodel==null)
            {
                return NotFound();
            }
            dBContext.Regions.Remove(regionDomainmodel);
            dBContext.SaveChanges();
            return Ok();
        }
    }
}


