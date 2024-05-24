<!-- 标签部分 -->
<template>
    <div>
        <el-carousel height="480px" v-if="isShow">
            <el-carousel-item v-for="item in images" :Key="item">
                <el-image :src="item.imageUrl" />
            </el-carousel-item>
        </el-carousel>
    </div>
</template>
<!-- 脚本部分 -->
<script setup>
import { ref,onMounted  } from 'vue'
import { getBanners, getBanners2 } from '../http/index'
const images = ref();
const isShow=ref(false);

onMounted(async()=>{ 
    images.value=(await getBanners2()).data
    isShow.value=true;
})
</script>
<!-- 样式部分 -->
<style></style>
