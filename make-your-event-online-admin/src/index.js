import React from 'react'
import ReactDOM from 'react-dom/client'
import reportWebVitals from './reportWebVitals'
import { createBrowserRouter, RouterProvider } from "react-router-dom"
import OrganizerLayout from './Components/Layouts/OrganizerLayout'
import Home from './Components/home'
import SignIn from './Components/User/signin'
import Logout from './Components/User/Logout'


const router = createBrowserRouter(
  [
    {
      path: "/",
      element: <Home />,
    },
    {
      path: "signIn",
      element: <SignIn />,
    },
    {
      path: "/organizer/dashboard",
      element: <OrganizerLayout />,

    },
    {
      path: "/logout",
      element: <Logout />,

    },
    {
      path: "/organizer/profile",
      element: <OrganizerLayout />,

    },
    {
      path: "/organizer/addService",
      element: <OrganizerLayout />,

    }
  ]);

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>

);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
