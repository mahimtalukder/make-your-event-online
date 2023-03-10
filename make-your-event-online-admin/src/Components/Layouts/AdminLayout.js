import { React, useEffect } from "react"
import { useNavigate, useLocation } from "react-router-dom"
import axios from "axios";


import Sidebar from "../Inc/AdminSidebar"
import Topbar from "../Inc/AdminTopbar"
import Footer from "../Inc/Footer";
import Dashboard from "../Admin/Dashboard";
import CustomerList from "../Admin/CustomerList"
import ViewProfile from "../Admin/ViewProfile"



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

        var url = 'admin/get/' + data.UserId
        AxiosConfig.get(url).then(res => {
        }).catch(err => {
            navigate("/signin");
        })
    }, [])


    const component = () => {
        if (location.pathname == "/admin/dashboard") {
            return <Dashboard />;
        } else if (location.pathname == "/Admin/customerlist") {
            return <CustomerList />

        } else if (location.pathname == "/admin/profile") {
            return <ViewProfile />

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