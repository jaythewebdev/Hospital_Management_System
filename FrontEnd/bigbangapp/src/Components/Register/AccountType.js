import React from "react";
import { Link } from "react-router-dom";
import { useState} from "react";
import './AccountType.css'
import patient from '../images/patient-pngrepo-com.png'
import doctor from '../images/doctor-pngrepo-com.png'
import NavBar from "../Navbar/Navbar";
import { useNavigate } from "react-router-dom";

function AccountType() {

    const [selectedAccountType, setSelectedAccountType] = useState(null);

    const handleAccountTypeSelect = (accountType) => {
      setSelectedAccountType(accountType);
    };
    const navigate=useNavigate();

    const handleNextClick = () => {
      console.log(selectedAccountType);
        if(selectedAccountType=="doctor"){
          navigate("/DoctorRegister");
        }
        else{
          navigate("/PatientRegister")
        }
        // selectedAccountType=="doctor"?(navigate("/DoctorRegister/")):(navigate("/PatientRegister/"));
    };

  return (
    <div>
<header class="header">
<div className="account-type-selection">
      <h2>Choose an Account Type</h2>
      <div className="account-types">
        <div
          className={`account-type ${
            selectedAccountType === "doctor" ? "selected" : ""
          }`}
          onClick={() => handleAccountTypeSelect("doctor")}
        >
          <img src={doctor} alt="doctor" />
          <span>Doctor</span>
          {selectedAccountType === "doctor" && (
            <span className="tick">&#10003;</span>
          )}
        </div>
        <div
          className={`account-type ${
            selectedAccountType === "patient" ? "selected" : ""
          }`}
          onClick={() => handleAccountTypeSelect("patient")}
        >
          <img src={patient} alt="patient" />
          <span>Patient</span>
          {selectedAccountType === "patient" && (
            <span className="tick">&#10003;</span>
          )}
        </div>
      </div>
      <div>
            <h3>
                Hello Mate!<br/>
                Please choose an option to continue 
            </h3>
        </div>
      <button onClick={handleNextClick} disabled={!selectedAccountType}>Next</button>
    </div>
</header>
<NavBar/>  
    </div>

  );
}

export default AccountType;
