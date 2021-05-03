import React, { useEffect, useContext } from 'react';
import clsx from 'clsx';
import { makeStyles } from '@material-ui/core/styles';
import CssBaseline from '@material-ui/core/CssBaseline';
import Drawer from '@material-ui/core/Drawer';
import List from '@material-ui/core/List';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import IconButton from '@material-ui/core/IconButton';
import Container from '@material-ui/core/Container';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Link from '@material-ui/core/Link';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import MainListItems from './Networking';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import DashboardIcon from '@material-ui/icons/Dashboard';
import PersonIcon from '@material-ui/icons/Person';
import UserDetails from './UserDetails';
import { useParams, useHistory } from 'react-router-dom';
import { Card, TextField, Button } from '@material-ui/core';
import ChatDiv from '../StyledComponents/ChatDiv';
//import AuthContext from './AuthContext';
import * as signalR from "@microsoft/signalr";

function Copyright() {
    return (
        <Typography variant="body2" color="textSecondary" align="center">
            {'Copyright © '}
            <Link color="inherit" href="https://material-ui.com/">
                Your Website
      </Link>{' '}
            {new Date().getFullYear()}
            {'.'}
        </Typography>
    );
}

const drawerWidth = 240;

const useStyles = makeStyles((theme) => ({

    card: {
        padding: "100px",
        marginLeft: "auto",
        marginRight: "auto",
        marginTop: "10px",
        backgroundColor: "white",
    },
    button: {
        marginLeft: "20px",
        marginTop: "30px",
        alignSelf: "center",
    },
    root: {
        display: 'flex',
    },
    toolbar: {
        paddingRight: 24, // keep right padding when drawer closed
    },
    toolbarIcon: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'flex-end',
        padding: '0 8px',
        ...theme.mixins.toolbar,
    },
    appBar: {
        zIndex: theme.zIndex.drawer + 1,
        transition: theme.transitions.create(['width', 'margin'], {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.leavingScreen,
        }),
    },
    appBarShift: {
        marginLeft: drawerWidth,
        width: `calc(100% - ${drawerWidth}px)`,
        transition: theme.transitions.create(['width', 'margin'], {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.enteringScreen,
        }),
    },
    menuButton: {
        marginRight: 36,
    },
    menuButtonHidden: {
        display: 'none',
    },
    title: {
        flexGrow: 1,
    },
    drawerPaper: {
        position: 'relative',
        whiteSpace: 'nowrap',
        width: drawerWidth,
        transition: theme.transitions.create('width', {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.enteringScreen,
        }),
    },
    drawerPaperClose: {
        overflowX: 'hidden',
        transition: theme.transitions.create('width', {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.leavingScreen,
        }),
        width: theme.spacing(7),
        [theme.breakpoints.up('sm')]: {
            width: theme.spacing(9),
        },
    },
    appBarSpacer: theme.mixins.toolbar,
    content: {
        flexGrow: 1,
        height: '100vh',
        overflow: 'auto',
    },
    container: {
        paddingTop: theme.spacing(4),
        paddingBottom: theme.spacing(4),
    },
    paper: {
        padding: theme.spacing(2),
        display: 'flex',
        overflow: 'auto',
        flexDirection: 'column',
    },
    fixedHeight: {
        height: 240,
    },
}));

