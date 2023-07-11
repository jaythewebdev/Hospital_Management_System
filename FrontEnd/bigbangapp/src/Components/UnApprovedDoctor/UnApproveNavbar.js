import React, { useState } from "react";
import {FaSignOutAlt } from "react-icons/fa";
import "../Navbar/Navbar.css";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";

function UnApproveNavbar() {  
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
            <li class="nav-link"><a href="#">Profile</a></li>
            <div class="login-register">
                <a href="#" class="button" onClick={logout}><FaSignOutAlt className="navbar-icon"/>&nbsp;&nbsp;LogOut</a>
            </div>
        </ul>
    </nav>
</div>

    );
  }

  export default UnApproveNavbar;