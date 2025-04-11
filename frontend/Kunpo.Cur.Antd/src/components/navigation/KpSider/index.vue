<template>
  <a-layout-sider v-model:collapsed="collapsed" :trigger="null" collapsible class="kp-sider" :width="256"
    :theme="themeStore.algorithm === antTheme.darkAlgorithm ? 'dark' : 'light'">
    <div class="kp-sider-logo">
      <img src="@/assets/images/logo.svg" alt="logo" />
      <h1 v-show="!collapsed">{{ title }}</h1>
    </div>
    <a-menu v-model:selectedKeys="selectedKeys" v-model:openKeys="openKeys" mode="inline"
      :theme="themeStore.algorithm === antTheme.darkAlgorithm ? 'dark' : 'light'" :items="menuItems"
      @click="handleMenuClick" />
  </a-layout-sider>
</template>

<script lang="ts" setup>
import { ref, computed, h } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { useThemeStore } from '@/stores/theme'
import { theme as antTheme } from 'ant-design-vue'
import type { MenuClickEventHandler } from 'ant-design-vue/es/menu/src/interface'
import {
  DashboardOutlined,
  UserOutlined,
  TeamOutlined,
  SettingOutlined
} from '@ant-design/icons-vue'

const router = useRouter()
const route = useRoute()
const themeStore = useThemeStore()

const title = ref('Kunpo.Cur')
const collapsed = ref(false)
const selectedKeys = ref<string[]>([])
const openKeys = ref<string[]>([])

// 根据路由更新选中的菜单项
const updateSelectedKeys = () => {
  const path = route.path
  selectedKeys.value = [path.split('/')[1]]
  openKeys.value = [path.split('/')[1]]
}

// 菜单项配置
const menuItems = computed(() => [
  {
    key: 'dashboard',
    icon: () => h(DashboardOutlined),
    label: '仪表盘',
    title: '仪表盘'
  },
  {
    key: 'system',
    icon: () => h(SettingOutlined),
    label: '系统管理',
    title: '系统管理',
    children: [
      {
        key: 'user',
        icon: () => h(UserOutlined),
        label: '用户管理',
        title: '用户管理'
      },
      {
        key: 'role',
        icon: () => h(TeamOutlined),
        label: '角色管理',
        title: '角色管理'
      }
    ]
  }
])

const handleMenuClick: MenuClickEventHandler = ({ key }) => {
  router.push(`/${key}`)
}

// 监听路由变化
watch(() => route.path, () => {
  updateSelectedKeys()
})

onMounted(() => {
  updateSelectedKeys()
})
</script>

<style lang="less" scoped>
.kp-sider {
  height: 100vh;
  overflow: auto;

  &-logo {
    height: 64px;
    padding: 16px;
    display: flex;
    align-items: center;
    overflow: hidden;

    img {
      height: 32px;
      margin-right: 8px;
    }

    h1 {
      margin: 0;
      font-size: 18px;
      font-weight: 600;
      white-space: nowrap;
    }
  }
}
</style>