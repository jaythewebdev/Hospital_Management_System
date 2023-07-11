import "./App.css";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { Route, Routes } from "react-router-dom";
import { BrowserRouter } from "react-router-dom";
import Login from "./Components/Login/Login";
import AccountType from "./Components/Register/AccountType";
import AdminRegister from "./Components/AdminRegister/AdminRegister";
import PatientRegister from "./Components/PatientRegister/PatientRegister";
import DoctorRegister from "./Components/DoctorRegister/DoctorRegister";
import AdminProfile from "./Components/AdminProfile/AdminProfile";
import DoctorProfile from "./Components/DoctorProfile/DoctorProfile";
import PatientProfile from "./Components/PatientProfile/PatientProfile";
import UpdateDoctor from "./Components/UpdateDoctorProfile/UpdateDoctor";
import UpdatePatient from "./Components/UpdatePatientProfile/UpdatePatient";
import UnApproveProfile from "./Components/UnApprovedDoctor/UnApproveProfile";
import Home from "./Components/Home/Home";
import ListPatients from "./Components/ListPatients/ListPatients";
import ListAllApprovedDoctors from "./Components/ListAllApprovedDoctors/ListAllApprovedDoctors";
import ListAllUnApprovedDoctors from "./Components/ListAllUnApprovedDoctors/ListAllUnApprovedDoctors";
import AdminDoctorsTab from "./Components/AdminDoctorsTab/AdminDoctorsTab";
import ApprovedDoctors from "./Components/PatientApprovedDoctors/ApprovedDoctors";
import AdminDoctorsTabProtected from "./Protected/AdminDoctorsTabProtected";
import AdminProfileProtected from "./Protected/AdminProfileProtected";
import DoctorProfileProtected from "./Protected/DoctorProfileProtected";
import ListAllApprovedDoctorsProtected from "./Protected/ListAllApprovedDoctorsProtected";
import ListAllUnApprovedDoctorsProtected from "./Protected/ListAllUnApprovedDoctorsProtected";
import ListPatientsProtected from "./Protected/ListPatientsProtected";
import PatientApprovedDoctorsProtected from "./Protected/PatientApprovedDoctorsProtected";
import PatientProfileProtected from "./Protected/PatientProfileProtected";
import UpdateDoctorProtected from "./Protected/UpdateDoctorProtected";
import UpdatePatientProtected from "./Protected/UpdatePatientProtected";
import Search from "./Components/ApprovedSearchBar/Search";
import UnApprovedSearch from "./Components/UnApprovedSearchBar/UnApprovedSearch";
import PageNotFound from "./Components/Error/PageNotFound";
import ApprovedSearchBarProtected from "./Protected/ApprovedSearchBarProtected";
import UnApprovedSearchProtected from "./Protected/UnApprovedSearchProtected";
import PageNotFoundProtected from "./Protected/PageNotFoundProtected";


function App() {
  var token;
  var role;
  return (
    <div>
      <ToastContainer autoClose={1000}/>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="Login" element={<Login />} />
          <Route path="/AccountType/" element={<AccountType />} />
          <Route path="/DoctorRegister" element={<DoctorRegister />} />
          <Route path="/PatientRegister" element={<PatientRegister />} />
          <Route path="/AdminRegister" element={<AdminRegister />} />
          <Route path="/UnApproveProfile" element={<UnApproveProfile />} />

          <Route
            path="/AdminProfile"
            element={
              <AdminProfileProtected token={token} role={role}>
                <AdminProfile />
              </AdminProfileProtected>
            }
          />

          <Route
            path="/PatientProfile"
            element={
              <PatientProfileProtected token={token} role={role}>
                <PatientProfile />
              </PatientProfileProtected>
            }
          />
          <Route
            path="/DoctorProfile"
            element={
              <DoctorProfileProtected token={token} role={role}>
                <DoctorProfile />
              </DoctorProfileProtected>
            }
          />
          <Route
            path="/UpdatePatient"
            element={
              <UpdatePatientProtected token={token} role={role}>
                <UpdatePatient />
              </UpdatePatientProtected>
            }
          />
          <Route
            path="/UpdateDoctor"
            element={
              <UpdateDoctorProtected token={token} role={role}>
                <UpdateDoctor />
              </UpdateDoctorProtected>
            }
          />
          <Route
            path="/ListPatients"
            element={
              <ListPatientsProtected token={token} role={role}>
                <ListPatients />
              </ListPatientsProtected>
            }
          />
          <Route
            path="/ListAllUnApprovedDoctors"
            element={
              <ListAllUnApprovedDoctorsProtected token={token} role={role}>
                <ListAllUnApprovedDoctors />
              </ListAllUnApprovedDoctorsProtected>
            }
          />
          <Route
            path="/ListAllApprovedDoctors"
            element={
              <ListAllApprovedDoctorsProtected token={token} role={role}>
                <ListAllApprovedDoctors />
              </ListAllApprovedDoctorsProtected>
            }
          />
          <Route
            path="/AdminDoctorsTab"
            element={
              <AdminDoctorsTabProtected token={token} role={role}>
           
                <AdminDoctorsTab />
              </AdminDoctorsTabProtected>
            }
          />
          <Route
            path="/PatientApprovedDoctors"
            element={
              <PatientApprovedDoctorsProtected token={token} role={role}>
                <ApprovedDoctors />
              </PatientApprovedDoctorsProtected>
            }
          />
          <Route
            path="/Search"
            element={
               <ApprovedSearchBarProtected token={token} role={role}>
                <Search />
               </ApprovedSearchBarProtected>
            }
          />
                    <Route
            path="/UnApprovedSearch"
            element={
              <UnApprovedSearchProtected token={token} role={role}>
                <UnApprovedSearch/>
              </UnApprovedSearchProtected>
            }/>
            <Route
            path="/Error"
            element={
                <PageNotFound/>
            }
            />
        </Routes> 
      </BrowserRouter>
    </div>
  );
}

export default App;
