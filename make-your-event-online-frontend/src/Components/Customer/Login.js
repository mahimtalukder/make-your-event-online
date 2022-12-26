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
            <div class="row justify-content-center">
                <div class="col-6 col-md-8 col-lg-6 col-xl-5col">
                    <div class="tab-content" id="tab-content-5">
                        <div class="tab-pane fade show active" id="signin" role="tabpanel" aria-labelledby="signin-tab">
                            <form action="#">
                                <div class="form-group">
                                    <label for="singin-email">Username or email address *</label>
                                    <input type="text" class="form-control" id="singin-email" name="singin-email" required="" />
                                </div>{/* End .form-group */}

                                <div class="form-group">
                                    <label for="singin-password">Password *</label>
                                    <input type="password" class="form-control" id="singin-password" name="singin-password" required="" />
                                </div>{/* End .form-group */}

                                <div class="form-footer">
                                    <button type="submit" class="btn btn-outline-primary-2">
                                        <span>LOG IN</span>
                                        <i class="icon-long-arrow-right"></i>
                                    </button>
                                </div>{/* End .form-footer */}
                            </form>
                        </div>{/* .End .tab-pane */}
                    </div>
                </div>

            </div>
        </div>
    )
}

export default Dashboard