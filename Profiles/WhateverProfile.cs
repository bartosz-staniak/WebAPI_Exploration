using API_exploration.DTOs;
using API_exploration.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.Profiles
{
    public class WhateverProfile : Profile
    {
        public WhateverProfile()
        {
            CreateMap<InitialModel, WhateverReadDTO>();
            CreateMap<WhateverCreateDTO, InitialModel>();
        }
    }
}
