import { React, useEffect } from "react"
import { useNavigate } from "react-router-dom"
import axios from 'axios'

function Dashboard(props) {
    const navigate = useNavigate()

    let data = JSON.parse(localStorage.getItem('user'))
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
        }).catch(err => {
            console.log(err)
            navigate("/signin");
        })
    }, [])

    return (
        <div>
            <div className="d-flex justify-content-between align-items-center flex-wrap grid-margin">
                <div>
                    <h4 className="mb-3 mb-md-0">Welcome to Dashboard</h4>
                </div>
            </div>

        </div>
    )

}

export default Dashboard


