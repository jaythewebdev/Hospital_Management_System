import React from "react";
import "./Tab.css";
import { Link } from "react-router-dom";

function Tab() {
  return (
    <div>
      <h2 className="pat-tbl-head">Doctors</h2>
      <div className="tab-container">
        <div className="tab-buttons">
          <Link to="/Search" className="tab-button">
            <div>View Doctors</div>
          </Link>
          <Link to="/UnApprovedSearch" className="tab-button">
            <div>Requests</div>
          </Link>
        </div>
      </div>
    </div>
  );
}

export default Tab;
