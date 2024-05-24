<template>
  <div>
    <el-row>
      <el-col :span="24">
        <ul>
          <li v-if="!useUser.NickName" @click="OpenLogin"><el-link :underline="false">登录</el-link></li>
          <li v-if="!useUser.NickName" @click="registerLogin"><el-link :underline="false">注册</el-link></li>
          <li v-if="useUser.NickName"><el-link :underline="false" >{{useUser.NickName}}</el-link></li>
          <li v-if="useUser.NickName">
            <el-link :underline="false" href="/personcenter">个人中心</el-link>
          </li>
          <li v-if="useUser.NickName"><el-link :underline="false" @click="logOutPerson">注销</el-link></li>
        </ul>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="8">
        <el-link :underline="false" href="/">
          <el-image class="image" scc="/vite.svg" fit="contain" />
        </el-link>
      </el-col>
      <el-col :span="8">
        <el-input
          class="w-50 m-2"
          style="margin-top: 30px"
          v-model="searchInput"
          placeholder="请输入内容"
          size="large"
          @change="change"
          :suffix-icon="Search"
        ></el-input>
      </el-col>
      <el-col :span="8">
        <div class="servce-item">
          <span class="icon icon-headset"></span>
          <!-- <span class="service-item-info">在线客服</span> -->
        </div>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="18">
        <el-menu
          :default-active="activeIndex"
          class="el-menu-header"
          mode="horizontal"
          router
        >
          <el-menu-item index="/">首页</el-menu-item>
          <el-menu-item index="/loveflower">爱情鲜花</el-menu-item>
          <el-menu-item index="/birthdayflower">生日鲜花</el-menu-item>
          <el-menu-item index="/friendflower">友情鲜花</el-menu-item>
          <el-menu-item index="/weddingflower">婚庆鲜花</el-menu-item>
        </el-menu>
      </el-col>
    </el-row>
  </div>
  <LoginCom ref="LoginComRef"/>
  <RegisterCom ref="RegisterComRef"/>
</template>

<script setup lang="ts">
// reactive computed computed
// import ElMessage from 'element-plus/lib/components/message/index.js';
import { ref } from "vue";
import { Search } from "@element-plus/icons-vue";
// import { userStore } from 'vuex';

import LoginCom from "./LoginCom.vue";
import RegisterCom from "./RegisterCom.vue";
import { useUserInfoStore } from '@/store/user'
// import { userStore } from "vuex"
// const store = userStore();
const useUser = useUserInfoStore(); 
const searchInput = ref(null);
const LoginComRef = ref(null);
const RegisterComRef = ref(null);
const activeIndex = ref(1);
const change = () => {
  // ElMessage('你搜索的是：' + searchInput.value);
};

/**
 * 登录
 */
const OpenLogin = () => {
  //  store.commit('OpenLogin')
  console.log(useUser)
  console.log(LoginComRef.value);
  useUser.OpenLogin();
  LoginComRef.value?.setShow(true);
}

/**
 * 注册
 */
const registerLogin = () => {
  //  store.commit('OpenLogin')
  console.log(useUser)
  console.log(LoginComRef.value);
  useUser.OpenRegister();
  RegisterComRef.value?.setShow(true);
}

/**
 * 退出
 */
 const logOutPerson = () => {
  localStorage.removeItem('NickName');
  localStorage.removeItem('token');
  useUser.SettingNickName(null)
}



</script>

<style scoped lang="scss">
.image {
  width: 200px;
  height: 100px;
}

ul {
  list-style: none;
  justify-content: flex-end;
  display: flex;
  padding-right: 20px;

  li {
    margin-left: 20px;
  }
}

.service-item {
  display: inline-block;
  font-size: 14px;
  color: #71797f;
  vertical-align: top;
  line-height: 47px;
  margin-top: 25px;

  a {
    text-decoration: none;
  }
}

.el-menu-header {
  margin-left: 30% !important;
  border-bottom: 0px !important;

  .el-menu-item {
    width: 170px !important;
  }
}
</style>
