import React from "react";
import "./ListPatients.css";
import { useState, useEffect } from "react";
import { toast } from "react-toastify";
import AdminNavBar from "../AdminNavbar/AdminNavbar";
import '../UnApprovedSearchBar/UnApprovedSearch.css'
import "../ApprovedSearchBar/search.css";


function ListPatients() {
  const [searchQuery, setSearchQuery] = useState("");
  const [data, setData] = useState([]);

  const handleChange = (event) => {
    setSearchQuery(event.target.value);
  };

  const handleSearch = async () => {
    if (searchQuery === "") {
      viewPatients();
    } else {
      try {
        const response = await fetch(
          `https://localhost:7235/api/Admin/Search_Patient_By_Name?name=${searchQuery}`,
          {
            method: "GET",
            headers: {
              accept: "text/plain",
              'Authorization': 'Bearer ' + localStorage.getItem('token')
            },
          }
        );
        if (response.ok) {
          const data = await response.json();
          const filteredData = data.filter((user) =>
            user.name.toLowerCase().includes(searchQuery.toLowerCase())
          );
          setData(filteredData);
          console.log(filteredData);
        } else {
          setData([]);
          toast.error("No Patients match your search.");
          console.error("Failed to get patints by name");
        }
      } catch (error) {
        console.error(error);
      }
    }
  };
  

  const viewPatients = () => {
    fetch("https://localhost:7235/api/Admin/View_All_Patients", {
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
          setData(myData);
        }
      })
      .catch((err) => {
        console.log(err.error);
      });
  };

  useEffect(() => {
    viewPatients();
  }, []);

  useEffect(() => {
    const timer = setTimeout(() => {
      handleSearch();
    }, 500); // Delay of 500ms before making the API call
    return () => clearTimeout(timer);
  }, [searchQuery]);

  return (
    <div className="search-container">
  <h2 className="pat-tbl-head">Patients</h2>
    <div className="search-table">
      <div >
        <div className="search-bar">
        <input
          type="text"
          placeholder="Search Name"
          id="search-input"
          value={searchQuery}
          onChange={handleChange}
        />
        </div>
      </div>

      <div>
        <div className="patient-table">
          <table className="fl-table">
            <thead>
              <tr>
              <th>PatientId</th>
            <th>Name</th>
            <th>D.O.B</th>
            <th>Gender</th>
            <th>Phone</th>
            <th>Email</th>
            <th>Blood Group</th>
              </tr>
            </thead>
            <tbody>
              {data.length === 0 ? (
                <tr id="col">
                  <td colSpan="7">No data available</td>
                </tr>
              ) : (
                data.map((user) => (
                  <tr key={user.patientId}>
                            <td>{user.patientId}</td>
                            <td>{user.name}</td> 
                            <td>{user.dateOfBirth}</td>
                            <td>{user.gender}</td>
                            <td>{user.phoneNumber}</td>
                            <td>{user.emailId}</td>
                            <td>{user.bloodType}</td> 
                  </tr>
                ))
              )}
            </tbody>
          </table>
        </div>
      </div>
      </div>
      <AdminNavBar/>
    </div>
  );
}

export default ListPatients;
