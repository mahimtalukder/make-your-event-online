import { React, useEffect, useState } from 'react'
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

    let [serviceList, setServiceList] = useState([])
    let [user, setUser] = useState({})

    const fatchUser = async () => {
        var url = 'customer/get/' + userInfo.UserId
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
                                      
                                        <th>Name</th>
                                        <th>Email</th>
                                        <th>Phone</th>
                                        <th>Address</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {user.map((user) => (
                                        <tr>
                                            <td class="py-1">
                                                <img src={getThambnil(service.Id)} alt="image" />
                                            </td>
                                            <td>{user.Name}</td>
                                            <td>{user.Email}</td>
                                            <td>{user.Phone}</td>
                                            <td>{User.Address}</td>
                                            <td> <Link to={"/Admin/userResetPassword/"+user.Id } className="btn btn-primary me-1 mb-1">View</Link></td>
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