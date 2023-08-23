import React from 'react'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'

import Home from './Pages/Home'
import NotFound from './Pages/NotFound'
import Products from './Pages/Products'
import SingleProduct from './Pages/SingleProduct'
import Contact from './Pages/Contact'
import Default  from './Pages/Default'
import Profile from './Pages/Profile'
import Hero  from './Pages/Hero'


const router = createBrowserRouter([
  {
    path:"/",
    element: <Default/>,
    errorElement: <NotFound />,
    children: [
      {
        path: '/',
        element: <Hero/>
      },
      {
        path:"products",
        element: <Products/>
      },
      {
        path: "products/:id",
        element: <SingleProduct/>
      },
      {
        path: "contact",
        element: <Contact/>
      },
      {
        path: 'profile',
        element: <Profile/>
      },
    ]
  },
 
])

const App = () => {
  return (
    <RouterProvider router={router}/>
  )
}

export default App