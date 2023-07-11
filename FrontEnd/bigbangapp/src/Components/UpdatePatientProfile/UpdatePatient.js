import React, { useState } from "react";
import '../UpdateDoctorProfile/UpdateDoctor.css';
import { useNavigate } from "react-router-dom";
import PatientNavBar from "../PatientNavbar/PatientNavbar";
import { toast } from "react-toastify";


 const UpdatePatient = () => {
  const [formData, setFormData] = useState(
    {
      "patientID": localStorage.getItem('id'),
      "phoneNumber": "",
      "emailId": ""
      }
  );

  const navigate=useNavigate();


  const update=()=>{
    console.log(formData)
      fetch("https://localhost:7235/api/Patient/Update_Patient_Profile",{
          "method":"PUT",
          headers:{
              "accept":"text/plain",
              "Content-Type":"application/json",
              'Authorization': 'Bearer ' + localStorage.getItem('token')
          },
          "body":JSON.stringify({...formData,"formData":{} }
          )
      })
      .then(async (data)=>{
          if(data.status >= 200 && data.status<=300){
              var myData = await data.json();
              console.log(myData);
              toast.success("Patient Details Updated Succesfully");
              navigate('/PatientProfile');
          }
      })
      .catch((err)=>{
          console.log(err.error)
      })
  }
  
  const isFormValid = () => {
    return formData.phoneNumber !== "" && formData.emailId !== "";
  }
   return (
    <div>
<div className="update-container">
        <div className="up-prof-head">
            <h1>
                Update Profile
            </h1>
        </div>
<div className="form-container-update" >
      <div className="up-prof">
        {/* <label className="up-prof-label" htmlFor="PH NO">PH NO :</label> */}
        <input
         required
         className="up-prof-input"
          id="PH NO"
          name="PH NO"
        //   value={formData.name}
          placeholder="Phone Number"
          onChange={(event,e)=>{
            setFormData({...formData,"phoneNumber":event.target.value})}}
        />
      </div><br/>
      <div className="up-prof">
        {/* <label className="up-prof-label" htmlFor="address">ADDRESS :</label> */}
        <input
        required
         className="up-prof-input"
          id=  "email"
          name="email"
          placeholder="Email"
          onChange={(event,e)=>{
            setFormData({...formData,"emailId":event.target.value})}}
        />
      </div><br/>
      <div className="prof-btn">
      <button className="up-prof-btn" type="submit"onClick={update} disabled={!isFormValid()} >SUMBIT</button>
      
      </div>
    </div>
    </div>
    <PatientNavBar/>
    </div>
  );
};
 export default UpdatePatient;
