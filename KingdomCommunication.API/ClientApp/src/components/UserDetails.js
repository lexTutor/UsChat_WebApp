import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography';
import Title from './Title';

const useStyles = makeStyles({
    depositContext: {
        flex: 1,
    },
});

export default function UserDetails({ data } = this.props) {
    const classes = useStyles();
    var today = new Date();

    return (
        <React.Fragment>
            <Title>Welcome</Title>
            <Typography component="p" variant="h4">
                {data.userName}
      </Typography>
            <Typography color="textSecondary" className={classes.depositContext}>
                {today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds()}
      </Typography>
          
        </React.Fragment>
    );
}