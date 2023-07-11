import React, { useState } from "react";
import { NavLink } from "react-router-dom";
import "./Navbar.css";
import { Link } from "react-router-dom";

function NavBar() {  
    const [navActive, setNavActive] = React.useState(false);

    const toggleNavItems = () => {
      setNavActive(!navActive);
    };

    return (
<div className="nav-main">
<nav class="navbar-container">
        <div class="logo-container">
            <Link to="/">Healthcare</Link>
        </div>

        <div className="bars" onClick={toggleNavItems}>
            <div class="bar"></div>
            <div class="bar"></div>
            <div class="bar"></div>
        </div>

        <ul className={`nav-items ${navActive ? 'active' : ''}`}>
            <li class="nav-link"><Link to="/">Home</Link></li>
            <li class="nav-link"><a href="#">Service</a></li>
            <li class="nav-link"><a href="#">Projects</a></li>
            <li class="nav-link"><a href="#">About</a></li>
            <div class="login-register">
                <Link to="/Login/" class="button">Login</Link>
                <Link to="/AccountType/" class="button">Sign Up</Link>
            </div>
        </ul>
    </nav>
</div>

    );
  }

  export default NavBar;