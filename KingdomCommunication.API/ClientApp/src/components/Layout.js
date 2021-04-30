import React, { useState } from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import AuthContext from './AuthContext';

export default function Layout(props) {
    const [isAuthenticated, setAuthenticated] = useState(false);

    return (
        <AuthContext.Provider value={{ isAuthenticated, setAuthenticated }}>
            
                <NavMenu />
                <Container>
                    {props.children}
                </Container>
        </AuthContext.Provider>
    );
};
