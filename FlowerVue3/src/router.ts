import { createRouter, createWebHistory } from "vue-router";

// import { createRouter, createWebHistory, type Router } from "vue-router";
import HomePage from "./views/Home.vue";
import LoveFlower from "./views/LoveFlower.vue";
import BirthdayFlower from "./views/BirthdayFlower.vue";
import FriendFlower from "./views/FriendFlower.vue";
import WeddingFlower from "./views/WeddingFlower.vue";
import FlowerDetail from "./views/FlowerDetail.vue";
// import FlowerPay from"./views/FlowerPay.vue"
import Personcenter from "./views/PersonCenter.vue";
const router = createRouter({
  // 4.1Provide the history implementation to use. we are using the hash history for simplicity here.12
  history: createWebHistory(),
  routes: [
    // {
    //     path: "/",
    //     name: pageName.home,
    //     meta: { title: "Home" },
    //     component: () => import("@/views/Home.vue"),
    //   },
    { path: "/", component: HomePage },
    { path: "/loveflower", component: LoveFlower },
    { path: "/birthdayflower", component: BirthdayFlower },
    { path: "/friendflower", component: FriendFlower },
    { path: "/weddingflower", component: WeddingFlower },
    { path: "/detail", component: FlowerDetail },
    //  {path: '/pay', component: FlowerPay },
    { path: "/personcenter", component: Personcenter },
  ],
});
export default router;
