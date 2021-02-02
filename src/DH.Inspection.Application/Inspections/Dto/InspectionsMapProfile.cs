using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DH.Inspection.Inspections.Dto
{
    public class InspectionsMapProfile : Profile
    {
        public InspectionsMapProfile()
        {
            CreateMap<InspectionsDto, Inspections>();

        }
    }
}
