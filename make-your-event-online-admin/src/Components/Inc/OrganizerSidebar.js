import React from "react";
import { Link } from "react-router-dom";

const OrganizerSidebar = () => {
    return (
        <div>
            <nav className="sidebar">
                <div className="sidebar-header">
                    <a href="{{ route('adminDash') }}" className="sidebar-brand">
                        MY<span>EO</span>
                    </a>
                    <div className="sidebar-toggler not-active">
                        <span></span>
                        <span></span>
                        <span></span>
                    </div>
                </div>
                <div className="sidebar-body">
                    <ul className="nav">
                        <li className="nav-item nav-category">Main</li>
                        <li className="nav-item">
                            <Link to="/organizer/dashboard" className="nav-link">
                                <i className="link-icon" data-feather="box"></i>
                                <span className="link-title">Dashboard</span>
                            </Link>
                        </li>
                        <li className="nav-item nav-category">Personal</li>
                        <li className="nav-item">
                            <a
                                href="{{route('adminProfile')}}"
                                className="nav-link"
                            >
                                <i className="link-icon" data-feather="user"></i>
                                <span className="link-title">View Profile</span>
                            </a>
                        </li>
                        <li className="nav-item">
                            <a
                                href="{{route('adminEditProfile')}}" images
                                className="nav-link"
                            >
                                <i className="link-icon" data-feather="edit"></i>
                                <span className="link-title">Edit Profile</span>
                            </a>
                        </li>
                    </ul>
                </div>
            </nav>
            <nav className="sidebar">
                <div className="sidebar-header">
                    <Link to="/organizer/dashboard" className="sidebar-brand">
                        CM<span>WP</span>
                    </Link>
                    <div className="sidebar-toggler not-active">
                        <span></span>
                        <span></span>
                        <span></span>
                    </div>
                </div>
                <div className="sidebar-body">
                    <ul className="nav">
                        <li className="nav-item nav-category">Main</li>
                        <li className="nav-item">
                            <Link to="/organizer/dashboard" className="nav-link">
                                <i className="link-icon" data-feather="box"></i>
                                <span className="link-title">Dashboard</span>
                            </Link>
                        </li>
                        <li className="nav-item nav-category">Personal</li>
                        <li className="nav-item">
                            <Link to="/organizer/profile" className="nav-link">
                                <i className="link-icon" data-feather="user"></i>
                                <span className="link-title">View Profile</span>
                            </Link>
                        </li>
                        <li className="nav-item">
                            <a
                                href="{{route('adminEditProfile')}}"
                                className="nav-link"
                            >
                                <i className="link-icon" data-feather="edit"></i>
                                <span className="link-title">Edit Profile</span>
                            </a>
                        </li>
                        <li className="nav-item">
                            <a
                                href="{{route('adminChangePassword')}}"
                                className="nav-link"
                            >
                                <i className="link-icon" data-feather="lock"></i>
                                <span className="link-title">Change Password</span>
                            </a>
                        </li>

                        <li className="nav-item nav-category">Organizer</li>

                        <li className="nav-item">
                            <Link to="/organizer/addservice" className="nav-link">
                                <i className="link-icon" data-feather="box"></i>
                                <span className="link-title">
                                    Add Services
                                </span>
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/admin/list/director" className="nav-link">
                                <i className="link-icon" data-feather="box"></i>
                                <span className="link-title">Director List</span>
                            </Link>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
    )
}

export default OrganizerSidebar