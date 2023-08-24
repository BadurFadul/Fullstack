import { useState } from 'react';
import { AppBar, Toolbar, Typography, IconButton, Button, Box, Menu, Container, Tooltip, MenuItem, List, Divider, ListItemButton, ListItem, ListItemIcon, ListItemText, Drawer  } from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';
import Avatar from '@mui/material/Avatar';
import AdbIcon from '@mui/icons-material/Adb';
import HomeIcon from '@mui/icons-material/Home';
import BusinessIcon from '@mui/icons-material/Business';
import { Link, Outlet } from 'react-router-dom';
import ContactMailIcon from '@mui/icons-material/ContactMail';
import AccountCircle from '@mui/icons-material/AccountCircle';

import ShoppingBagOutlinedIcon from '@mui/icons-material/ShoppingBagOutlined';
import LightModeOutlinedIcon from '@mui/icons-material/LightModeOutlined';
import useAppSelector from '../Hooks/useAppSelector';

const pages = ['Products', 'Pricing', 'Blog'];
const settings = ['Profile', 'Account', 'Dashboard', 'Logout'];

const logo = 'src\Assets\bador.png'

interface HeaderProps {
  handleClickOpen: () => void;
}

const Home = ({handleClickOpen} : HeaderProps) => {
  const [state, setState] = useState(false)
  const [anchorElNav, setAnchorElNav] = useState<null | HTMLElement>(null);
  const [anchorElUser, setAnchorElUser] = useState<null | HTMLElement>(null);

  const items = useAppSelector(state => state.cardReducer.items);

  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const toggleDrawer = () => {
    setState(!state);
  }

  const Listitems = () => (
    <List sx={{width: '220px', color: 'black' }}>
      <Box sx={{ display: 'flex', alignItems: 'center', marginBottom: '7.3px', }}>
      <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2, marginLeft: '2px' }}
            onClick={toggleDrawer}
            
          >
            <MenuIcon sx={{color: 'black'}}/>
          </IconButton>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Breweries-App
          </Typography>
      </Box>
          <Divider/>
          <ListItem sx={{}}>
            <ListItemButton component={Link} to="/" onClick={toggleDrawer}>
              <ListItemIcon>
                <HomeIcon sx={{color: 'black'}}/>
              </ListItemIcon>
              <ListItemText primary="Home" />
            </ListItemButton>
          </ListItem>
          <ListItem>
            <ListItemButton component={Link} to="/products" onClick={toggleDrawer}>
              <ListItemIcon>
                <BusinessIcon sx={{color: 'black'}}/>
              </ListItemIcon>
              <ListItemText primary="Companies" />
            </ListItemButton>
          </ListItem>
          <ListItem>
            <ListItemButton component={Link} to="/contact" onClick={toggleDrawer}>
              <ListItemIcon>
                <ContactMailIcon sx={{color: 'black'}}/>
              </ListItemIcon>
              <ListItemText primary="Contact" />
            </ListItemButton>
          </ListItem>
        </List>
  )

  return (
    <Box>
      <AppBar position='static'
        elevation={0}
        sx={{
          color:'black',
          background:'white',
          height:'5rem',
          padding:'1.5rem'
        }}
      >
      <Container maxWidth='xl'>
        <Toolbar disableGutters>
          {/* <AdbIcon sx={{ display: { xs: 'none', md: 'flex' }, mr: 1 }} /> */}
          {/* <img
              style={{ display: 'none' }}
              src={logo}
              alt="increase priority"
          /> */}
        <Typography
            variant="h6"
            noWrap
            component="a"
            href="/"
            sx={{
              mr: 2,
              display: { xs: 'none', md: 'flex' },
              fontFamily: 'monospace',
              fontWeight: 700,
              letterSpacing: '.3rem',
              color: 'inherit',
              textDecoration: 'none',
            }}
          >
            E-Commerce
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}>
            <IconButton
                size="large"
                edge="start"
                color="inherit"
                aria-label="menu"
                sx={{ mr: 2 }}
                onClick={toggleDrawer}
              >
            <MenuIcon />
          </IconButton>
          <Menu
              id="menu-appbar"
              anchorEl={anchorElNav}
              anchorOrigin={{
                vertical: 'bottom',
                horizontal: 'left',
              }}
              keepMounted
              transformOrigin={{
                vertical: 'top',
                horizontal: 'left',
              }}
              open={Boolean(anchorElNav)}
              onClose={handleCloseNavMenu}
              sx={{
                display: { xs: 'block', md: 'none' },
              }}
            >
            </Menu>
          </Box>
          <Typography
            variant="h5"
            noWrap
            component="a"
            href="/"
            sx={{
              mr: 2,
              display: { xs: 'flex', md: 'none' },
              flexGrow: 1,
              fontFamily: 'monospace',
              fontWeight: 700,
              letterSpacing: '.3rem',
              color: 'inherit',
              textDecoration: 'none',
            }}
          >
            E-Commerce
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
              <Button color="inherit" component={Link} to="/">Home</Button>
              <Button color="inherit" component={Link} to="/products">Shops</Button>
              <Button color="inherit" component={Link} to="/profile">Contact</Button>
          </Box>
          <Box sx={{ flexGrow: 0 }}>
          <IconButton color="inherit">
          </IconButton>
          <IconButton color="inherit" onClick={handleClickOpen} >
              <ShoppingBagOutlinedIcon />
              {items.length}
          </IconButton>
          <IconButton color="inherit">
            <LightModeOutlinedIcon  />
          </IconButton>
            <Tooltip title="Open settings">
              <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                <AccountCircle/>
              </IconButton>
            </Tooltip>
            
            <Menu
              sx={{ mt: '45px' }}
              id="menu-appbar"
              anchorEl={anchorElUser}
              anchorOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              keepMounted
              transformOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              open={Boolean(anchorElUser)}
              onClose={handleCloseUserMenu}
            >
              {settings.map((setting) => (
                <MenuItem key={setting} onClick={handleCloseUserMenu}>
                  <Typography textAlign="center">{setting}</Typography>
                </MenuItem>
              ))}
            </Menu>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
    <Drawer
        anchor='left'
        open={state}
        onClose={toggleDrawer}
        sx={{ 
          '& .MuiDrawer-paper': { backgroundColor: 'white' },
          color:'black',
         }} 
      >
        <Box
        >
          {Listitems()}
        </Box>

      </Drawer>
  </Box>
  )
}

export default Home