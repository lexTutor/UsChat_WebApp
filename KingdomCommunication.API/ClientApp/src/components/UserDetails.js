import React, { useState, useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography';
import Title from './Title';
import { Button } from '@material-ui/core';
import AddAPhotoIcon from '@material-ui/icons/AddAPhoto';

const useStyles = makeStyles({
    depositContext: {
        flex: 1,
    },
    cusor :{
        cursor: "pointer"
    }
});

export default function UserDetails({ data, OnReload } = this.props) {
    const classes = useStyles();
    var today = new Date();
    const [image, setImage] = useState();

    const handleChange = e => {
        setImage(e.target.files[0]);
    }

    const handleCameraclick = e => {
        document.getElementById("image").click();
    }

    const handleUpload = e => {
        if (image !== null) {
            const formData = new FormData();
            formData.append('image', image);
            fetch(`user/image/${data.id}`, {
                mode: 'no-cors',
                method: "POST",
                body: formData
            }).then((res) => {
                return res.json();
            }).then((obj) => {
                if (obj === null || obj === undefined) {
                    setImage(null);
                    return;
                }
                else {
                    setImage(null);
                    setTimeout(() => {
                        OnReload();
                    }, 8000);
                }
            });
        }
    }

    return (
        <React.Fragment>
            <img src={`${data.imageUrl}`} alt="pic" style={{ borderRadius: "50%", width:"150px" }} />
            <Title>Welcome</Title>
            <Typography component="p" variant="h4">
                {data.username}
      </Typography>
            <Typography color="textSecondary" className={classes.depositContext}>
                {today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds()}
            </Typography>
            <input
                id="image"
                type="file"
                style={{ display:'None' }}
                onChange={handleChange}
            />
            <AddAPhotoIcon
                className={classes.cursor}
                size="medium"
                variant="contained"
                onClick={handleCameraclick}
                >
                Select Image
            </AddAPhotoIcon>
            {image && <label>{image.name}</label>}
            <Button
                size="small"
                variant="contained"
                color="primary"
                onClick={handleUpload}
                style={{ backgroundColor: "#1f2667bf" }}>
                Upload Image
            </Button>
        </React.Fragment>
    );
}