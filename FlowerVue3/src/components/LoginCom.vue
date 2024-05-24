<template>
    <el-dialog v-model="isShowlogin" title="登录" width="30%" :before-close="handelClose">
        <el-form :model="form" label-width="120px">
            <el-form-item label="用户名">
                <el-input v-model="form.UserName" />
            </el-form-item>
            <el-form-item label="密码">
                <el-input v-model="form.Password" />
            </el-form-item>
            <el-form-item label="验证码">
                <el-input v-model="form.ValidateCode" />
                <el-image style="width: 200px; height: 100px;" class="codeImg" :src="vaildImages"
                    @click="changeImg"></el-image>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="sumbit">确定</el-button>
                <el-button @click="handelClose">取消</el-button>
            </el-form-item>
        </el-form>
    </el-dialog>
</template>

<script setup lang='ts'>
import { ref, computed, reactive, onMounted } from 'vue';
import { LoginPost, getImages } from '../http/index'
import { guid, oriVaildImages } from '../utils/index'
import { ElMessage } from 'element-plus'
// import store from "../store"
// import { userStore } from 'vuex';
// const store = userStore();
// const isShowlogin = false;
import { storeToRefs } from 'pinia';
import { useUserInfoStore } from '../store/user'
// 得调用一下
const useUser = useUserInfoStore();
const { IsShowlogin } = storeToRefs(useUserInfoStore);
console.log(IsShowlogin)
// const isShowlogin = computed(()=>useUser.IsShowlogin)
const isShowlogin = ref(false);
const vaildImages = ref('');
const handelClose = (done: () => void) => {
    // store.commit('CloseLogin');
    useUser.CloseLogin();
    isShowlogin.value = false;
}
const setShow = (flag: boolean) => {
    isShowlogin.value = flag
}

let Validatekey = ref('');
onMounted(async () => {
    // const resImg = await getImages(t)
    changeImg();
})

/**
 * 改变图片
 */
const changeImg = () => {
    const t = guid();
    Validatekey.value = t;
    vaildImages.value = oriVaildImages.value + t;
}

const form = reactive(
    {
        UserName: '',
        Password: '',
        ValidateCode: ''
    }
)
const sumbit = async () => {
    const formData = {
        UserName: form.UserName,
        Password: form.Password,
        ValidateCode: form.ValidateCode,
        Validatekey: Validatekey.value
    }
    const res: any = (await LoginPost(formData)).data;
    if (res.isSuccess) {
        ElMessage({
            message: '登录成功',
            type: 'success',
        })
        localStorage['token'] = res.result;
        localStorage['NickName'] = res.result;
        useUser.SettingNickName(res.result);
        isShowlogin.value = false;
    } else {
        console.log('错误')
        ElMessage({
            message: res.msg,
            type: 'error',
        })
    }

}
defineExpose({
    setShow
})
</script>

<style scoped lang="scss">
:deep(.codeImg img) {
    width: 200px;
    height: 100px;
}
</style>