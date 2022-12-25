import { React, useEffect, useState } from 'react'
import { useNavigate } from "react-router-dom";
import axios from "axios"
import { Link } from "react-router-dom"



const SignIn = () => {
    const navigate = useNavigate();
    const [dberror, setDberror] = useState("");
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    //Final submit function

    const handleSubmit = (event) => {
        event.preventDefault();

        //Write your code here
        var obj = { Username: username, Password: password };
        axios.post("https://localhost:44335/api/login", obj)
            .then(resp => {
                var data = resp.data;
                if (data.UserType == "organizer") {
                    localStorage.setItem('user', JSON.stringify(data));
                    setTimeout(() => {
                        window.location.reload(false);
                    }, 500);
                    navigate("/organizer/dashboard");
                }
                else if (data.UserType == "Admin") {
                    localStorage.setItem('user', JSON.stringify(data));
                    setTimeout(() => {
                        window.location.reload(false);
                    }, 500);
                    navigate("/admin/dashboard");
                }
            }).catch(err => {
                setDberror("Invalid Input");
                console.log(err);
            });

    }


    //Custom hook call
    return (
        <div className="main-wrapper">
            <div className="page-wrapper full-page">
                <div className="page-content d-flex align-items-center justify-content-center">

                    <div className="row w-100 mx-0 auth-page">
                        <div className="col-md-8 col-xl-6 mx-auto">
                            <div className="card">
                                <div className="row">
                                    <div className="col-md-4 pe-md-0">
                                        <div className="auth-side-wrapper">
                                        </div>
                                    </div>
                                    <div className="col-md-8 ps-md-0">
                                        <div className="auth-form-wrapper px-4 py-5">
                                            <a href="#" className="noble-ui-logo d-block mb-2">CM<span>WP</span></a>
                                            <h5 className="text-muted fw-normal mb-4">Welcome back! Log in to your account.</h5>
                                            <h5 className="text-danger">{dberror}</h5>

                                            <form className="forms-sample" onSubmit={handleSubmit}>
                                                {/* {{ csrf_field() }} */}
                                                <div className="mb-3">
                                                    <label for="id" className="form-label">Username</label>
                                                    <input type="text" className="form-control" id="username" name="username" value={username} onChange={(e) => setUsername(e.target.value)} placeholder="Username" />
                                                </div>
                                                <div className="mb-3">
                                                    <label for="password" className="form-label">Password</label>
                                                    <input type="password" className="form-control" id="password" name="password" value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Password" />

                                                </div>
                                                <div>
                                                    <button type="submit" className="btn btn-primary me-2 mb-2 mb-md-0 text-white">
                                                        Login
                                                    </button>
                                                </div>
                                                <Link className='d-block mt-3 text-muted' to="/forgetPassword">Forget password? Reset Password</Link>
                                            </form>
                                        </div>
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

export default SignIn