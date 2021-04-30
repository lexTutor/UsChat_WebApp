import React, { useState } from 'react';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import { Button} from '@material-ui/core';
import DashboardIcon from '@material-ui/icons/Dashboard';
import SearchIcon from '@material-ui/icons/Search';
import TextField from '@material-ui/core/TextField';

const  MainListItems = ({handleSearch }= this.props) => {

    const [Search, setSearch] = useState("");

    const handleChange = (e) => {
        setSearch(e.target.value);
    }

    return (
        <>
        <div>
        <ListItem>
            <ListItemIcon>
                <DashboardIcon />
            </ListItemIcon>
            <ListItemText primary="Dashboard" />
        </ListItem>
        <ListItem button>
            <ListItemIcon>
                <SearchIcon />
            </ListItemIcon>
          
            <ListItemText primary="Search" />
        </ListItem>
        <ListItem >
            <TextField
                variant="standard"
                margin="normal"
                required
                fullWidth
                name="search"
                label="search"
                type="search"
                id="search"
                required
                onChange={handleChange}
            />
        </ListItem>
            </div>
            <Button
                size="medium"
                variant="contained"
                color="primary"
                onClick={() => handleSearch(Search)}
                style={{ backgroundColor: "#1f2667bf" }}
            >
                Add
       </Button>
            </>);
  };

export default MainListItems;
