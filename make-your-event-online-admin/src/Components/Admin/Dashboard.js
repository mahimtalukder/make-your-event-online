import { React, useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import axios from 'axios'
import { Pie } from "react-chartjs-2";
import 'chart.js/auto';

function Dashboard(props) {
    const navigate = useNavigate()
    let data = JSON.parse(localStorage.getItem('user'))
    let [serviceList, setServiceList] = useState([])

    const AxiosConfig = axios.create({
        baseURL: 'https://localhost:44335/api',
        headers: {
            Authorization: data.LoginToken,
            Username: data.UserId
        }
    });

    const fetchServices = async (organizerId) => {
        const { data } = await AxiosConfig.get(
            "user/getallservices"
        );
        const services = data;
        setServiceList(services);
    };

    useEffect(() => {

        var url = 'admin/get/' + data.UserId
        AxiosConfig.get(url).then(res => {
            console.log(res.data)
        }).catch(err => {
            console.log(err)
            navigate("/signin");
        })

        fetchServices(data.UserId)
    }, [])

    let Available = 0;
    let NotAvailable = 0;

    serviceList.forEach(service => {
        if (service.Availability == 1) {
            Available++;
        } else {
            NotAvailable++;
        }
    })

    const availabilityData = {
        labels: ["Not Available", "Available"],
        datasets: [
            {
                label: "Total Services",
                backgroundColor: ["#F7464A", "#46BFBD"],
                hoverBackgroundColor: ["#FF5A5E", "#5AD3D1"],
                data: [NotAvailable, Available],
            },
        ],
    };


    return (
        <div>
            <div className="d-flex justify-content-between align-items-center flex-wrap grid-margin">
                <div>
                    <h4 className="mb-3 mb-md-0">Welcome to Dashboard</h4>
                </div>
            </div>

            <div class="row">
                <div class="col-xl-6 grid-margin stretch-card">
                    <div class="card">
                        <div class="card-body">
                            <h6 class="card-title">Services Availability</h6>
                            <Pie
                                data={availabilityData}
                                options={{
                                    title: {
                                        display: true,
                                        fontSize: 20
                                    },
                                    legend: {
                                        display: true,
                                        position: 'right'
                                    }
                                }}

                                style={{ display: "block", boxSizing: "border-box", height: "372px", width: "744px " }}
                            />
                        </div>
                    </div>
                </div>
            </div>

        </div>
    )

}

export default Dashboard


