import React from "react"
import "../AdminProfile/AdminProfile.css"
import { useState,useEffect } from "react";
import { Link } from "react-router-dom";
import PatientNavBar from "../PatientNavbar/PatientNavbar";

function PatientProfile(){
  const[patient,setPatient]=useState([]);

  useEffect(()=>{
    fetch("https://localhost:7235/api/Patient/Patient_Profile?key="+
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
            setPatient(myData);
        }
    })
    .catch((err)=>{
        console.log(err.error)
    })
  },[]);
return(
<div className="doc-prof-container">
<div class="center">
<div class="card">
  <div class="additional">
    <div class="user-card">
      <div class="points center">
        Patient
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
      <h1>{patient.name}</h1>
      <div class="coords">
        <span>Patient ID</span>
        <span>{patient.patientId}</span>
      </div>
      <div class="coords">
        <span>  Phone</span>
        <span>{patient.phoneNumber}</span>
      </div>
      <div class="coords">
        <span>Email</span>
        <span>{patient.emailId}</span>
      </div>
      <div class="coords">
        <span>D.O.B </span>
        <span>{patient.dateOfBirth}</span>
      </div>
      <div class="coords">
        <span>Address</span>
        <span>{patient.address}</span>
      </div>
      <div class="stats">
        <div>
          <div class="title">Blood Group</div>
          {/* <i class="fa fa-trophy"></i> */}
          <div class="value">{patient.bloodType}</div>
        </div>
        <div>
          <div class="title">Gender</div>
          {/* <i class="fa fa-gamepad"></i> */}
          <div class="value">{patient.gender}</div>
        </div>
      </div>
    </div>
  </div>
  <div class="general">
    <h1>{patient.name}</h1>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce a volutpat mauris, at molestie lacus. Nam vestibulum sodales odio ut pulvinar.</p>
    <span class="more">Mouse over the card for more info</span>
  </div>
</div>
<div>
<div style={{display:"flex",
justifyContent:"center"}}>
            <Link to="/UpdatePatient">
                <button className="btn1">Edit Profile</button>
            </Link>
        </div>
</div>
</div>
<PatientNavBar/>
</div>
);
}

export default PatientProfile;