export default function Dashboard() {
    const classes = useStyles();
    const [open, setOpen] = React.useState(true);
    const [Data, setData] = React.useState(true);
    const [messages, setMessages] = React.useState([{ userFromId: 1, messageDetails: "Start Chat" }]);
    const [newMessage, setNewMessage] = React.useState("");
    const [Update, setUpdate] = React.useState(true);
    const [chatWith, setChatWith] = React.useState("");
    const { Id } = useParams();
    const [recieved, setrecieved] = React.useState(null);
    const history = useHistory();
    //const { isAuthenticated, SetAuthenticated } = useContext(AuthContext);
    const hubConnection = new signalR.HubConnectionBuilder().withUrl(`/ChatHub/${Id}`,
        {
            accessTokenFactory: () => {
                return `${Id}`;
            }
        }).build();


    useEffect(() => {

    }, [messages]);


    useEffect(() => {
        hubConnection.start();
        fetch(`user/get/${Id}`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${Id}`
            },
        }).then((res) => {
            return res.json();
        }).then((data) => {
            if (data.success === false) {
                history.push("")
            }
            else {
                setData(data.data);
            }
        });
    },
        [Update]);

    useEffect(() => {

        if (recieved !== null) {
            console.log("recieved")
            let msgs = [...messages];
            msgs.push(recieved)
            setMessages(msgs);
        }
    }, [recieved])

    const handleReload = () => {
        fetch(`user/get/${Id}`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${Id}`
            },
        }).then((res) => {
            return res.json();
        }).then((data) => {
            if (data.success === false) {
            }
            else {
                setData(data.data);
            }
        });
    }

    const handleDrawerOpen = () => {
        setOpen(true);
    };

    const handleDrawerClose = () => {
        setOpen(false);
    };

    const handleConnect = (id1, id2) => {
        let withId = Id === id1 ? id2 : id1;
        setChatWith(withId);
        fetch(`message/get/${id1}/${id2}`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${Id}`
            },
        }).then((res) => {
            return res.json();
        }).then((data) => {
            if (data === null || data === undefined) {
                return;
            }
            else {
                let nm = [...messages];
                nm.push(data.data);
                setMessages(data.data);
            }
        });
    }

    const handleSearch = (search) => {
        let obj = { UserName_To: search }
        fetch(`connection/add/${Id}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${Id}`
            },
            body: JSON.stringify(obj),
        }).then((res) => {
            if (!res.ok) { return; }
            return res.json();
        }).then((data) => {
            if (data === null || data === undefined) {
                alert("UserName not found")
            }
            else { setUpdate(!Update); }
        });
    };

    const handleChange = (e) => {
        setNewMessage(e.target.value);
    }

    const SendMessage = () => {
        if (chatWith !== "" && chatWith !== null) {
            let obj = { userFromId: Id, userToId: chatWith, MessageDetails: newMessage }
            fetch(`message/add/${Id}`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": `Bearer ${Id}`
                },
                body: JSON.stringify(obj),
            }).then((res) => {
                if (!res.ok) { return; }
                return res.json();
            }).then((data) => {
                if (data === null || data === undefined) {
                    alert("Message not sent")
                    return;
                }
                else {
                    setNewMessage("");
                }
            });
        }
        else {
            alert("select a connection to send a message");
        }
    }

    hubConnection.on("ReceieveMessage", (message) => {
        setrecieved(message);
    });

    const fixedHeightPaper = clsx(classes.paper, classes.fixedHeight);
    //onLoad={() => SetAuthenticated(true)}
    return (
        <div className={classes.root} >
            <CssBaseline />
            <Drawer
                variant="permanent"
                classes={{
                    paper: clsx(classes.drawerPaper, !open && classes.drawerPaperClose),
                }}
                open={open}
            >
                <div className={classes.toolbarIcon}>
                    {open && <IconButton onClick={handleDrawerClose}>
                        <ChevronLeftIcon />
                    </IconButton>}
                    {!open && <IconButton onClick={handleDrawerOpen}>
                        <ChevronRightIcon />
                    </IconButton>}
                </div>
                <List> {<MainListItems handleSearch={handleSearch} />}
                </List>
                <Divider />
                <ListItem>
                    <ListItemIcon>
                        <DashboardIcon />
                    </ListItemIcon>
                    <ListItemText primary="My Network" />
                </ListItem>

                {Data.connections && <List>{Data.connections.map((data) => (
                    <ListItem key={data.userId_To} >
                        <ListItemIcon>
                            <PersonIcon />
                        </ListItemIcon>
                        {(Data.username.toLowerCase() !== data.userName_To.toLowerCase()) &&
                            <ListItemText primary={data.userName_To} onClick={() => handleConnect(data.userId_To, data.userId_From)}></ListItemText>}
                        {(Data.username.toLowerCase() !== data.userName_From.toLowerCase()) &&
                            <ListItemText primary={data.userName_From} onClick={() => handleConnect(data.userId_To, data.userId_From)}></ListItemText>}
                        {console.log(Data.userName)}
                        {console.log(data.userName_To)}
                        {console.log(data.userName_From)}
                    </ListItem>
                ))}</List>}
                <Divider />
            </Drawer>
            <main className={classes.content}>
                <div className={classes.appBarSpacer} />
                <Container maxWidth="lg" className={classes.container}>
                    <Grid container spacing={3} className={classes.root} style={{ justifyContent: "space-between" }}>
                        <Grid>
                            <Card visibility="hidden" id="msgCard" className={classes.card}>
                                {messages.map((msg) => (
                                    <ChatDiv key={msg.userFromId} main={msg.userFromId === Id ? 1 : 2}>
                                        {msg.messageDetails}
                                    </ChatDiv>
                                ))}
                                <TextField
                                    id="standard-secondary"
                                    label="Message"
                                    color="secondary"
                                    required
                                    value={newMessage}
                                    onChange={handleChange}
                                />
                                <Button
                                    size="small"
                                    variant="contained"
                                    color="primary"
                                    className={classes.button}
                                    onClick={SendMessage}
                                    style={{ backgroundColor: "#1f2667bf" }}
                                >
                                    Send
                                </Button>
                            </Card>
                        </Grid>
                        <Grid item xs={12} md={4} lg={3}>
                            <Paper className={fixedHeightPaper} style={{ width: "200px", height: "400px" }}>
                                <UserDetails data={Data} OnReload={handleReload}/>
                            </Paper>
                        </Grid>
                    </Grid>
                </Container>
            </main>
        </div>
    );
}