import axios from 'axios';

let user = JSON.parse(localStorage.getItem('user'))
console.log(user)

const AxiosConfig = axios.create({
    baseURL: 'https://localhost:44335/api',
    headers: {
        Authorization: user.LoginToken,
        Username: user.UserId
    }
});

export default AxiosConfig