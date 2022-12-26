import { React, useEffect, useState } from 'react'
import { Link, useNavigate } from "react-router-dom";
import axios from "axios"


const CustomerList = () => {

    const userInfo = JSON.parse(localStorage.getItem('user'));
    const AxiosConfig = axios.create({
        baseURL: 'https://localhost:44335/api',
        headers: {
            Authorization: userInfo.LoginToken,
            Username: userInfo.UserId
        }
    });

    let [user, setUser] = useState({})

    const fatchUser = async () => {
        var url = 'customer/get'
        const { data } = await AxiosConfig.get(
            url
        );
        const userData = data;
        setUser(userData);
    };


    useEffect(() => {
        fatchUser()
    }, [])



    return (
        <div class="row">
            <div class="col-lg-12 grid-margin stretch-card">
                <div class="card">
                    <div class="card-body">
                        <h4 class="card-title">Striped Table</h4>
                        <div class="table-responsive">
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                      
                                        <th>Name</th>
                                        <th>Email</th>
                                        <th>Phone</th>
                                        <th>Address</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {user.map((userData) => (
                                        <tr>
                                            <td>{userData.Name}</td>
                                            <td>{userData.Email}</td>
                                            <td>{userData.Phone}</td>
                                            <td>{userData.Address}</td>
                                            <td> <Link to={"/Admin/userResetPassword/"+userData.Id } className="btn btn-primary me-1 mb-1">View</Link></td>
                                            <th></th>
                                        </tr>
                                    ))}

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default CustomerList