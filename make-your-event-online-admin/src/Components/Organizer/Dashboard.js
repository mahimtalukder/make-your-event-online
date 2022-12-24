import { React, useEffect } from "react"
import { useNavigate } from "react-router-dom"

import Sidebar from "../Inc/OrganizerSidebar"
import Topbar from "../Inc/OrganizerTopbar"
import Footer from "../Inc/Footer"
import axios from 'axios'

function Dashboard(props) {
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
            console.log(res.data)
        }).catch(err => {
            console.log(err)
            navigate("/signin");
        })
    }, [])

    return (
        <div class="main-wrapper">
            <Sidebar />

            <div class="page-wrapper">
                <Topbar />

                <div class="page-content">
                    <div>
                        <div className="d-flex justify-content-between align-items-center flex-wrap grid-margin">
                            <div>
                                <h4 className="mb-3 mb-md-0">Welcome to Dashboard</h4>
                            </div>
                        </div>

                    </div>
                </div>

                <Footer />
            </div>
        </div>
    )

}

export default Dashboard


