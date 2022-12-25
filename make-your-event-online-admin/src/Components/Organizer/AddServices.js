import { React, useEffect, useState } from 'react'
import { useNavigate } from "react-router-dom";
import axios from "axios"


const AddService = () => {
    let userInfo = JSON.parse(localStorage.getItem('user'));
    let [massage, setMessage] = useState("")
    let [error, setError] = useState("")

    const AxiosConfig = axios.create({
        baseURL: 'https://localhost:44335/api',
        headers: {
            Authorization: userInfo.LoginToken,
            Username: userInfo.UserId
        }
    });

    const navigate = useNavigate();
    let [categoryList, setCategoryList] = useState([]);

    let [user, setUser] = useState()

    const fetchProducts = async () => {
        const { data } = await AxiosConfig.get(
            "category"
        );
        const category = data;
        setCategoryList(category);
        console.log(category);
    };

    useEffect(() => {

        var url = 'organizer/get/' + userInfo.UserId
        AxiosConfig.get(url).then(res => {
            setUser(res.data)
        }).catch(err => {
            console.log(err)
            // navigate("/signin");
        })

        fetchProducts()


    }, [])



    console.log(categoryList)

    const [name, setName] = useState("");
    const [pricePerUnit, setPricePerUnit] = useState()
    const [availability, setAvailability] = useState()
    const [organizerId, setOrganizerId] = useState(userInfo.UserId)
    const [categoryId, setCategoryId] = useState()
    const [tentativeDeliveryDate, setTentativeDelivery] = useState()

    const handleSubmit = (event) => {
        event.preventDefault();

        //Write your code here
        var obj = { Name: name, PricePerUnit: pricePerUnit, Availability: availability, OrganizerId: organizerId, CategoryId: categoryId, TentativeDeliveryDate: tentativeDeliveryDate };
        console.log(obj)

        AxiosConfig.post("organizer/addservice", obj).then(res => {
            setMessage("Created!")
            console.log(res.data)
        }).catch(err => {
            setError("Invalid Input!")
            console.log(err)
            // navigate("/signin");
        })

    }

    return (
        <div class="row d-flex justify-content-center">
            <div class="col-md-6 grid-margin stretch-card">
                <div class="card">
                    <div class="card-body">

                        <h6 class="card-title text-success">{massage}</h6>
                        <h6 class="card-title text-danger">{error}</h6>
                        <h6 class="card-title">Services</h6>


                        <form class="forms-sample" onSubmit={handleSubmit}>
                            <div class="mb-3">
                                <label for="name" class="form-label">Name</label>
                                <input type="text" class="form-control" id="name" placeholder="Name" value={name} onChange={(e) => setName(e.target.value)} />
                            </div>
                            <div class="mb-3">
                                <label for="price" class="form-label">Price per Unit</label>
                                <input type="number" class="form-control" id="price" placeholder="Price" value={pricePerUnit} onChange={(e) => setPricePerUnit(e.target.value)} />
                            </div>
                            <div class="mb-3">
                                <label for="tentativeDeliveryDate" class="form-label">Can Delivery within Days</label>
                                <input type="number" class="form-control" id="tentativeDeliveryDate" placeholder="Tentative Delivery Day" value={tentativeDeliveryDate} onChange={(e) => setTentativeDelivery(e.target.value)} />
                            </div>
                            <div class="mb-3">
                                <label for="availability" class="form-label">Availability</label>
                                <select id="availability" class="form-select form-select-lg" onChange={(e) => setAvailability(e.target.value)}>
                                    <option selected="">Open this select menu</option>
                                    <option value="1">Yes</option>
                                    <option value="2">No</option>
                                </select>
                            </div>

                            <div class="mb-3">
                                <label for="category" class="form-label">Category</label>
                                <select id="category" class="form-select form-select-lg" onChange={(e) => setCategoryId(e.target.value)}>
                                    <option selected="">Open this select menu</option>
                                    {categoryList.map((category) => (
                                        <option value={category.Id} >{category.Name}</option>
                                    ))}
                                </select>
                            </div>

                            <button type="submit" class="btn btn-primary me-2">Submit</button>
                        </form>

                    </div>
                </div>
            </div >

        </div >
    )

}
export default AddService