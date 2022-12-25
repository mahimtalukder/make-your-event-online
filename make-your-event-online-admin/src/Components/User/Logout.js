import React from 'react'
import AxiosConfig from "../axiosConfig"
import { useNavigate } from "react-router-dom"


const Logout = () => {
    const navigate = useNavigate();
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