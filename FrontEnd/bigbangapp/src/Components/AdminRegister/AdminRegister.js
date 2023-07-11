import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "../Login/Login.css";
import "./AdminRegister.css";
import login from "../images/Admin-rafiki.png";
import AdminNavBar from "../AdminNavbar/AdminNavbar";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import emailjs from 'emailjs-com';
import emailjsConfig from './emailjs.config';
import { useEffect } from "react";


function AdminRegister() {
  const [admin, setAdmin] = useState({
    "user": {},
    "name": "",
    "phoneNumber": "",
    "emailId": ""
  });

  const navigate = useNavigate();

  const handleInputChange = (e) => {
    setAdmin({
      ...admin,
      [e.target.name]: e.target.value
    });
  };

  const register = () => {
    // Check if all fields are filled
    if (!admin.name || !admin.phoneNumber || !admin.emailId) {
      toast.warning("Please fill in all the fields");
      return;
    }
    fetch("https://localhost:7235/api/Admin/Admin_Registration", {
      method: "POST",
      headers: {
        accept: "text/plain",
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      },
      body: JSON.stringify({ ...admin, "admin": {} })
    })
      .then(async (data) => {
        var myData = await data.json();
        console.log(myData);
        toast.success("Registered Successfully");
        // Send email to the user
        const password = admin.name.substring(0, 2) + '1234';
        const templateParams = {
          to_name: admin.name,
          to_email: admin.emailId,
          subject: 'Account Created Successfully',
          message: `Your account has been successfully created!\n\nYour User Id is :${myData.userId}\n\nYour password is: ${password}\n\nPlease login with your email and the provided password.`
        };

        emailjs.send(
          emailjsConfig.serviceID,
          emailjsConfig.templateID,
          templateParams,
          emailjsConfig.userID
        )
          .then((response) => {
            console.log('Email sent successfully!', response.status, response.text);
            navigate("/AdminProfile");
          })
          .catch((error) => {
            console.error('Error sending email:', error);
            toast.error("Error occurred while sending email. Please try again.");
            navigate("/AdminProfile");
          });
      })
      .catch((err) => {
        toast.error("Error occured, Kindly retry again !!")
        console.log(err.error);
      });
  };

  return (
    <div>
      <div className="container">
        <div className="form-column">
          <div className="logo text-center">{/* <h1>Company Name</h1> */}</div>
          <div className="wrapper">
            <div className="inner-warpper text-center">
              <h2 className="title">Admin Registration</h2>
              <div className="input-group">
                <input
                  className="form-control"
                  name="name"
                  id="userName"
                  type="text"
                  placeholder="User Name"
                  required
                  value={admin.name}
                  onChange={handleInputChange}
                />
                <span className="lighting"></span>
              </div>
              <div className="input-group">
                <input
                  className="form-control"
                  name="phoneNumber"
                  id="adminphone"
                  type="phone"
                  placeholder="Phone Number"
                  required
                  value={admin.phoneNumber}
                  onChange={handleInputChange}
                />
              </div>
              <div className="input-group">
                <input
                  className="form-control"
                  name="emailId"
                  id="adminemail"
                  type="email"
                  placeholder="Email Id"
                  required
                  value={admin.emailId}
                  onChange={handleInputChange}
                />
              </div>
              <button id="login-btn" onClick={register}>
                Register
              </button>
            </div>
          </div>
        </div>
        <div className="image-column" id="admin-reg-img">
          <img src={login} alt="Admin" className="login-image" />
        </div>
      </div>
      <AdminNavBar />
    </div>
  );
}

export default AdminRegister;
