import { React, useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"

import axios from 'axios'

function Dashboard(props) {
    const navigate = useNavigate()

    let data = JSON.parse(localStorage.getItem('user'))
    let [user, setUser] = useState([])
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
            setUser(res.data)
        }).catch(err => {
            console.log(err)
            navigate("/signin");
        })
    }, [])

    return (
        <div class="row d-flex justify-content-center">
            <div class="col-md-6 grid-margin stretch-card">
                <div class="card">
                    <div class="card-body">

                        <h6 class="card-title">Basic Form</h6>
                        <img class="wd-70 rounded-circle" src={user.ProfilePicture} alt="profile"></img>

                        <form class="forms-sample">
                            <div class="mb-3">
                                <label for="name" class="form-label">Name</label>
                                <input type="text" class="form-control" id="name" placeholder="Name" value={user.Name} disabled />
                            </div>
                            <div class="mb-3">
                                <label for="email" class="form-label">Email address</label>
                                <input type="email" class="form-control" id="email" placeholder="Email" value={user.Email} disabled />
                            </div>
                            <div class="mb-3">
                                <label for="phone" class="form-label">Phone</label>
                                <input type="number" class="form-control" id="phone" value={user.Phone} placeholder="Phone" disabled />
                            </div>

                            <div class="mb-3">
                                <label for="address" class="form-label">Address</label>
                                <input type="textarea" class="form-control" id="address" value={user.Address} placeholder="Address" disabled />
                            </div>

                            <button type="submit" class="btn btn-primary me-2">Submit</button>
                            <button class="btn btn-secondary">Cancel</button>
                        </form>

                    </div>
                </div>
            </div>

        </div>
    )

}

export default Dashboard


