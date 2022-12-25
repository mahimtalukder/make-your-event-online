import { React, useEffect } from "react"
import { useNavigate, useLocation } from "react-router-dom"
import axios from "axios"

import Topbar from "./Inc/TopBar"
import Footer from "./Inc/Footer"
import Home from "./Home"

function Layout(props) {
    const location = useLocation()
    const navigate = useNavigate()

    const component = () => {
        console.log(location)
        if (location.pathname == "/") {
            return <Home />;
        }
        // else if (location.pathname == "/organizer/profile") {
        //     return <Profile />;
        // }
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