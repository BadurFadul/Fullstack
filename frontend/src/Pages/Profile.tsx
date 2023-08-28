import React from 'react';
import useAppSelector from '../Hooks/useAppSelector';
import useAppDispatch from '../Hooks/useAppDispatch';
import { Avatar, Box, Container, Grid, List, ListItem, ListItemText, Typography } from '@mui/material';

const Profile = () => {
  const authenticatedUser = useAppSelector(state => state.userReducer.currentUser);

  return (
    <Container maxWidth="md">
      <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', p: 4 }}>
        <Grid container spacing={3}>
          <Grid item xs={12} md={6}>
            {/* Left Half: Profile Picture */}
            <Box sx={{ display: 'flex', justifyContent: 'center' }}>
              <Avatar alt="Avatar" sx={{ width: 150, height: 150 }} />
            </Box>
          </Grid>
          <Grid item xs={12} md={6}>
            {/* Right Half: Information */}
            <Box>
              <Typography variant="h4" gutterBottom>
                Profile Information
              </Typography>
              <List>
                <ListItem>
                  <ListItemText primary={`First Name: ${authenticatedUser?.firstName}`} />
                </ListItem>
                <ListItem>
                  <ListItemText primary={`Last Name: ${authenticatedUser?.lastName}`} />
                </ListItem>
                <ListItem>
                  <ListItemText primary={`Email: ${authenticatedUser?.email}`} />
                </ListItem>
                <ListItem>
                  <ListItemText primary={`Date of Birth: ${authenticatedUser?.dateOfBirth}`} />
                </ListItem>
                <ListItem>
                  <ListItemText primary={`Orders: ${authenticatedUser?.orders.join(', ')}`} />
                </ListItem>
                <ListItem>
                  <ListItemText primary={`Reviews: ${authenticatedUser?.reviews}`} />
                </ListItem>
                <ListItem>
                  <ListItemText primary={`Payments: ${authenticatedUser?.payments}`} />
                </ListItem>
                <ListItem>
                  <ListItemText primary={`Shopping Cart: ${authenticatedUser?.shoppingCart}`} />
                </ListItem>
              </List>
            </Box>
          </Grid>
        </Grid>
      </Box>
    </Container>
  );
};

export default Profile;
