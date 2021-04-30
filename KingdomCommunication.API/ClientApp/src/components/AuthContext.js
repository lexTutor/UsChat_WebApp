import React from "react";

const AuthContext = React.createContext({
    isAuthenticated: false,
    setAuthenticated: () => { }
});
export default AuthContext;