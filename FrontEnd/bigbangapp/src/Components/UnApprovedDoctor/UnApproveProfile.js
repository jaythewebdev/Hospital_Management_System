import React from "react"
import "../AdminProfile/AdminProfile.css"
import { useState,useEffect } from "react";
import UnApproveNavbar from "./UnApproveNavbar";


function UnApproveProfile(){
  const[doctor,setDoctor]=useState([]);

  useEffect(()=>{
    fetch("https://localhost:7235/api/Doctor/Doctor_Profile?key="+
    localStorage.getItem('id'),{
        "method":"GET",
        headers:{
            "accept":"text/plain",
            'Authorization': 'Bearer ' + localStorage.getItem('token')
        }
    })
    .then(async (data)=>{
        if(data.status >= 200 && data.status<=300){
            var myData = await data.json();
            console.log(myData);
            setDoctor(myData);
        }
    })
    .catch((err)=>{
        console.log(err.error)
    })
  },[]);
return(
<div>
<div class="center">
<div class="card">
  <div class="additional">
    <div class="user-card">
      <div class="points center">
        Doctor
      </div>
      <svg xmlns="http://www.w3.org/2000/svg" xmlnsXlink="http://www.w3.org/1999/xlink" version="1.1"  width="110" height="110" viewBox="0 0 650 650" role="img" aria-labelledby="title desc" class="center">
      <defs>
        <clipPath id="circular-border">
          <circle cx="300" cy="300" r="280"></circle>
        </clipPath>
        <clipPath id="avoid-antialiasing-bugs">
          <rect width="100%" height="498" />
        </clipPath>
      </defs>
      <circle cx="300" cy="300" r="280" fill="#0074D9" clipPath="url(#avoid-antialiasing-bugs)" />
      <circle cx="300" cy="230" r="115" fill="#FFFFFF" />
      <circle cx="300" cy="550" r="205" fill="#fff" clipPath="url(#circular-border)" />
    </svg>
    </div>
    <div class="more-info">
      <h1>{doctor.name}</h1>
      <div class="coords">
        <span>Doctor ID</span>
        <span>{doctor.doctorId}</span>
      </div>
      <div class="coords">
        <span>  Phone</span>
        <span>{doctor.phoneNumber}</span>
      </div>
      <div class="coords">
        <span>Email</span>
        <span>{doctor.emailId}</span>
      </div>
      <div class="coords">
        <span>Experience</span>
        <span>{doctor.experience}</span>
      </div>
      <div class="coords">
        <span>D.O.B </span>
        <span>{doctor.dateOfBirth}</span>
      </div>
      <div class="stats">
        <div>
          <div class="title">Status</div>
          {/* <i class="fa fa-trophy"></i> */}
          <div class="value">{doctor.status}</div>
        </div>
        <div>
          <div class="title">Specialization</div>
          {/* <i class="fa fa-group"></i> */}
          <div class="value">{doctor.specialization}</div>
        </div>
      </div>
    </div>
  </div>
  <div class="general">
    <h1>{doctor.name}</h1>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce a volutpat mauris, at molestie lacus. Nam vestibulum sodales odio ut pulvinar.</p>
    <span class="more">Mouse over the card for more info</span>
  </div>
</div>
<div>
<div style={{display:"flex",
justifyContent:"center",color:"#167FE9"}}>
            <h2>You are Yet to be Approved ...</h2>
        </div>
</div>
</div>
<UnApproveNavbar/>
</div>
);
}

export default UnApproveProfile;