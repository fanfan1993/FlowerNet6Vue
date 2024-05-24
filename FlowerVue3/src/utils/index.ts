
import { ref } from 'vue'
const RequestUrl = ref('https://localhost:7263/api');
const RequestJson = ref('/json');
const guid = () => {
    return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
}
const oriVaildImages = ref(RequestUrl.value + '/Login/GetValidateCodeImage?t=');
const FormatToken = (res: string ) => {
    return decodeURIComponent(escape(window.atob(res.replace('-','+').replace('-','/').split('.')[1])));
}
export {
    RequestUrl, RequestJson, guid ,oriVaildImages, FormatToken
}