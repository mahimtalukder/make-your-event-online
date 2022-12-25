import { React, useEffect } from "react"
import { useNavigate, useLocation } from "react-router-dom"
import axios from "axios"

import Topbar from "./Inc/TopBar"
import Footer from "./Inc/Footer"
import Home from "./Home"
import Dashboard from "./Customer/Dashboard"
import Login from "./Customer/Login"

function Layout(props) {
    const location = useLocation()
    const navigate = useNavigate()

    const component = () => {
        console.log(location)
        if (location.pathname == "/") {
            return <Home />;
        }
        else if (location.pathname == "/customer/account") {
            return <Dashboard />
        }
        else if (location.pathname == "/customer/login") {
            return <Login />
        }
    }

    return (
        <div class="page-wrapper">
            <Topbar />

            <main class="main">

                {component()}

            </main>

            <Footer />
        </div>
    )

}

export default Layout