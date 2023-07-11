import React, { useState } from "react";
import './Login.css';
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import '../images/login-1.jpg';
import loginimg from '../images/Pediatrician-pana.png'
import { Link } from "react-router-dom";
import NavBar from "../Navbar/Navbar";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";

function Login() {
  const navigate = useNavigate();
  const [loginData, setLoginData] = useState({
    "userId": 0,
    "password": "",
    "role": "",
    "token": "",
    "status": ""
  });
  useEffect(() => {
    let ignore = false;
    if (!ignore)  removingLocalStorage()
    return () => { ignore = true; }
    },[]);

    var removingLocalStorage=()=>{
      localStorage.clear();
  }

  const login = () => {
    fetch("https://localhost:7235/api/User/Login", {
      method: "POST",
      headers: {
        accept: "text/plain",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ ...loginData, "Login": {} }),
    })
      .then(async (data) => {
        var myData = await data.json();
        localStorage.setItem("id", myData.userId);
        localStorage.setItem("role", myData.role);
        localStorage.setItem("token", myData.token);
        if (myData.role === "Patient") {
          console.log(myData);
          toast.success("successful");
          navigate("/PatientProfile");
        } else if (myData.role === "Admin") {
          console.log(myData);
          toast.success("successful");
          navigate("/AdminProfile");
        } else if (myData.role === "Doctor" && myData.token == null) {
          console.log(myData);
          toast.warning("Oops!! It seems you are not yet approved . Try login later !!");
          navigate("/UnApproveProfile");
        } else if (myData.role === "Doctor" && myData.token != null) {
          console.log(myData);
          toast.success("successful");
          navigate("/DoctorProfile");
        }
        else if(myData.userId==0 && myData.password!=""){
          toast.warning("Kindly Fill the User Id Field!!");
        }
        else if(myData.userId!=0 && myData.password==""){
          toast.warning("Kindly Fill the Password Field!!");
        }
        else if(myData.userId==0 && myData.password==""){
          console.log(myData);
          toast.warning("Kindly Fill all the fields !!");
        }
      })
      .catch((err) => {
        console.log("hi");
        toast.error("Kindly check your User Id and Password !!");
        console.log(err.error);
      });
  };

  return (
    <div>
      <div className="container">
        <div className="image-column">
          <img src={loginimg} alt="Login" className="login-image" />
        </div>
        <div className="form-column">
          <div className="logo text-center">
            {/* <h1>Company Name</h1> */}
          </div>
          <div className="wrapper">
            <div className="inner-warpper text-center">
              <h2 className="title">Login to your account</h2>
              <div className="input-group">
                <input
                  className="form-control"
                  name="userName"
                  id="userName"
                  type="number"
                  placeholder="User ID"
                  required
                  onChange={(event) => {
                    setLoginData({
                      ...loginData,
                      userId: event.target.value,
                    });
                  }}
                />
                <span className="lighting"></span>
              </div>
              <div className="input-group">
                <input
                  className="form-control"
                  name="userPassword"
                  id="userPassword"
                  type="password"
                  placeholder="Password"
                  required
                  onChange={(event) => {
                    setLoginData({
                      ...loginData,
                      password: event.target.value,
                    });
                  }}
                />
              </div>

              <button id="login-btn" onClick={login} >
                Login
              </button>
              <div className="clearfix supporter">
                <div className="pull-left remember-me">
                  <input id="rememberMe" type="checkbox" />
                  <label htmlFor="rememberMe">Remember Me</label>
                </div>
                <Link className="forgot pull-right" to=''>
                  Forgot Password?
                </Link>
              </div>
            </div>
            <div className="signup-wrapper text-center">
              <Link className="toRegister" to='/AccountType/'>
                Don't have an account?{" "}
                <span className="text-primary">Create One</span>
              </Link>
            </div>
          </div>
        </div>
      </div>
      <NavBar />
    </div>
  );
}

export default Login;
