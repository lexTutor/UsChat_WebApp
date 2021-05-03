import React, { useState, useContext } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import AuthContext from './AuthContext';

export default function NavMenu() {
    const [collapsed, setCollapsed] = useState(true);
    const {context} = useContext(AuthContext);

    const toggleNavbar = () => {
        setCollapsed(!collapsed);
    }
    return (
        <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                <Container>
                    <NavbarBrand tag={Link} to="/">UsChat.com</NavbarBrand>
                    <NavbarToggler onClick={toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/">Login</NavLink>
                            </NavItem>
                            {context && <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/Dashboard/:Id">DashBoard</NavLink>
                            </NavItem>}
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/SignUp">SignUp</NavLink>
                            </NavItem>
                        </ul>
                    </Collapse>
                </Container>
            </Navbar>
        </header>
        );
    }
