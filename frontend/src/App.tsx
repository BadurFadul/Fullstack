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
import Cart from './Pages/Cart'


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
      {
        path: 'cart',
        element: <Cart open = {false} handleClose={function (): void {
          throw new Error('Function not implemented.');
        }}/>
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