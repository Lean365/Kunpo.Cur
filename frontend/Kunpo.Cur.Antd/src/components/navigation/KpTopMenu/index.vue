<template>
  <a-menu v-model:selectedKeys="selectedKeys" mode="horizontal"
    :theme="themeStore.algorithm === antTheme.darkAlgorithm ? 'dark' : 'light'" :items="menuItems"
    @click="handleMenuClick" />
</template>

<script lang="ts" setup>
import { ref, computed, h } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { useI18n } from 'vue-i18n'
import { useThemeStore } from '@/stores/theme'
import { theme as antTheme } from 'ant-design-vue'
import {
  DashboardOutlined,
  UserOutlined,
  TeamOutlined,
  SettingOutlined
} from '@ant-design/icons-vue'

const { t } = useI18n()
const router = useRouter()
const route = useRoute()
const themeStore = useThemeStore()

const selectedKeys = ref<string[]>([])

// 根据路由更新选中的菜单项
const updateSelectedKeys = () => {
  const path = route.path
  selectedKeys.value = [path.split('/')[1]]
}

// 菜单项配置
const menuItems = computed(() => [
  {
    key: 'dashboard',
    icon: () => h(DashboardOutlined),
    label: t('menu.dashboard'),
    title: t('menu.dashboard')
  },
  {
    key: 'system',
    icon: () => h(SettingOutlined),
    label: t('menu.system'),
    title: t('menu.system'),
    children: [
      {
        key: 'user',
        icon: () => h(UserOutlined),
        label: t('menu.user'),
        title: t('menu.user')
      },
      {
        key: 'role',
        icon: () => h(TeamOutlined),
        label: t('menu.role'),
        title: t('menu.role')
      }
    ]
  }
])

const handleMenuClick = ({ key }: { key: string }) => {
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
:deep(.ant-menu-horizontal) {
  border-bottom: none;
}
</style>