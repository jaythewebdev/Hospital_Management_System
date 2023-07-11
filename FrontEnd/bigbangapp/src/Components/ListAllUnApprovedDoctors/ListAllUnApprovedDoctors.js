import React, { useState, useEffect } from "react";
import AdminNavBar from "../AdminNavbar/AdminNavbar";
import '../ListAllApprovedDoctors/ListAllApprovedDoctors.css';
import './ListAllUnApprovedDoctors.css'
import Tab from "../Tab/Tab";


function ListAllUnApprovedDoctors() {
  const [patients, setPatients] = useState([]);

  const viewPatients = () => {
    fetch("https://localhost:7235/api/Admin/View_All_UnApproved_Doctors", {
      method: "GET",
      headers: {
        accept: "text/plain",
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      },
    })
      .then(async (data) => {
        if (data.status >= 200 && data.status <= 300) {
          var myData = await data.json();
          console.log(myData);
          setPatients(myData);
        }
      })
      .catch((err) => {
        console.log(err.error);
      });
  };

  useEffect(() => {
    viewPatients();
  }, []);

  const handleClick = async (doctorId) => {
    const statusDTO = {
      id: doctorId,
      status: "Approved",
    };

    console.log(statusDTO);
    await unApproveDoctor(statusDTO);
    viewPatients();
  };

  const unApproveDoctor = async (statusDTO) => {
    try {
      const response = await fetch(
        "https://localhost:7235/api/Admin/Update_Doctor_Status",
        {
          method: 'PUT',
          body: JSON.stringify(statusDTO),
          headers: {
            accept: "text/plain",
            "Content-Type": "application/json",
            'Authorization': 'Bearer ' + localStorage.getItem('token')
          },
        }
      );
      if (response.ok) {
        const data = await response.json();
        console.log(data);
      } else {
        throw new Error('Failed to Unapprove doctor');
      }
    } catch (error) {
      console.error(error);
    }
  };

  const handleDelete = async (doctorId) => {
    try {
      const response = await fetch(
        "https://localhost:7235/api/Admin/Delete_Doctor?key="+doctorId,
        {
          method: 'DELETE',
          headers: {
            accept: 'text/plain',
            'Authorization': 'Bearer ' + localStorage.getItem('token')
          },
        }
      );
      if (response.ok) {
        // Doctor deleted successfully
        const data = await response.json();
        console.log(data);
        viewPatients();
      } else {
        throw new Error('Failed to delete doctor');
      }
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="unapprove-list">
        <Tab/>
        <div>
      <h2 className="pat-tbl-head">Pending Requests</h2>
      <div className="patient-table">
        <table className="fl-table">
          <thead>
            <tr>
              <th>DoctorId</th>
              <th>Name</th>
              <th>PhoneNumber</th>
              <th>Specialization</th>
              <th>Experience(Yrs)</th>
              <th>Approval</th>
              <th>Remove</th>
            </tr>
          </thead>
          <tbody>
            {patients.map((user) => (
              <tr key={user.doctorId}>
                <td>{user.doctorId}</td>
                <td>{user.name}</td>
                <td>{user.phoneNumber}</td>
                <td>{user.specialization}</td>
                <td>{user.experience}</td>
                <td>
                  <div className="approve-button" onClick={() => handleClick(user.doctorId)}>
                    Approve
                  </div>
                </td>
                <td>
                  <div className="Delete-button" onClick={() => handleDelete(user.doctorId)}>
                    Delete
                  </div>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <AdminNavBar />
    </div>
    </div>
  );
}

export default ListAllUnApprovedDoctors;
