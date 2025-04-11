<template>
  <el-container class="layout-container">
    <el-aside width="200px">
      <SideMenu :menu-items="menuItems" />
    </el-aside>
    <el-container>
      <el-header>
        <div class="header-right">
          <el-dropdown @command="handleLanguageChange">
            <span class="el-dropdown-link">
              {{ currentLanguage === 'zh-CN' ? '中文' : 'English' }}
              <el-icon class="el-icon--right"><arrow-down /></el-icon>
            </span>
            <template #dropdown>
              <el-dropdown-menu>
                <el-dropdown-item command="zh-CN">中文</el-dropdown-item>
                <el-dropdown-item command="en-US">English</el-dropdown-item>
              </el-dropdown-menu>
            </template>
          </el-dropdown>
          <el-dropdown>
            <span class="el-dropdown-link">
              {{ t('common.admin') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
            </span>
            <template #dropdown>
              <el-dropdown-menu>
                <el-dropdown-item @click="handleLogout">{{ t('common.logout') }}</el-dropdown-item>
              </el-dropdown-menu>
            </template>
          </el-dropdown>
        </div>
      </el-header>
      <el-main>
        <router-view></router-view>
      </el-main>
    </el-container>
  </el-container>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import { useRouter } from 'vue-router/dist/vue-router'
import { useI18n } from 'vue-i18n'
import { HomeFilled, ArrowDown } from '@element-plus/icons-vue'
import SideMenu from '@/components/navigation/KpSideMenu/index.vue'
import type { MenuItem } from '@/types/menu'

const router = useRouter()
const { locale, t } = useI18n()

const currentLanguage = computed(() => locale.value)

const menuItems: MenuItem[] = [
  {
    path: '/',
    title: 'menu.home',
    icon: HomeFilled
  }
]

const handleLanguageChange = (lang: string) => {
  locale.value = lang
}

const handleLogout = () => {
  // TODO: 实现登出逻辑
  router.push('/login')
}
</script>

<style scoped>
.layout-container {
  height: 100vh;
}

.el-header {
  background-color: #fff;
  border-bottom: 1px solid #dcdfe6;
  display: flex;
  align-items: center;
  justify-content: flex-end;
  padding: 0 20px;
}

.el-aside {
  background-color: #304156;
}

.header-right {
  display: flex;
  align-items: center;
  gap: 20px;
}

.el-dropdown-link {
  cursor: pointer;
  display: flex;
  align-items: center;
}
</style>