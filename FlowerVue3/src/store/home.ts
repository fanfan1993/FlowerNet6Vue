import { createStore, useStore as beseUseStore, store } from 'vuex';
const store = createStore(
    {
        state:{
      
                IsShowLogin: false,
                IsShowRegister: false,
                NickName: localStorage['NickName']
            },
        mutations: {
            OpenLogin(state: any) {
                state.IsShowLogin = true;
            },
            CloseLogin(state: any) {
                state.IsShowLogin = false;
            },
            OpenRegister(state: any) {
                state.IsShowRegister = true;
            },
            CloseRegister(state: any) {
                state.IsShowRegister = false;
            },
            SettingNickName(state: any, name: string) {
                state.NickName = name;
            },

        }
    }
)
export default store;