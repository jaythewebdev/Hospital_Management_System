import { Navigate } from "react-router-dom";

function PatientProfileProtected({token,role,children})
{
    role=localStorage.getItem("role");
    token=localStorage.getItem("token");
    if(token!=null && role=="Patient")
        return children;
    else {
            localStorage.clear();
            return <Navigate to='/Error'/>;
        }}

export default PatientProfileProtected;