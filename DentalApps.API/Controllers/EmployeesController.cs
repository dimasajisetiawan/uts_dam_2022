using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DentalApps.API.DAL.Interface;
using DentalApps.Models;
using DentalApps.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DentalApps.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployees _employee;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployees employees, IMapper mapper)
        {
            _employee = employees;
            _mapper = mapper;
        }

           [HttpPost]
        public async Task<ActionResult<EmployeeReadDto>> Create(EmployeeCreateDto employeeCreateDto)
        {
            try
            {
                var newEmployee = _mapper.Map<Employee>(employeeCreateDto);
                await _employee.Create(newEmployee);
                var employeeReadDto = _mapper.Map<EmployeeReadDto>(newEmployee);
                return CreatedAtRoute(nameof(GetById), 
                    new { patientID=employeeReadDto.EmployeeID },employeeReadDto);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetAll()
        {
            var results = await _employee.GetAll(); 

            var employeeReadDto = _mapper.Map<IEnumerable<EmployeeReadDto>>(results);
            return Ok(employeeReadDto);
        }

        [HttpGet("{employeeId}",Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeReadDto>> GetById(string employeeId)
        {
            var employee = await _employee.GetById(employeeId);
            if(employee==null) return NotFound();

            var output = _mapper.Map<EmployeeReadDto>(employee);
            return Ok(output);
        }

        
        [HttpPut("{employeeId}")]
        public async Task<ActionResult<EmployeeReadDto>> Update(string employeeId, EmployeeCreateDto employeeCreateDto)
        {
            try
            {
                var editEmployee = _mapper.Map<Employee>(employeeCreateDto);
                await _employee.Update(employeeId,editEmployee);
                var employeeReadDto = _mapper.Map<EmployeeReadDto>(editEmployee);
                return Ok(employeeReadDto);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{employeeId}")]
        public async Task<ActionResult> Delete(string employeeId)
        {
            try
            {
                await _employee.Delete(employeeId);
                return Ok($"Data {employeeId} berhasil didelete !");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}