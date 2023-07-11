using HospitalAPI.CustomExceptions;
using HospitalAPI.Interfaces;
using HospitalAPI.Models;
using HospitalAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactCORS")]

    public class PatientController : ControllerBase
    {

        private readonly IManagePatient _patient;


        public PatientController(IManagePatient patient)
        {
            _patient = patient;
        }

        [HttpPost("Patient_Registration")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize]
        public async Task<ActionResult<UserDTO>> RegisterPatient(PatientRegisterDTO userDTO)
        {
            try
            {
                var user = await _patient.PatientRegistration(userDTO);
                if (user == null)
                {
                    return BadRequest(new Error(1, "Unable to Register. Try again with a different mail."));
                }
                return Ok(user);
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Patient_Profile")]
        [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult<Patient>> PatientProfile(int key)
        {
            try
            {
                var user = await _patient.PatientProfile(key);
                if (user == null)
                {
                    return BadRequest(new Error(1, "Unable to get the profile."));
                }
                return Ok(user);
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update_Patient_Profile")]
        [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult<PatientUpdateDTO>> UpdatePatientProfile(PatientUpdateDTO patient)
        {
            try
            {
                var user = await _patient.UpdatePatient(patient);
                if (user == null)
                {
                    return BadRequest(new Error(1, "Unable to update the profile."));
                }
                return Ok(user);
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Get_All_Approved_Doctors")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Doctor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Doctor>>> ViewAllApprovedDoctors()
        {
            try
            {
                var user = await _patient.ViewAllApprovedDoctors();
                if (user == null)
                {
                    return BadRequest(new Error(1, "No doctors available ."));
                }
                return Ok(user);
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Search_By_Name_Patient")]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize]
        public async Task<ActionResult<ICollection<Doctor>>> SearchByNameForPatient(string name)
        {
            try
            {
                var user = await _patient.SearchByNameForPatient(name);
                if (user == null)
                {
                    return BadRequest(new Error(1, "No doctors available ."));
                }
                return Ok(user);
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Search_By_Specialization_Patient")]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize]
        public async Task<ActionResult<ICollection<Doctor>>> SearchBySpecializationForPatient(string name)
        {
            try
            {
                var user = await _patient.SearchDoctorBySpecializationForPatient(name);
                if (user == null)
                {
                    return BadRequest(new Error(2,"Unable to get the doctors ."));
                }
                return Ok(user);
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Experience_Sort_Descending_Patient")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Doctor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Doctor>>> SortExperienceByDescForPatient()
        {
            var user = await _patient.SortByDescExpDoctorsForPatient();
            if (user == null)
            {
                return BadRequest("No Doctors available");
            }
            return Ok(user);
        }

        [HttpGet("Experience_Sort_Ascending_Patient")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Doctor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Doctor>>> SortExperienceByAscForPatient()
        {
            var user = await _patient.SortByAscExpDoctorsForPatient();
            if (user == null)
            {
                return BadRequest("No Doctors available");
            }
            return Ok(user);
        }

        [HttpGet("Date_Added_Sort_Descending_Patient")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Doctor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Doctor>>> SortAddedByDescForPatient()
        {
            var user = await _patient.SortByRecenetlyAddedDescDoctorsForPatient();
            if (user == null)
            {
                return BadRequest("No Doctors available");
            }
            return Ok(user);
        }

        [HttpGet("Date_Added_Sort_Ascending_Patient")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Doctor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Doctor>>> SortAddedByAscForPatient()
        {
            var user = await _patient.SortByRecenetlyAddedAscDoctorsForPatient();
            if (user == null)
            {
                return BadRequest("No Doctors available");
            }
            return Ok(user);
        }
    }
}
