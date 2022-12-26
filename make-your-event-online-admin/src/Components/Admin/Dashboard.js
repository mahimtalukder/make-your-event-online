import { React, useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import axios from 'axios'
import { Pie } from "react-chartjs-2";
import 'chart.js/auto';

function Dashboard(props) {
    const navigate = useNavigate()
    let data = JSON.parse(localStorage.getItem('user'))
    let [serviceList, setServiceList] = useState([])
    let [customer, setcustomer] = useState([])
    let [org, setorg] = useState([])
    let [user, setuser] = useState([])

    const AxiosConfig = axios.create({
        baseURL: 'https://localhost:44335/api',
        headers: {
            Authorization: data.LoginToken,
            Username: data.UserId
        }
    });

    const fetchServices = async () => {
        const { data } = await AxiosConfig.get(
            "user/getallservices"
        );
        const services = data;
        setServiceList(services);
    };
    const getcustomer = async () => {
        const { data } = await AxiosConfig.get(
            "customer/get"
        );
        const cu = data;
        setcustomer(cu);

    };
    const getOrganization = async () => {
        const { data } = await AxiosConfig.get(
            "Admin/getOrganization"
        );
        const cuor = data;
        setorg(cuor);


    };
    const getuser = async () => {
        const { data } = await AxiosConfig.get(
            "Admin/getuser"
        );
        const cuord = data;
        setuser(cuord);

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
                <div class="col-12 col-xl-12 stretch-card">
                    <div class="row flex-grow-1">
                        <div class="col-md-4 grid-margin stretch-card">
                            <div class="card">
                                <div class="card-body">
                                    <div class="d-flex justify-content-between align-items-baseline">
                                        <h6 class="card-title mb-0">Total Customers</h6>
                                        <div class="dropdown mb-2">
                                            <a type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                <i class="icon-lg text-muted pb-3px" data-feather="more-horizontal"></i>
                                            </a>
                                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="eye" class="icon-sm me-2"></i> <span class="">View</span></a>
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="edit-2" class="icon-sm me-2"></i> <span class="">Edit</span></a>
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="trash" class="icon-sm me-2"></i> <span class="">Delete</span></a>
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="printer" class="icon-sm me-2"></i> <span class="">Print</span></a>
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="download" class="icon-sm me-2"></i> <span class="">Download</span></a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-6 col-md-12 col-xl-5">
                                            <h3 class="mb-2">{customer ? customer.length : 0}</h3>
                                            <div class="d-flex align-items-baseline">
                                                <p class="text-success">
                                                    <span></span>
                                                    <i data-feather="arrow-up" class="icon-sm mb-1"></i>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-6 col-md-12 col-xl-7">
                                            <div id="customersChart" class="mt-md-3 mt-xl-0"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 grid-margin stretch-card">
                            <div class="card">
                                <div class="card-body">
                                    <div class="d-flex justify-content-between align-items-baseline">
                                        <h6 class="card-title mb-0">Total Organization</h6>
                                        <div class="dropdown mb-2">
                                            <a type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                <i class="icon-lg text-muted pb-3px" data-feather="more-horizontal"></i>
                                            </a>
                                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="eye" class="icon-sm me-2"></i> <span class="">View</span></a>
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="edit-2" class="icon-sm me-2"></i> <span class="">Edit</span></a>
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="trash" class="icon-sm me-2"></i> <span class="">Delete</span></a>
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="printer" class="icon-sm me-2"></i> <span class="">Print</span></a>
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="download" class="icon-sm me-2"></i> <span class="">Download</span></a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-6 col-md-12 col-xl-5">
                                            <h3 class="mb-2">{org ? org.length : 0}</h3>
                                            <div class="d-flex align-items-baseline">
                                                <p class="text-danger">
                                                    <span></span>
                                                    <i data-feather="arrow-down" class="icon-sm mb-1"></i>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-6 col-md-12 col-xl-7">
                                            <div id="ordersChart" class="mt-md-3 mt-xl-0"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 grid-margin stretch-card">
                            <div class="card">
                                <div class="card-body">
                                    <div class="d-flex justify-content-between align-items-baseline">
                                        <h6 class="card-title mb-0">Total Users</h6>
                                        <div class="dropdown mb-2">
                                            <a type="button" id="dropdownMenuButton2" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                <i class="icon-lg text-muted pb-3px" data-feather="more-horizontal"></i>
                                            </a>
                                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton2">
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="eye" class="icon-sm me-2"></i> <span class="">View</span></a>
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="edit-2" class="icon-sm me-2"></i> <span class="">Edit</span></a>
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="trash" class="icon-sm me-2"></i> <span class="">Delete</span></a>
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="printer" class="icon-sm me-2"></i> <span class="">Print</span></a>
                                                <a class="dropdown-item d-flex align-items-center" href="javascript:;"><i data-feather="download" class="icon-sm me-2"></i> <span class="">Download</span></a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-6 col-md-12 col-xl-5">
                                            <h3 class="mb-2">{user ? user.length : 0}</h3>
                                            <div class="d-flex align-items-baseline">
                                                <p class="text-success">
                                                    <span></span>
                                                    <i data-feather="arrow-up" class="icon-sm mb-1"></i>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-6 col-md-12 col-xl-7">
                                            <div id="growthChart" class="mt-md-3 mt-xl-0"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
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


