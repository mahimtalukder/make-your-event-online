import { React, useEffect, useState } from 'react'
import axios from "axios"


const Dashboard = () => {

    const AxiosConfig = axios.create({
        baseURL: 'https://localhost:44335/api',
    });


    useEffect(() => {
        console.log("called")
    }, [])

    return (
        <div>
            <div class="mb-6"></div>
            <nav aria-label="breadcrumb" class="breadcrumb-nav mb-3">
                <div class="container">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                        <li class="breadcrumb-item"><a href="#">Shop</a></li>
                        <li class="breadcrumb-item active" aria-current="page">My Account</li>
                    </ol>
                </div>
            </nav>

            <div class="page-content">
                <div class="dashboard">
                    <div class="container">
                        <div class="row">
                            <aside class="col-md-4 col-lg-3">
                                <ul class="nav nav-dashboard flex-column mb-3 mb-md-0" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" id="tab-dashboard-link" data-toggle="tab"
                                            href="#tab-dashboard" role="tab" aria-controls="tab-dashboard"
                                            aria-selected="true">Dashboard</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="tab-orders-link" data-toggle="tab"
                                            href="#tab-orders" role="tab" aria-controls="tab-orders"
                                            aria-selected="false">Orders</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="tab-downloads-link" data-toggle="tab"
                                            href="#tab-downloads" role="tab" aria-controls="tab-downloads"
                                            aria-selected="false">Downloads</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="tab-address-link" data-toggle="tab"
                                            href="#tab-address" role="tab" aria-controls="tab-address"
                                            aria-selected="false">Adresses</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="tab-account-link" data-toggle="tab"
                                            href="#tab-account" role="tab" aria-controls="tab-account"
                                            aria-selected="false">Account Details</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="#">Sign Out</a>
                                    </li>
                                </ul>
                            </aside>

                            <div class="col-md-8 col-lg-9">
                                <div class="tab-content">
                                    <div class="tab-pane fade show active" id="tab-dashboard" role="tabpanel"
                                        aria-labelledby="tab-dashboard-link">
                                        <p>Hello <span class="font-weight-normal text-dark">User</span> (not <span
                                            class="font-weight-normal text-dark">User</span>? <a href="#">Log
                                                out</a>)
                                            <br />
                                            From your account dashboard you can view your <a href="#tab-orders"
                                                class="tab-trigger-link link-underline">recent orders</a>, manage
                                            your <a href="#tab-address" class="tab-trigger-link">shipping and
                                                billing addresses</a>, and <a href="#tab-account"
                                                    class="tab-trigger-link">edit your password and account details</a>.
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Dashboard