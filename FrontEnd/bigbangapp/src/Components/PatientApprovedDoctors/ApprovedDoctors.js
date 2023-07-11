import React, { useState, useEffect } from "react";
import AdminNavBar from "../AdminNavbar/AdminNavbar";
import '../ListAllApprovedDoctors/ListAllApprovedDoctors.css';
import PatientNavBar from "../PatientNavbar/PatientNavbar";
import { toast } from "react-toastify";
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
        const responseByName = await fetch(
          `https://localhost:7235/api/Admin/Search_By_Name?name=${searchQuery}`,
          {
            method: "GET",
            headers: {
              accept: "text/plain",
              'Authorization': 'Bearer ' + localStorage.getItem('token')
            },
          }
        );
  
        const responseBySpeciality = await fetch(
          `https://localhost:7235/api/Admin/Search_By_Specialization?name=${searchQuery}`,
          {
            method: "GET",
            headers: {
              accept: "text/plain",
              'Authorization': 'Bearer ' + localStorage.getItem('token')
            },
          }
        );
  
        if (responseByName.ok && responseBySpeciality.ok) {
          const dataByName = await responseByName.json();
          const dataBySpeciality = await responseBySpeciality.json();
          const combinedData = [...dataByName, ...dataBySpeciality];
  
          // Filter out duplicate entries by doctor's name
          const uniqueData = combinedData.reduce((acc, current) => {
            const existingEntry = acc.find(
              (entry) => entry.name === current.name
            );
            if (!existingEntry) {
              acc.push(current);
            }
            return acc;
          }, []);
  
          setData(uniqueData);
          console.log(uniqueData);
        } else if (responseByName.ok) {
          const dataByName = await responseByName.json();
          setData(dataByName);
          console.log(dataByName);
        } else if (responseBySpeciality.ok) {
          const dataBySpeciality = await responseBySpeciality.json();
          setData(dataBySpeciality);
          console.log(dataBySpeciality);
        } else {
          setData([]);
          toast.error("No doctors match your search.");
          console.error("Failed to get doctors by name or specialization");
        }
      } catch (error) {
        console.error(error);
      }
    }
  };
  

  const viewPatients = async () => {
    try {
      const response = await fetch(
        "https://localhost:7235/api/Patient/Get_All_Approved_Doctors",
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
        setData(data);
        console.log(data);
      } else {
        console.error("Failed to get all approved doctors");
      }
    } catch (error) {
      console.error(error);
    }
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
  <h1 className="pat-tbl-head">Doctors</h1>
    <div className="search-table">
      <div >
        <div className="search-bar">
        {/* <span className="search-icon"></span> */}
        <input
          type="text"
          placeholder="Search Name / Specialization"
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
              <th>DoctorId</th>
              <th>Name</th>
              <th>PhoneNumber</th>
              <th>Specialization</th>
              <th>Experience(Yrs)</th>
              </tr>
            </thead>
            <tbody>
              {data.length === 0 ? (
                <tr id="col">
                  <td colSpan="5">No data available</td>
                </tr>
              ) : (
                data.map((user) => (
                  <tr key={user.doctorId}>
                <td>{user.doctorId}</td>
                <td>{user.name}</td>
                <td>{user.phoneNumber}</td>
                <td>{user.specialization}</td>
                <td>{user.experience}</td>
                  </tr>
                ))
              )}
            </tbody>
          </table>
        </div>
      </div>
      </div>
      <PatientNavBar />
    </div>
  );
}

export default ListPatients;
