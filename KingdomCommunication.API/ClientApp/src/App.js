import React, { useState } from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import DashBoard from './components/MainDashBoard';
import { FetchData } from './components/FetchData';
import Login from './components/Login';
import SignUp from './components/SignUp'
import AuthContext from './components/AuthContext';
import './custom.css'

export default function App() {
    const [isAuthenticated, setAuthenticated] = useState(false);

        return (
            <AuthContext.Provider value={{ isAuthenticated, setAuthenticated }}>
                <Layout>
                <Route exact path='/' component={Login} />
                <Route path='/Dashboard/:Id' component={DashBoard} />
                <Route path='/SignUp' component={SignUp} />
                <Route path='/Weather' component={FetchData} />
            </Layout>
            </AuthContext.Provider>
        );
};
