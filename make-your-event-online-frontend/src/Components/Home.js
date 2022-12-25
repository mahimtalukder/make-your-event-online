import { React, useEffect, useState } from 'react'
import axios from "axios"


const Home = () => {

    const AxiosConfig = axios.create({
        baseURL: 'https://localhost:44335/api',
    });

    let [serviceList, setServiceList] = useState([])

    const fetchServices = async () => {
        const { data } = await AxiosConfig.get(
            "user/getallservices"
        );
        const services = data;
        console.log(data);
        setServiceList(services);
    };


    useEffect(() => {
        fetchServices()
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
        <div>
            <div class="mb-6"></div>

            <div class="container">
                <div class="heading heading-center mb-3">
                    <h2 class="title">Our Services</h2>{/* End .title */}
                </div>{/* End .heading */}

                <div class="tab-content">
                    <div class="tab-pane p-0 fade show active" id="top-all-tab" role="tabpanel" aria-labelledby="top-all-link">
                        <div class="products">
                            <div class="row justify-content-center">
                                {serviceList.map((service) => (
                                    <div class="col-6 col-md-4 col-lg-3 col-xl-5col">
                                        <div class="product product-11 text-center">
                                            <figure class="product-media">
                                                <a href="#">
                                                    <img src={getThambnil(service.Id)} alt="Product image" class="product-image" />
                                                    <img src={getThambnil(service.Id)} alt="Product image" class="product-image-hover" />
                                                </a>
                                            </figure>{/* End .product-media */}

                                            <div class="product-body">
                                                <div class="product-cat">
                                                    <a href="#">Lighting</a>
                                                </div>{/* End .product-cat */}
                                                <h3 class="product-title"><a href="#">{service.Name}</a></h3>{/* End .product-title */}
                                                <div class="product-price">
                                                    ${service.PricePerUnit}
                                                </div>{/* End .product-price */}
                                            </div>{/* End .product-body */}
                                            <div class="product-action">
                                                <a href="#" class="btn-product btn-cart"><span>add to cart</span></a>
                                            </div>{/* End .product-action */}
                                        </div>{/* End .product */}
                                    </div>
                                ))}
                            </div>{/* End .row */}
                        </div>{/* End .products */}
                    </div>{/* .End .tab-pane */}
                    <div class="tab-pane p-0 fade" id="top-fur-tab" role="tabpanel" aria-labelledby="top-fur-link">
                        <div class="products">
                            <div class="row justify-content-center">
                                <div class="col-6 col-md-4 col-lg-3 col-xl-5col">
                                    <div class="product product-11 text-center">
                                        <figure class="product-media">
                                            <span class="product-label label-circle label-sale">Sale</span>
                                            <a href="product.html">
                                                <img src="assets/images/demos/demo-2/products/product-9-1.jpg" alt="Product image" class="product-image" />
                                                <img src="assets/images/demos/demo-2/products/product-9-2.jpg" alt="Product image" class="product-image-hover" />
                                            </a>

                                            <div class="product-action-vertical">
                                                <a href="#" class="btn-product-icon btn-wishlist "><span>add to wishlist</span></a>
                                            </div>{/* End .product-action-vertical */}
                                        </figure>{/* End .product-media */}

                                        <div class="product-body">
                                            <div class="product-cat">
                                                <a href="#">Furniture</a>
                                            </div>{/* End .product-cat */}
                                            <h3 class="product-title"><a href="product.html">Garden Armchair</a></h3>{/* End .product-title */}
                                            <div class="product-price">
                                                <span class="new-price">$94,00</span>
                                                <span class="old-price">Was $94,00</span>
                                            </div>{/* End .product-price */}
                                        </div>{/* End .product-body */}
                                        <div class="product-action">
                                            <a href="#" class="btn-product btn-cart"><span>add to cart</span></a>
                                        </div>{/* End .product-action */}
                                    </div>{/* End .product */}
                                </div>{/* End .col-sm-6 col-md-4 col-lg-3 */}

                                <div class="col-6 col-md-4 col-lg-3 col-xl-5col">
                                    <div class="product product-11 text-center">
                                        <figure class="product-media">
                                            <span class="product-label label-circle label-new">New</span>
                                            <a href="product.html">
                                                <img src="assets/images/demos/demo-2/products/product-12-1.jpg" alt="Product image" class="product-image" />
                                                <img src="assets/images/demos/demo-2/products/product-12-2.jpg" alt="Product image" class="product-image-hover" />
                                            </a>

                                            <div class="product-action-vertical">
                                                <a href="#" class="btn-product-icon btn-wishlist "><span>add to wishlist</span></a>
                                            </div>{/* End .product-action-vertical */}
                                        </figure>{/* End .product-media */}

                                        <div class="product-body">
                                            <div class="product-cat">
                                                <a href="#">Furniture</a>
                                            </div>{/* End .product-cat */}
                                            <h3 class="product-title"><a href="product.html">2-Seater</a></h3>{/* End .product-title */}
                                            <div class="product-price">
                                                $3.107,00
                                            </div>{/* End .product-price */}
                                        </div>{/* End .product-body */}
                                        <div class="product-action">
                                            <a href="#" class="btn-product btn-cart"><span>add to cart</span></a>
                                        </div>{/* End .product-action */}
                                    </div>{/* End .product */}
                                </div>{/* End .col-sm-6 col-md-4 col-lg-3 */}

                                <div class="col-6 col-md-4 col-lg-3 col-xl-5col">
                                    <div class="product product-11 text-center">
                                        <figure class="product-media">
                                            <a href="product.html">
                                                <img src="assets/images/demos/demo-2/products/product-13-1.jpg" alt="Product image" class="product-image" />
                                                <img src="assets/images/demos/demo-2/products/product-13-2.jpg" alt="Product image" class="product-image-hover" />
                                            </a>

                                            <div class="product-action-vertical">
                                                <a href="#" class="btn-product-icon btn-wishlist "><span>add to wishlist</span></a>
                                            </div>{/* End .product-action-vertical */}
                                        </figure>{/* End .product-media */}

                                        <div class="product-body">
                                            <div class="product-cat">
                                                <a href="#">Furniture</a>
                                            </div>{/* End .product-cat */}
                                            <h3 class="product-title"><a href="product.html">Wingback Chair</a></h3>{/* End .product-title */}
                                            <div class="product-price">
                                                $2.486,00
                                            </div>{/* End .product-price */}
                                        </div>{/* End .product-body */}
                                        <div class="product-action">
                                            <a href="#" class="btn-product btn-cart"><span>add to cart</span></a>
                                        </div>{/* End .product-action */}
                                    </div>{/* End .product */}
                                </div>{/* End .col-sm-6 col-md-4 col-lg-3 */}
                            </div>{/* End .row */}
                        </div>{/* End .products */}
                    </div>{/* .End .tab-pane */}
                    <div class="tab-pane p-0 fade" id="top-decor-tab" role="tabpanel" aria-labelledby="top-decor-link">
                        <div class="products">
                            <div class="row justify-content-center">
                                <div class="col-6 col-md-4 col-lg-3 col-xl-5col">
                                    <div class="product product-11 text-center">
                                        <figure class="product-media">
                                            <a href="product.html">
                                                <img src="assets/images/demos/demo-2/products/product-8-1.jpg" alt="Product image" class="product-image" />
                                                <img src="assets/images/demos/demo-2/products/product-8-2.jpg" alt="Product image" class="product-image-hover" />
                                            </a>

                                            <div class="product-action-vertical">
                                                <a href="#" class="btn-product-icon btn-wishlist "><span>add to wishlist</span></a>
                                            </div>{/* End .product-action-vertical */}
                                        </figure>{/* End .product-media */}

                                        <div class="product-body">
                                            <div class="product-cat">
                                                <a href="#">Decor</a>
                                            </div>{/* End .product-cat */}
                                            <h3 class="product-title"><a href="product.html">Madra Log Holder</a></h3>{/* End .product-title */}
                                            <div class="product-price">
                                                $401,00
                                            </div>{/* End .product-price */}

                                            <div class="product-nav product-nav-dots">
                                                <a href="#" class="active" style={{ background: "#333333" }}><span class="sr-only">Color name</span></a>
                                                <a href="#" style={{ background: "#927764" }}><span class="sr-only">Color name</span></a>
                                            </div>{/* End .product-nav */}

                                        </div>{/* End .product-body */}
                                        <div class="product-action">
                                            <a href="#" class="btn-product btn-cart"><span>add to cart</span></a>
                                        </div>{/* End .product-action */}
                                    </div>{/* End .product */}
                                </div>{/* End .col-sm-6 col-md-4 col-lg-3 */}

                                <div class="col-6 col-md-4 col-lg-3 col-xl-5col">
                                    <div class="product product-11 text-center">
                                        <figure class="product-media">
                                            <a href="product.html">
                                                <img src="assets/images/demos/demo-2/products/product-11-1.jpg" alt="Product image" class="product-image" />
                                                <img src="assets/images/demos/demo-2/products/product-11-2.jpg" alt="Product image" class="product-image-hover" />
                                            </a>

                                            <div class="product-action-vertical">
                                                <a href="#" class="btn-product-icon btn-wishlist "><span>add to wishlist</span></a>
                                            </div>{/* End .product-action-vertical */}
                                        </figure>{/* End .product-media */}

                                        <div class="product-body">
                                            <div class="product-cat">
                                                <a href="#">Decor</a>
                                            </div>{/* End .product-cat */}
                                            <h3 class="product-title"><a href="product.html">Original Outdoor Beanbag</a></h3>{/* End .product-title */}
                                            <div class="product-price">
                                                $259,00
                                            </div>{/* End .product-price */}
                                        </div>{/* End .product-body */}
                                        <div class="product-action">
                                            <a href="#" class="btn-product btn-cart"><span>add to cart</span></a>
                                        </div>{/* End .product-action */}
                                    </div>{/* End .product */}
                                </div>{/* End .col-sm-6 col-md-4 col-lg-3 */}

                                <div class="col-6 col-md-4 col-lg-3 col-xl-5col">
                                    <div class="product product-11 text-center">
                                        <figure class="product-media">
                                            <a href="product.html">
                                                <img src="assets/images/demos/demo-2/products/product-14-1.jpg" alt="Product image" class="product-image" />
                                                <img src="assets/images/demos/demo-2/products/product-14-2.jpg" alt="Product image" class="product-image-hover" />
                                            </a>

                                            <div class="product-action-vertical">
                                                <a href="#" class="btn-product-icon btn-wishlist "><span>add to wishlist</span></a>
                                            </div>{/* End .product-action-vertical */}
                                        </figure>{/* End .product-media */}

                                        <div class="product-body">
                                            <div class="product-cat">
                                                <a href="#">Decor</a>
                                            </div>{/* End .product-cat */}
                                            <h3 class="product-title"><a href="product.html">Cushion Set 3 Pieces</a></h3>{/* End .product-title */}
                                            <div class="product-price">
                                                $199,00
                                            </div>{/* End .product-price */}
                                        </div>{/* End .product-body */}
                                        <div class="product-action">
                                            <a href="#" class="btn-product btn-cart"><span>add to cart</span></a>
                                        </div>{/* End .product-action */}
                                    </div>{/* End .product */}
                                </div>{/* End .col-sm-6 col-md-4 col-lg-3 */}

                                <div class="col-6 col-md-4 col-lg-3 col-xl-5col">
                                    <div class="product product-11 text-center">
                                        <figure class="product-media">
                                            <a href="product.html">
                                                <img src="assets/images/demos/demo-2/products/product-15-1.jpg" alt="Product image" class="product-image" />
                                                <img src="assets/images/demos/demo-2/products/product-15-2.jpg" alt="Product image" class="product-image-hover" />
                                            </a>

                                            <div class="product-action-vertical">
                                                <a href="#" class="btn-product-icon btn-wishlist "><span>add to wishlist</span></a>
                                            </div>{/* End .product-action-vertical */}
                                        </figure>{/* End .product-media */}

                                        <div class="product-body">
                                            <div class="product-cat">
                                                <a href="#">Decor</a>
                                            </div>{/* End .product-cat */}
                                            <h3 class="product-title"><a href="product.html">Cushion Set 3 Pieces</a></h3>{/* End .product-title */}
                                            <div class="product-price">
                                                $199,00
                                            </div>{/* End .product-price */}
                                        </div>{/* End .product-body */}
                                        <div class="product-action">
                                            <a href="#" class="btn-product btn-cart"><span>add to cart</span></a>
                                        </div>{/* End .product-action */}
                                    </div>{/* End .product */}
                                </div>{/* End .col-sm-6 col-md-4 col-lg-3 */}
                            </div>{/* End .row */}
                        </div>{/* End .products */}
                    </div>{/* .End .tab-pane */}
                    <div class="tab-pane p-0 fade" id="top-light-tab" role="tabpanel" aria-labelledby="top-light-link">
                        <div class="products">
                            <div class="row justify-content-center">
                                <div class="col-6 col-md-4 col-lg-3 col-xl-5col">
                                    <div class="product product-11 text-center">
                                        <figure class="product-media">
                                            <a href="product.html">
                                                <img src="assets/images/demos/demo-2/products/product-7-1.jpg" alt="Product image" class="product-image" />
                                                <img src="assets/images/demos/demo-2/products/product-7-2.jpg" alt="Product image" class="product-image-hover" />
                                            </a>

                                            <div class="product-action-vertical">
                                                <a href="#" class="btn-product-icon btn-wishlist "><span>add to wishlist</span></a>
                                            </div>{/* End .product-action-vertical */}
                                        </figure>{/* End .product-media */}

                                        <div class="product-body">
                                            <div class="product-cat">
                                                <a href="#">Lighting</a>
                                            </div>{/* End .product-cat */}
                                            <h3 class="product-title"><a href="product.html">Petite Table Lamp</a></h3>{/* End .product-title */}
                                            <div class="product-price">
                                                $401,00
                                            </div>{/* End .product-price */}
                                        </div>{/* End .product-body */}
                                        <div class="product-action">
                                            <a href="#" class="btn-product btn-cart"><span>add to cart</span></a>
                                        </div>{/* End .product-action */}
                                    </div>{/* End .product */}
                                </div>{/* End .col-sm-6 col-md-4 col-lg-3 */}

                                <div class="col-6 col-md-4 col-lg-3 col-xl-5col">
                                    <div class="product product-11 text-center">
                                        <figure class="product-media">
                                            <a href="product.html">
                                                <img src="assets/images/demos/demo-2/products/product-10-1.jpg" alt="Product image" class="product-image" />
                                                <img src="assets/images/demos/demo-2/products/product-10-2.jpg" alt="Product image" class="product-image-hover" />
                                            </a>

                                            <div class="product-action-vertical">
                                                <a href="#" class="btn-product-icon btn-wishlist "><span>add to wishlist</span></a>
                                            </div>{/* End .product-action-vertical */}
                                        </figure>{/* End .product-media */}

                                        <div class="product-body">
                                            <div class="product-cat">
                                                <a href="#">Lighting</a>
                                            </div>{/* End .product-cat */}
                                            <h3 class="product-title"><a href="product.html">Carronade Large Suspension Lamp</a></h3>{/* End .product-title */}
                                            <div class="product-price">
                                                $401,00
                                            </div>{/* End .product-price */}

                                            <div class="product-nav product-nav-dots">
                                                <a href="#" class="active" style={{ background: "#e8e8e8" }}><span class="sr-only">Color name</span></a>
                                                <a href="#" style={{ background: "#333333" }}><span class="sr-only">Color name</span></a>
                                            </div>{/* End .product-nav */}

                                        </div>{/* End .product-body */}
                                        <div class="product-action">
                                            <a href="#" class="btn-product btn-cart"><span>add to cart</span></a>
                                        </div>{/* End .product-action */}
                                    </div>{/* End .product */}
                                </div>{/* End .col-sm-6 col-md-4 col-lg-3 */}

                                <div class="col-6 col-md-4 col-lg-3 col-xl-5col">
                                    <div class="product product-11 text-center">
                                        <figure class="product-media">
                                            <a href="product.html">
                                                <img src="assets/images/demos/demo-2/products/product-16-1.jpg" alt="Product image" class="product-image" />
                                                <img src="assets/images/demos/demo-2/products/product-16-2.jpg" alt="Product image" class="product-image-hover" />
                                            </a>

                                            <div class="product-action-vertical">
                                                <a href="#" class="btn-product-icon btn-wishlist "><span>add to wishlist</span></a>
                                            </div>{/* End .product-action-vertical */}
                                        </figure>{/* End .product-media */}

                                        <div class="product-body">
                                            <div class="product-cat">
                                                <a href="#">Lighting</a>
                                            </div>{/* End .product-cat */}
                                            <h3 class="product-title"><a href="product.html">Carronade Table Lamp</a></h3>{/* End .product-title */}
                                            <div class="product-price">
                                                $499,00
                                            </div>{/* End .product-price */}
                                        </div>{/* End .product-body */}
                                        <div class="product-action">
                                            <a href="#" class="btn-product btn-cart"><span>add to cart</span></a>
                                        </div>{/* End .product-action */}
                                    </div>{/* End .product */}
                                </div>{/* End .col-sm-6 col-md-4 col-lg-3 */}
                            </div>{/* End .row */}
                        </div>{/* End .products */}
                    </div>{/* .End .tab-pane */}
                </div>{/* End .tab-content */}
            </div>
        </div>
    )
}

export default Home