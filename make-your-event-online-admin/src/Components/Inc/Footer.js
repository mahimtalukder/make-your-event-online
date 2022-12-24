import React from "react";
import { Link } from "react-router-dom";

const Footer = () => {
    return (
        <footer class="footer d-flex flex-column flex-md-row align-items-center justify-content-between px-4 py-3 border-top small">
            <p class="text-muted mb-1 mb-md-0">Copyright © 2022 <a href="{{route('home')}}">CMWP</a>.</p>
        </footer>
    )
}
export default Footer