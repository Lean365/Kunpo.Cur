import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import AutoImport from 'unplugin-auto-import/vite'
import Components from 'unplugin-vue-components/vite'
import { ElementPlusResolver } from 'unplugin-vue-components/resolvers'
import Icons from 'unplugin-icons/vite'
import IconsResolver from 'unplugin-icons/resolver'
import path from 'path'
import fs from 'fs'

// 递归查找组件文件
function findComponentFile(componentName: string, baseDir: string): string | null {
  const files = fs.readdirSync(baseDir)
  
  for (const file of files) {
    const fullPath = path.join(baseDir, file)
    const stat = fs.statSync(fullPath)
    
    if (stat.isDirectory()) {
      const componentPath = path.join(fullPath, componentName, 'index.vue')
      if (fs.existsSync(componentPath)) {
        return componentPath
      }
      const result = findComponentFile(componentName, fullPath)
      if (result) return result
    }
  }
  
  return null
}

// https://vitejs.dev/config/
export default defineConfig({
  build: {
    rollupOptions: {
      input: {
        main: path.resolve(__dirname, 'index.html')
      }
    }
  },
  optimizeDeps: {
    include: ['vue', 'vue-router', 'pinia', '@vueuse/core', 'element-plus', '@element-plus/icons-vue']
  },
  plugins: [
    vue(),
    AutoImport({
      // 自动导入 Vue 相关函数，如：ref, reactive, toRef 等
      imports: ['vue', 'vue-router', 'pinia', '@vueuse/core', 'vue-i18n'],
      resolvers: [
        // 自动导入 Element Plus 相关函数
        ElementPlusResolver(),
        // 自动导入图标组件
        IconsResolver({
          prefix: 'Icon',
        }),
      ],
      dts: path.resolve(__dirname, 'src/auto-imports.d.ts'),
    }),
    Components({
      resolvers: [
        // 自动导入 Element Plus 组件
        ElementPlusResolver(),
        // 自动导入图标组件
        IconsResolver({
          enabledCollections: ['ep'],
        }),
        // 自定义组件解析器
        (name) => {
          if (name.startsWith('Kp')) {
            const componentsDir = path.resolve(__dirname, 'src/components')
            const componentPath = findComponentFile(name, componentsDir)
            
            if (componentPath) {
              const relativePath = path.relative(path.resolve(__dirname, 'src'), componentPath)
              return {
                name,
                from: `./${relativePath}`,
                sideEffects: []
              }
            }
          }
        }
      ],
      dts: path.resolve(__dirname, 'src/components.d.ts'),
      dirs: ['src/components']
    }),
    Icons({
      autoInstall: true,
    }),
  ],
  resolve: {
    alias: {
      '@': path.resolve(__dirname, 'src'),
      '@components': path.resolve(__dirname, 'src/components'),
      '@views': path.resolve(__dirname, 'src/views'),
      '@assets': path.resolve(__dirname, 'src/assets'),
      '@styles': path.resolve(__dirname, 'src/styles'),
      '@utils': path.resolve(__dirname, 'src/utils'),
      '@api': path.resolve(__dirname, 'src/api'),
      '@store': path.resolve(__dirname, 'src/store'),
    },
  },
  css: {
    preprocessorOptions: {
      scss: {
        additionalData: `@use "@/styles/variables.scss" as *;`
      }
    }
  },
  server: {
    port: 3000,
    proxy: {
      '/api': {
        target: 'http://localhost:5000',
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/api/, '')
      }
    }
  }
}) 