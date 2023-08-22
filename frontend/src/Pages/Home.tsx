import { AppBar, Toolbar, Typography, IconButton, Button, Box } from '@mui/material';
import { styled } from '@mui/material/styles';
import ShoppingBagOutlinedIcon from '@mui/icons-material/ShoppingBagOutlined';
import LightModeOutlinedIcon from '@mui/icons-material/LightModeOutlined';
import { Link } from 'react-router-dom';
import useAppSelector from '../Hooks/useAppSelector';
import { Login } from '@mui/icons-material';


const Logo = styled(Typography)(({ theme }) => ({
    marginRight: theme.spacing(10),
  }));
  
  const NavLinks = styled(Box)(({ theme }) => ({
    flexGrow: 1,
    display: 'flex',
    justifyContent: 'center',
  }));
  
  const Profile = styled('div')({
    display: 'flex',
    alignItems: 'center',
  });
  
  interface HeaderProps {
    handleClickOpen: () => void;
  }

const Home = () => {
  return (
        <AppBar
        elevation={0}
        position='static'
        sx={{
          color:'black',
          background:'white',
          height:'5rem',
          padding:'1.5rem'
        }}
        >
            <Toolbar 
        sx={{ 
          justifyContent: 'space-between',
          alignItems:'center'
       }}
       >
        <Logo>
          <Typography
            align='center'
          >
            Comerce.js
          </Typography>
        </Logo>
        <NavLinks>
          <Button color="inherit" component={Link} to="/">Home</Button>
          <Button color="inherit" component={Link} to="/products">Shops</Button>
          <Button color="inherit" component={Link} to="/profile">Profile</Button>
        </NavLinks>
        <Profile>
          <IconButton color="inherit">
          <Login />
          </IconButton>
          <IconButton color="inherit">
              <ShoppingBagOutlinedIcon />
              {/* {items.length} */}
          </IconButton>
          <IconButton color="inherit">
            <LightModeOutlinedIcon />
          </IconButton>
        </Profile>
      </Toolbar>
        </AppBar> 
  )
}

export default Home