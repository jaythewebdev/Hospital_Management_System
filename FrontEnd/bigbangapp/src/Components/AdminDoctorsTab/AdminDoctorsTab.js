import React from "react";
import AdminNavBar from "../AdminNavbar/AdminNavbar";
import Tab from "../Tab/Tab";
import './AdminDoctorsTab.css'


function AdminDoctorsTab() {
  return (
    <div className="docTab">
        <Tab/>
        <AdminNavBar/>
    </div>
  );
}

export default AdminDoctorsTab;
