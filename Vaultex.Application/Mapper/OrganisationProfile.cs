using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaultex.Application.DTOs.Organisation.Request;
using Vaultex.Application.DTOs.Organisation.Response;
using Vaultex.Domain.Entities;

namespace Vaultex.Application.Mapper
{
    public class OrganisationProfile : Profile
    {
        public OrganisationProfile()
        {
            CreateMap<Organisation, CreateOrganisationRequest>().ReverseMap();
            CreateMap<Organisation, GetOrganisationResponse>().ReverseMap();
        }
    }
}
