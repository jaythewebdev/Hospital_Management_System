import React, { useState } from "react";
import {FaSignOutAlt } from "react-icons/fa";
import "../Navbar/Navbar.css";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";

function PatientNavBar() {  
    const [navActive, setNavActive] = React.useState(false);

    const toggleNavItems = () => {
      setNavActive(!navActive);
    };

    const navigate = useNavigate();

    const logout = () => {
        localStorage.clear();
        navigate("/");
    };

    return (
<div className="nav-main">
<nav class="navbar-container">
        <div class="logo-container">
        <a href="#">Healthcare</a>
        </div>

        <div className="bars" onClick={toggleNavItems}>
            <div class="bar"></div>
            <div class="bar"></div>
            <div class="bar"></div>
        </div>

        <ul className={`nav-items ${navActive ? 'active' : ''}`}>
            <li class="nav-link"><Link to="/PatientProfile">Profile</Link></li>
            <li class="nav-link"><Link to="/UpdatePatient">Update Profile</Link></li>
            <li class="nav-link"><Link to="/PatientApprovedDoctors">Doctors</Link></li>
            <div class="login-register" onClick={logout}>
            <li class="button"><FaSignOutAlt className="navbar-icon"/>&nbsp;&nbsp;LogOut</li>
            </div>
        </ul>
    </nav>
</div>

    );
  }

  export default PatientNavBar;