import {defineStore} from 'pinia'
// import {createPinia} from 'pinia';
import { reactive } from 'vue';
export const useUserInfoStore : any = defineStore("user",
{
    // state:() => ({  // 用来定义一些变量
    //     mycount: 1,
    //     IsShowLogin: false,
    //     IsShowRegister: false,
    //     NickName: localStorage['NickName']
    // }),
    state:() => ({  // 用来定义一些变量
        mycount: 1,
        IsShowLogin: false,
        IsShowRegister: false,
        NickName: localStorage['NickName']
    }),
    
    getters: { // 类似于计算属性
        double: (state) => state.mycount * 2,
    },

    actions: {  // 里面是一些方法，在里面可以请求接口操作
        increment() { 
            this.mycount++ 
        },
        async registerUser(login, password) {  // 异步操作
           // await api.post({ login, password })
        },
        OpenLogin() {
            this.IsShowLogin = true;
        },
        CloseLogin() {
            this.IsShowLogin = false;
        },
        OpenRegister(state: any) {
            this.IsShowRegister = true;
        },
        CloseRegister(state: any) {
            this.IsShowRegister = false;
        },
        SettingNickName(name: string) {
            this.NickName = name;
        },
    }
})
