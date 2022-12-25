import React from 'react'
import { useNavigate } from "react-router-dom"
import axios from "axios"


const Logout = () => {
    let data = JSON.parse(localStorage.getItem('user'))
    const navigate = useNavigate();
    const AxiosConfig = axios.create({
        baseURL: 'https://localhost:44335/api',
        headers: {
            Authorization: data.LoginToken,
            Username: data.UserId
        }
    });

    AxiosConfig.post("logout")
        .then(resp => {
            var data = resp.data;
            console.log(data);
            localStorage.removeItem("user");
            navigate('/signin');
        }).catch(err => {
            console.log(err);
        });
}

export default Logout