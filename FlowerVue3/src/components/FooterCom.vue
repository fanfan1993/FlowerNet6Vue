<template>
    <div class="ft" id="footer">
        <div class="ft-container">
            <div class="ft-nav">
                <a href="/">首页</a>
                <a href="https://www.hua.net/" target="_blank">关于我们</a>
                <a href="https://www.hua.net/" target="blank">操体报道</a>
                <a href="https://ww.hua.net/" target="_blank">企业团购</a>
                <a href="https://www.hua.net/" target="_blank">花店入驻</a>
                <a href="https://ww.hua.net/" target="blank">友情链接</a>
                <a href="https://ww.hua.net/" target="_blank">在线补款</a>
                <a href="https://ww.hua.net/" target="_blank">为什么选择鲜花网</a>
            </div>
        </div>
    </div>
</template>
    
<script setup lang='ts'>
    
</script>
    
<style lang="scss" scoped>
    #footer {
        font-size: 0;
        background-color: #333;
        .ft-container { 
            width: 1200px;
            margin: 0 auto;
            padding: 40px 0 46px;
            .ft-nav {
                a {
                    display: inline-block;
                    font-size: 16px;
                    line-height: 16px;
                    color: #fff;
                }
                a + a {
                    padding-left: 28px;
                    margin-left: 33px;
                    border-left: 1px solid #fff;
                }
            }
        }
    }
</style>