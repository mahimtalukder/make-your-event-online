import { React, useEffect } from "react"
import { useNavigate, useLocation } from "react-router-dom"
import axios from "axios";


import Sidebar from "../Inc/OrganizerSidebar"
import Topbar from "../Inc/OrganizerTopbar"
import Footer from "../Inc/Footer";
import Dashboard from "../Organizer/Dashboard";
import Profile from "../Organizer/ViewProfile";
import AddService from "../Organizer/AddServices";
import Services from "../Organizer/ServiceList";


function OrganizerLayouts(props) {
    const location = useLocation()
    const navigate = useNavigate()

    let data = JSON.parse(localStorage.getItem('user'))
    console.log(data)
    useEffect(() => {
        const AxiosConfig = axios.create({
            baseURL: 'https://localhost:44335/api',
            headers: {
                Authorization: data.LoginToken,
                Username: data.UserId
            }
        });

        var url = 'organizer/get/' + data.UserId
        AxiosConfig.get(url).then(res => {
        }).catch(err => {
            navigate("/signin");
        })
    }, [])


    const component = () => {
        if (location.pathname == "/organizer/dashboard") {
            return <Dashboard />;
        }
        else if (location.pathname == "/organizer/profile") {
            return <Profile />;
        }
        else if (location.pathname == "/organizer/addservice") {
            return <AddService />;
        }
        else if (location.pathname == "/organizer/services") {
            return <Services />;
        }
    }

    return (
        <div class="main-wrapper">
            <Sidebar />

            <div class="page-wrapper">
                <Topbar />

                <div class="page-content">
                    {component()}
                </div>

                <Footer />
            </div>
        </div>

    )

}

export default OrganizerLayouts