using HospitalAPI.Interfaces;
using HospitalAPI.Models.DTO;
using HospitalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using HospitalAPI.CustomExceptions;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactCORS")]

    public class AdminController : ControllerBase
    {
        private readonly IManageAdmin _admin;

        public AdminController(IManageAdmin admin)
        {
            _admin = admin;
        }

        [HttpPost("Admin_Registration")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize]
        public async Task<ActionResult<UserDTO>> RegisterAdmin(Admin userDTO)
        {
            try
            {
                var user = await _admin.AdminRegistration(userDTO);
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

        [HttpGet("Admin_Profile")]
        [ProducesResponseType(typeof(Admin), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Admin>> AdminProfile(int key)
        {
            try
            {
                var user = await _admin.GetAdminProfile(key);
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

        [HttpGet("View_All_Doctors")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Doctor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ICollection<Doctor>>> ViewAllDoctors()
        {
            try
            {
                var user = await _admin.ViewAllDoctors();
                if (user == null)
                {
                    return BadRequest(new Error(1, "No Doctors available"));
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


        [HttpGet("View_All_UnApproved_Doctors")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Doctor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ICollection<Doctor>>> ViewAllUnApprovedDoctors()
        {
            try
            {
                var user = await _admin.ViewAllUnapprovedDoctors();
                if (user == null)
                {
                    return BadRequest(new Error(1, "No Doctors available"));
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

        [HttpGet("View_All_Patients")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Patient>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ICollection<Patient>>> ViewAllPatients()
        {
            try
            {
                var user = await _admin.ViewAllPatients();
                if (user == null)
                {
                    return BadRequest(new Error(1, "No Patients available"));
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


        [HttpPut("Update_Doctor_Status")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ActionResult<StatusDTO>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StatusDTO>> UpdateUserStatus(StatusDTO userApproval)
        {
            try
            {
                var result = await _admin.ChangeDoctorStatus(userApproval);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest(new Error(1, "Unable to update the Doctors status"));
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


        [HttpGet("Search_Patient_By_Name")]
        [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ICollection<Patient>>> SearchPatientByName(string name)
        {
            try
            {
                var user = await _admin.SearchPatientByName(name);
                if (user == null)
                {
                    return BadRequest(new Error(1, "No Patient available"));
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



        [HttpGet("Search_By_Name")]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<Doctor>>> SearchByName(string name)
        {
            try
            {
                var user = await _admin.SearchByName(name);
                if (user == null)
                {
                    return BadRequest(new Error(1, "No Doctors available"));
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


        [HttpGet("Search_By_Name_UnApproved")]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ICollection<Doctor>>> SearchByNameUnApproved(string name)
        {
            try
            {
                var user = await _admin.SearchByNameForUnApproved(name);
                if (user == null)
                {
                    return BadRequest(new Error(1, "No Doctors available"));
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

        [HttpGet("Search_By_Specialization")]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<ICollection<Doctor>>> SearchBySpecialization(string name)
        {
            try
            {
                var user = await _admin.SearchDoctorBySpecialization(name);
                if (user == null)
                {
                    return BadRequest("Unable to get the doctor.");
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

        [HttpGet("Search_By_Specialization_UnApproved")]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ICollection<Doctor>>> SearchBySpecializationUnApproved(string name)
        {
            try
            {
                var user = await _admin.SearchDoctorBySpecializationForUnApproved(name);
                if (user == null)
                {
                    return BadRequest("Unable to get the doctor.");
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

        [HttpDelete("Delete_Doctor")]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(int key)
        {
            try
            {
                var user = await _admin.DeleteDoctorById(key);
                if (user == null)
                {
                    return BadRequest(new Error(1, "Unable to get the doctor"));
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

        [HttpGet("Experience_Sort_Descending")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Doctor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Doctor>>> SortExperienceByDesc()
        {
            var user = await _admin.SortByDescExpDoctors();
            if (user == null)
            {
                return BadRequest("No Doctors available");
            }
            return Ok(user);
        }

        [HttpGet("Experience_Sort_Ascending")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Doctor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Doctor>>> SortExperienceByAsc()
        {
            var user = await _admin.SortByAscExpDoctors();
            if (user == null)
            {
                return BadRequest("No Doctors available");
            }
            return Ok(user);
        }

        [HttpGet("Date_Added_Sort_Descending")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Doctor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Doctor>>> SortAddedByDesc()
        {
            var user = await _admin.SortByRecenetlyAddedDescDoctors();
            if (user == null)
            {
                return BadRequest("No Doctors available");
            }
            return Ok(user);
        }

        [HttpGet("Date_Added_Sort_Ascending")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Doctor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Doctor>>> SortAddedByAsc()
        {
            var user = await _admin.SortByRecenetlyAddedAscDoctors();
            if (user == null)
            {
                return BadRequest("No Doctors available");
            }
            return Ok(user);
        }
    }
}
