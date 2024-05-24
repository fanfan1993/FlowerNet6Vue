import axios from 'axios'; 
import { ref } from 'vue';
const json = ref('/json')
const http = ref('https://localhost:7263/api/')
// const http = ref('/api/')
//获取首页Banner轮播图
export const getBanners = () => {
    return axios.get("/json/banner.json");
}

//获取首页Banner轮播图
export const getBanners2 = () => {
    return axios.get(http.value + "Image/GetImages");
}

//获取花轮播图
export const getflowers = (params?: any) => {
    return axios.post(http.value + "Flower/Getflowers", params);
}

//登录注册
export const registerPost = (params?: any) => {
    return axios.post(http.value + "Login/Register", params);
}

//登录
export const LoginPost = (params?: any) => {
    return axios.post(http.value + "Login/Check", params);
}


//获取code 图片
export const getImages = (params?: any) => {
    return axios.get(http.value + `Login/GetValidateCodeImage?t=${params}`);
}