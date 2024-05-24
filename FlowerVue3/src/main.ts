import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import router from './router'
import store from './store/home'
import pinia from './store/index'

const app = createApp(App)

app.use(store)
app.use(ElementPlus)
app.use(router)
app.use(pinia)
app.mount('#app')
