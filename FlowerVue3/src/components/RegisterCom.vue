<template>
    <el-dialog v-model="isShowlogin" title="注册" width="30%" :before-close="handelClose">
        <el-form :model="form" label-width="120px">
            <el-form-item label="昵称">
                <el-input v-model="form.NickName" />
            </el-form-item>
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
                <el-button  @click="handelClose">取消</el-button>
            </el-form-item>
        </el-form>
    </el-dialog>
</template>

<script setup lang='ts'>
import { ref, reactive , computed, onMounted } from 'vue';
import { guid, oriVaildImages } from '../utils/index'
// import store from "../store"
// import { userStore } from 'vuex';
// const store = userStore();
// const isShowlogin = false;
import { storeToRefs } from 'pinia';
import { useUserInfoStore } from '../store/user'
import { registerPost } from '../http/index'
import { ElMessage } from 'element-plus'
// 得调用一下
const useUser = useUserInfoStore();
const { IsShowlogin } = storeToRefs(useUserInfoStore);
console.log(IsShowlogin)
// const isShowlogin = computed(()=>useUser.IsShowlogin)
const isShowlogin = ref(false)
const handelClose = (done: () => void) => {
    // store.commit('CloseLogin');
    useUser.CloseRegister();
    isShowlogin.value = false;
    // done();
}
const vaildImages = ref('');
const Validatekey = ref('');
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

const setShow = (flag: boolean) => {
    isShowlogin.value = flag
}
const form = reactive(
    {
        NickName:'',
        UserName: '',
        Password:'',
        ValidateCode: ''
    }
)
const sumbit = async () => {
    form['Validatekey'] = Validatekey.value;
    const res:any = (await registerPost(form)).data;
    if(res.isSuccess) {
        ElMessage({
            message: '注册成功',
            type: 'success',
        })
        localStorage['token'] = res.result;
        localStorage['NickName'] = res.result;
        useUser.SettingNickName(res.result);
        isShowlogin.value = false;
    } else {
        console.log('错误')
        ElMessage({
            message:  res.msg,
            type: 'error',
        })
    }

}
defineExpose({
    setShow
})
</script>

<style></style>