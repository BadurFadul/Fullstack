import React, { useState, useEffect } from 'react';
import { Controller, useForm } from 'react-hook-form';
import { Box, TextField, Button, Typography, Dialog, DialogTitle, DialogContent, DialogActions, Container, Paper } from '@mui/material';
import { yupResolver } from '@hookform/resolvers/yup';

import registrationSchema from '../Validations/registrationSchema';
import { registrationFormData } from '../Validations/registrationSchema';

const Register = () => {
  const { handleSubmit, control, formState: { errors } } = useForm<registrationFormData>({
    resolver: yupResolver(registrationSchema)
  });

  const onSubmit = async (data: registrationFormData) => {
    console.log(data);

  };

  return (
    <Container
      sx={{
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        minHeight: '100vh',
      }}
    >
      <Paper elevation={6} sx={{ p: 4, borderRadius: '16px', width: '40rem' }}>
        <Typography variant="h4" align="center" gutterBottom>
          Register new account
        </Typography>
        <form onSubmit={handleSubmit(onSubmit)}>
          <Box sx={{ display: 'flex', flexDirection: 'column', gap: '1.5rem' }}>
            <Box sx={{ display: 'flex', flexDirection: 'row', gap: '1.5rem' }}>
              <Controller
                control={control}
                name="firstname"
                render={({ field: { onChange } }) => (
                  <TextField
                    placeholder="Badur@mail.com"
                    label="Enter your firstname"
                    onChange={onChange}
                    variant="outlined"
                    required
                  />
                )}
              />
              {errors.firstname && (
                <Typography color="error">{errors.firstname.message}</Typography>
              )}
              <Controller
                control={control}
                name="lastname" 
                render={({ field: { onChange } }) => (
                  <TextField
                    placeholder="Lastname"
                    label="Enter your lastname"
                    onChange={onChange}
                    variant="outlined"
                    required
                  />
                )}
              />
              {errors.lastname && (
                <Typography color="error">{errors.lastname.message}</Typography>
              )}
            <Controller
              control={control}
              name="email"
              render={({ field: { onChange } }) => (
                <TextField
                  placeholder="Badur@mail.com"
                  label="Enter your email"
                  type="email"
                  onChange={onChange}
                  variant="outlined"
                  required
                />
              )}
            />
            {errors.email && (
              <Typography color="error">{errors.email.message}</Typography>
            )}
            </Box>
            <Controller
                control={control}
                name="phonenumber" 
                render={({ field: { onChange } }) => (
                  <TextField
                    placeholder="phonenumber"
                    label="Enter your phonenumber"
                    onChange={onChange}
                    variant="outlined"
                    required
                  />
                )}
              />
              {errors.phonenumber && (
                <Typography color="error">{errors.phonenumber.message}</Typography>
              )}
            <Controller
              control={control}
              name="password"
              render={({ field: { onChange } }) => (
                <TextField
                  label="Password"
                  type="password"
                  onChange={onChange}
                />
              )}
            />
            {errors.password && (
              <Typography sx={{ color: 'red' }}>
                {errors.password.message}
              </Typography>
            )}
            <Controller
              control={control}
              name="confirm"
              render={({ field: { onChange } }) => (
                <TextField
                  label="Confirm"
                  type="password"
                  onChange={onChange}
                />
              )}
            />
            {errors.confirm && (
              <Typography sx={{ color: 'red' }}>
                {errors.confirm.message}
              </Typography>
            )}
            <Box sx={{ display: 'flex', flexDirection: 'row', gap: '1.5rem', justifyContent: 'center' }}>
            <Controller
                control={control}
                name="shippingAddress" 
                render={({ field: { onChange } }) => (
                  <TextField
                    placeholder="ShippingAdress"
                    label="Enter your ShippingAdress"
                    onChange={onChange}
                    variant="outlined"
                    required
                    sx={{ width: '100%' }}
                  />
                )}
              />
              {errors.shippingAddress && (
                <Typography color="error">{errors.shippingAddress.message}</Typography>
              )}
              <Controller
                control={control}
                name="billingAddress" 
                render={({ field: { onChange } }) => (
                  <TextField
                    placeholder="billingAddress"
                    label="Enter your billingAddress"
                    onChange={onChange}
                    variant="outlined"
                    required
                    sx={{ width: '100%' }}
                  />
                )}
              />
              {errors.billingAddress && (
                <Typography color="error">{errors.billingAddress.message}</Typography>
              )}
            </Box>
            <Controller
              control={control}
              name="avatar"
              render={({ field: { onChange } }) => (
                <TextField
                  placeholder="Avatar"
                  label="Avatar"
                  onChange={onChange}
                  sx={{ width: '100%' }}
                />
              )}
            />
            {errors.avatar && (
              <Typography sx={{ color: 'red' }}>
                {errors.avatar.message}
              </Typography>
            )}
            <Button type="submit" variant="contained">
              Register
          </Button>
          </Box>
        </form>
      </Paper>
    </Container>
  )
}

export default Register;
