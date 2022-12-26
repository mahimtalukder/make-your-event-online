import { React, useEffect, useState } from 'react'
import axios from "axios"
import { Link } from "react-router-dom";

const Topbar = () => {
    const AxiosConfig = axios.create({
        baseURL: 'https://localhost:44335/api',
    })

    let [cart, setCart] = useState([])

    useEffect(() => {
        let data = JSON.parse(localStorage.getItem('cart'))

        if (data != undefined) {
            setCart(data)
        }

    }, [])

    let total = 0;
    cart.forEach(service => {
        total += service.PricePerUnit
    })
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

    const removeFromCart = (serviceId) => {
        let data = JSON.parse(localStorage.getItem('cart'))
        let newData = [];
        let flag = true

        data.forEach(service => {
            console.log(service)
            if (service.Id == serviceId && flag) {
                flag = false
            }
            else {
                newData.push(service)
            }

            localStorage.setItem("cart", JSON.stringify(newData));
            setTimeout(() => {
                window.location.reload(false);
            }, 500);
        })
    }


    return (
        <header class="header header-2 header-intro-clearance">
            <div class="header-top">
                <div class="container">


                    <div class="header-right">
                        <ul class="top-menu">
                            <li>
                                <ul>
                                    <li><Link to="customer/login" data-toggle="modal"><i class="icon-user"></i>Login</Link></li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="header-middle">
                <div class="container">
                    <div class="header-left">
                        <button class="mobile-menu-toggler">
                            <span class="sr-only">Toggle mobile menu</span>
                            <i class="icon-bars"></i>
                        </button>

                        <a href="index.html" class="logo">
                            <img src="assets/images/demos/demo-2/logo.png" alt="Molla Logo" width="105" height="25" />
                        </a>
                    </div>{/* End .header-left */}

                    <div class="header-center justify-content-center">
                        <div class="header-search header-search-extended header-search-visible header-search-no-radius d-none d-lg-block">
                            <a href="#" class="search-toggle" role="button"><i class="icon-search"></i></a>
                            <form action="#" method="get">
                                <div class="header-search-wrapper search-wrapper-wide">
                                    <label for="q" class="sr-only">Search</label>
                                    <input type="search" class="form-control" name="q" id="q" placeholder="Search product ..." required />
                                    <button class="btn btn-primary" type="submit"><i class="icon-search"></i></button>
                                </div>{/* End .header-search-wrapper */}
                            </form>
                        </div>{/* End .header-search */}
                    </div>

                    <div class="header-right">
                        <div class="account">
                            <Link to="customer/account" title="My account">
                                <div class="icon">
                                    <i class="icon-user"></i>
                                </div>
                                <p>Account</p>
                            </Link>
                        </div>{/* End .compare-dropdown */}


                        <div class="dropdown cart-dropdown">
                            <a href="#" class="dropdown-toggle" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static">
                                <div class="icon">
                                    <i class="icon-shopping-cart"></i>
                                    <span class="cart-count">{cart ? cart.length : 0}</span>
                                </div>
                                <p>Cart</p>
                            </a>

                            {
                                cart.length != 0 ?
                                    (<div class="dropdown-menu dropdown-menu-right">
                                        <div class="dropdown-cart-products">
                                            {cart.map((service) => (
                                                <div class="product">
                                                    <div class="product-cart-details">
                                                        <h4 class="product-title">
                                                            <a href="product.html">{service.Name}</a>
                                                        </h4>

                                                        <span class="cart-product-info">
                                                            ${service.PricePerUnit}
                                                        </span>
                                                    </div>{/* End .product-cart-details */}

                                                    <figure class="product-image-container">
                                                        <a href="#" class="product-image">
                                                            <img src={getThambnil(service.Id)} alt="product" />
                                                        </a>
                                                    </figure>
                                                    <button class="btn-remove" title="Remove Product" onClick={e => removeFromCart(service.Id)}><i class="icon-close"></i></button>
                                                </div>
                                            ))}
                                        </div>{/* End .cart-product */}

                                        <div class="dropdown-cart-total">
                                            <span>Total</span>

                                            <span class="cart-total-price">${total}</span>
                                        </div>{/* End .dropdown-cart-total */}

                                        <div class="dropdown-cart-action">
                                            <a href="cart.html" class="btn btn-primary">View Cart</a>
                                            <a href="checkout.html" class="btn btn-outline-primary-2"><span>Checkout</span><i class="icon-long-arrow-right"></i></a>
                                        </div>{/* End .dropdown-cart-total */}
                                    </div>) :
                                    <div></div>
                            }

                        </div>{/* End .cart-dropdown */}
                    </div>{/* End .header-right */}
                </div>{/* End .container */}
            </div>{/* End .header-middle */}

            <div class="header-bottom sticky-header">
                <div class="container">
                    <div class="header-left">
                        <div class="dropdown category-dropdown">
                            <a href="#" class="dropdown-toggle" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static" title="Browse Categories">
                                Browse Categories
                            </a>

                            <div class="dropdown-menu">
                                <nav class="side-nav">
                                    <ul class="menu-vertical sf-arrows">
                                        <li class="item-lead"><a href="#">Daily offers</a></li>
                                        <li class="item-lead"><a href="#">Gift Ideas</a></li>
                                        <li><a href="#">Beds</a></li>
                                        <li><a href="#">Lighting</a></li>
                                        <li><a href="#">Sofas & Sleeper sofas</a></li>
                                        <li><a href="#">Storage</a></li>
                                        <li><a href="#">Armchairs & Chaises</a></li>
                                        <li><a href="#">Decoration </a></li>
                                        <li><a href="#">Kitchen Cabinets</a></li>
                                        <li><a href="#">Coffee & Tables</a></li>
                                        <li><a href="#">Outdoor Furniture </a></li>
                                    </ul>{/* End .menu-vertical */}
                                </nav>{/* End .side-nav */}
                            </div>{/* End .dropdown-menu */}
                        </div>{/* End .category-dropdown */}
                    </div>{/* End .header-left */}

                    <div class="header-center justify-content-center">
                        <nav class="main-nav">
                            <ul class="menu sf-arrows">
                                <li class="megamenu-container active">
                                    <a href="index.html" class="item-lead">Home</a>
                                </li>
                                <li>
                                    <a href="category.html" class="item-lead">Shop</a>
                                </li>
                                <li>
                                    <a href="product.html" class="item-lead">Product</a>
                                </li>
                            </ul>{/* End .menu */}
                        </nav>{/* End .main-nav */}
                    </div>{/* End .header-center justify-content-center */}

                </div>{/* End .container */}
            </div>{/* End .header-bottom */}
        </header>
    )
}

export default Topbar