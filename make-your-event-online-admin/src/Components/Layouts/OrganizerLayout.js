import { React, useEffect } from "react"
import { useNavigate } from "react-router-dom"
import AxiosConfig from "../axiosConfig";

import Sidebar from "../Inc/OrganizerSidebar"
import Topbar from "../Inc/OrganizerTopbar"
import Footer from "../Inc/Footer";

function OrganizerLayouts(props) {
    const navigate = useNavigate()

    useEffect(() => {
        if (props.path == "dashboard") {
            AxiosConfig.get("admin/dashboard")
                .then((resp) => {
                    console.log(resp.data);
                })
                .catch((err) => {
                    navigate("/signin");
                    console.log(err);
                })
        }
    }, [])

    const component = () => {
        if (props.path == "dashboard") {
            return <Dashboard />;
        }
    }

    return (
        <div class="wrapper">

            {/* LEFT MAIN SIDEBAR */}
            <Sidebar />

            {/*  PAGE WRAPPER */}
            <div class="ec-page-wrapper">

                {/* Header */}
                <Topbar />

                {/* CONTENT WRAPPER */}
                <div class="ec-content-wrapper">
                    {component()}
                </div> {/* End Content Wrapper */}

                {/* Footer */}
                <Footer />

            </div> {/* End Page Wrapper */}
        </div>
    )

}

export default OrganizerLayouts