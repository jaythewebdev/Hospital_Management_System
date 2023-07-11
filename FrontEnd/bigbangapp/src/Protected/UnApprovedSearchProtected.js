import { Navigate } from "react-router-dom";

function UnApprovedSearchProtected({token,role,children})
{
    role=localStorage.getItem("role");
    token=localStorage.getItem("token");
    if(token!=null && role=="Admin")
        return children;
    else {
        localStorage.clear();
        return <Navigate to='/Error'/>;
    }
}

export default UnApprovedSearchProtected;