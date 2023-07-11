import { Navigate } from "react-router-dom";

function DoctorProfileProtected({token,role,children})
{
    role=localStorage.getItem("role");
    token=localStorage.getItem("token");
    if(token!=null && role=="Doctor")
        return children;
    else {
            localStorage.clear();
            return <Navigate to='/Error'/>;
        }
}

export default DoctorProfileProtected;