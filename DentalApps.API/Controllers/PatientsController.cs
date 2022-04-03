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
    public class PatientsController : ControllerBase
    {
        private readonly IPatients _patient;
        private readonly IMapper _mapper;

        public PatientsController(IPatients patient, IMapper mapper )
        {
            _patient = patient;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PatientReadDto>> Create(PatientCreateDto patientCreateDto)
        {
            try
            {
                var newPatient = _mapper.Map<Patient>(patientCreateDto);
                await _patient.Create(newPatient);
                var patientReadDto = _mapper.Map<PatientReadDto>(newPatient);
                return CreatedAtRoute(nameof(GetById), 
                    new { patientID=patientReadDto.PatientID },patientReadDto);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientReadDto>>> GetAll()
        {
            var results = await _patient.GetAll(); 

            var patientReadDto = _mapper.Map<IEnumerable<PatientReadDto>>(results);
            return Ok(patientReadDto);
        }

        [HttpGet("{patientId}",Name = "GetById")]
        public async Task<ActionResult<PatientReadDto>> GetById(string patientId)
        {
            var patient = await _patient.GetById(patientId);
            if(patient==null) return NotFound();

            var output = _mapper.Map<PatientReadDto>(patient);
            return Ok(output);
        }

        
        [HttpPut("{patientId}")]
        public async Task<ActionResult<PatientReadDto>> Update(string patientId, PatientCreateDto patientCreateDto)
        {
            try
            {
                var editPatient = _mapper.Map<Patient>(patientCreateDto);
                await _patient.Update(patientId,editPatient);
                var patientReadDto = _mapper.Map<PatientReadDto>(editPatient);
                return Ok(patientReadDto);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{patientId}")]
        public async Task<ActionResult> Delete(string patientId)
        {
            try
            {
                await _patient.Delete(patientId);
                return Ok($"Data {patientId} berhasil didelete !");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}