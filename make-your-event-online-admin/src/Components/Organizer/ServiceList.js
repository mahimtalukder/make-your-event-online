import { React, useEffect, useState } from 'react'
import axios from "axios"


const ServiceList = () => {

    const userInfo = JSON.parse(localStorage.getItem('user'));
    const AxiosConfig = axios.create({
        baseURL: 'https://localhost:44335/api',
        headers: {
            Authorization: userInfo.LoginToken,
            Username: userInfo.UserId
        }
    });

    let [serviceList, setServiceList] = useState([])
    let [user, setUser] = useState({})

    const fatchUser = async () => {
        var url = 'organizer/get/' + userInfo.UserId
        const { data } = await AxiosConfig.get(
            url
        );
        const userData = data;
        setUser(userData);
    };

    const fetchServices = async (organizerId) => {
        const { data } = await AxiosConfig.get(
            "organizer/getallservice/" + organizerId
        );
        const services = data;
        console.log(data);
        setServiceList(services);
    };


    useEffect(() => {
        fatchUser()
        fetchServices(userInfo.UserId)
    }, [])

    let [link, setLink] = useState("");
    const getThambnil = (serviceId) => {
        var url = 'user/getthumbnail/' + serviceId
        AxiosConfig.get(url).then(res => {
            setLink(res.data.Source);
        }).catch(err => {
            console.log(err)
            // navigate("/signin");
        })

        return link
    }

    let [ordersCount, setOrdersCount] = useState("");
    const totalOrder = (serviceId) => {
        var url = 'organizer/serviceordercount/' + serviceId
        AxiosConfig.get(url).then(res => {
            setOrdersCount(res.data)
        }).catch(err => {
            console.log(err)
            // navigate("/signin");
        })

        return ordersCount
    }


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
                                        <th>Thumbnail</th>
                                        <th>Name</th>
                                        <th>Price Per Unit</th>
                                        <th>Availability</th>
                                        <th>Toatl Order</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {serviceList.map((service) => (
                                        <tr>
                                            <td class="py-1">
                                                <img src={getThambnil(service.Id)} alt="image" />
                                            </td>
                                            <td>{service.Name}</td>
                                            <td>${service.PricePerUnit}</td>
                                            <td>{service.Availability ? "Yes" : "No"}</td>
                                            <td>{totalOrder(service.Id)}</td>
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

export default ServiceList