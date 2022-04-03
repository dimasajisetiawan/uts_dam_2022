using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DentalApps.Models;
using DentalApps.Models.DTO;

namespace DentalApps.API.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee,EmployeeReadDto>();
            CreateMap<EmployeeCreateDto,Employee>();
        }
    }
}