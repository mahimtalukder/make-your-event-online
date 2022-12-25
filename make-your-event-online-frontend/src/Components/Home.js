import { React, useEffect, useState } from 'react'
import axios from "axios"


const Home = () => {

    const AxiosConfig = axios.create({
        baseURL: 'https://localhost:44335/api',
    });

    let [serviceList, setServiceList] = useState([])

    const fetchServices = async () => {
        const { data } = await AxiosConfig.get(
            "user/GetAvailableServices"
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
                </div>{/* End .tab-content */}
            </div>
        </div>
    )
}

export default Home