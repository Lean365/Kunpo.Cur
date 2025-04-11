<template>
  <a-dropdown :trigger="['click']" placement="bottomRight">
    <a-space>
      <a-avatar :src="user.avatar" :size="32" />
      <span class="user-name">{{ user.nickname }}</span>
    </a-space>
    <template #overlay>
      <a-menu>
        <a-menu-item key="profile" @click="handleProfile">
          <template #icon>
            <user-outlined />
          </template>
          {{ t('header.profile') }}
        </a-menu-item>
        <a-menu-item key="settings" @click="handleSettings">
          <template #icon>
            <setting-outlined />
          </template>
          {{ t('header.settings') }}
        </a-menu-item>
        <a-menu-divider />
        <a-menu-item key="logout" @click="handleLogout">
          <template #icon>
            <logout-outlined />
          </template>
          {{ t('header.logout') }}
        </a-menu-item>
      </a-menu>
    </template>
  </a-dropdown>
</template>

<script lang="ts" setup>
import { computed } from 'vue'
import { useRouter } from 'vue-router'
import { useI18n } from 'vue-i18n'
import { useAuthStore } from '@/stores/auth'
import {
  UserOutlined,
  SettingOutlined,
  LogoutOutlined
} from '@ant-design/icons-vue'

const { t } = useI18n()
const router = useRouter()
const authStore = useAuthStore()

// 用户信息
const user = computed(() => ({
  nickname: authStore.user?.nickname || '未登录',
  avatar: authStore.user?.avatar || 'https://api.dicebear.com/7.x/miniavs/svg?seed=0'
}))

// 处理个人资料
const handleProfile = () => {
  router.push('/profile')
}

// 处理设置
const handleSettings = () => {
  router.push('/settings')
}

// 处理退出登录
const handleLogout = async () => {
  try {
    await authStore.logout()
    router.push('/login')
  } catch (error) {
    console.error('退出登录失败:', error)
  }
}
</script>

<style lang="less" scoped>
.user-name {
  margin-left: 8px;
  font-size: 14px;
  color: rgba(0, 0, 0, 0.85);
}
</style>