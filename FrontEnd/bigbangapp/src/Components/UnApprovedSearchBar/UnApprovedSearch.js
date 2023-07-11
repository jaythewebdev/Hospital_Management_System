import React, { useState, useEffect } from "react";
import AdminNavBar from "../AdminNavbar/AdminNavbar";
import "../ListAllApprovedDoctors/ListAllApprovedDoctors.css";
import "../ApprovedSearchBar/search.css";
import { toast } from "react-toastify";
import AdminDoctorsTab from "../AdminDoctorsTab/AdminDoctorsTab";
import './UnApprovedSearch.css'
import Tab from "../Tab/Tab";


function UnApprovedSearch() {
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
            `https://localhost:7235/api/Admin/Search_By_Name_UnApproved?name=${searchQuery}`,
            {
              method: "GET",
              headers: {
                accept: "text/plain",
                'Authorization': 'Bearer ' + localStorage.getItem('token')
              },
            }
          );
    
          const responseBySpeciality = await fetch(
            `https://localhost:7235/api/Admin/Search_By_Specialization_UnApproved?name=${searchQuery}`,
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
          "https://localhost:7235/api/Admin/View_All_UnApproved_Doctors",
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
  
    const handleClick = async (doctorId) => {
      const statusDTO = {
        id: doctorId,
        status: "Approved",
      };
      console.log(statusDTO);
      await unApproveDoctor(statusDTO);
      await viewPatients();
      setSearchQuery(""); // Reset the search query
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
          toast.success("Doctor Unapproved successfully..")
        } else {
          toast.error("Failed to Unapprove doctor..")
          console.error('Failed to Unapprove doctor');
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
          toast.success("Doctor deleted successfully..")
          await viewPatients();
          setSearchQuery(""); // Reset the search query
        } else {
          console.error('Failed to delete doctor');
          console.error('Failed to delete doctor');
        }
      } catch (error) {
        console.error(error);
      }
    };

  return (
<div className="search-container">
  {/* <h2 className="pat-tbl-head">Doctors</h2> */}
<div>
    <Tab/>
</div>
    <div className="search-table">
      <div >
        <div className="search-bar">
        <input
          type="text"
          placeholder="Search  Name / Specialization"
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
                <th>Approval</th>
                <th>Remove</th>
              </tr>
            </thead>
            <tbody>
              {data.length === 0 ? (
                <tr id="col">
                  <td colSpan="7">No data available</td>
                </tr>
              ) : (
                data.map((user) => (
                  <tr key={user.doctorId}>
                    <td>{user.doctorId}</td>
                    <td>{user.name}</td>
                    <td>{user.phoneNumber}</td>
                    <td>{user.specialization}</td>
                    <td>{user.experience}</td>
                    <td>
                      {/* <div className="view-button">Disapprove</div> */}
                      <div className="approve-button" onClick={() => handleClick(user.doctorId)}>
                    Approve
                  </div>
                    </td>
                    <td>
                      {/* <div className="Delete-button">Delete</div> */}
                      <div className="Delete-button" onClick={() => handleDelete(user.doctorId)}>
                    Delete
                  </div>
                    </td>
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

export default UnApprovedSearch;
