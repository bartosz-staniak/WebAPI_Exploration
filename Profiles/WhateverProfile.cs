﻿using API_exploration.DTOs;
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
            CreateMap<WhateverUpdateDTO, InitialModel>(); // attempt to fix a patch mapping issue
            CreateMap<InitialModel, WhateverUpdateDTO>();
        }
    }

    public class AnotherProfile : Profile
    {
        public AnotherProfile()
        {

        }
        CreateMap<AnotherModel, AnotherUpdateDTO>();
    }
}
