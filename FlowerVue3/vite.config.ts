import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import * as path from 'path'
// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  resolve: {
    // 设置别名
    alias: {
      '@': path.resolve(__dirname, 'src'),
      Assets: path.resolve(__dirname, 'src/assets'),
      Components: path.resolve(__dirname, 'src/components'),
      Utils: path.resolve(__dirname, 'src/utils'), // 工具类方法（新创建的）
    },
  },
  // server:{
  //   proxy:{
  //      '/api':{
  //          target:"https://localhost:7263/api", //跨域地址
  //          changeOrigin:true, //支持跨域
  //         //  ws: true,
  //          rewrite:(path) => path.replace(/^\/api/, "")//重写路径,替换/api
  //      }
  //   },
  //   headers: {
  //     "Origin-Agent-Cluster": "?0"
  //   }
//  }
})
