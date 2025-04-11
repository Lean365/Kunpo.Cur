<template>
  <a-layout-header class="kp-header">
    <div class="kp-header-left">
      <div class="kp-header-logo">
        <img src="@/assets/images/logo.svg" alt="logo" />
        <h1>{{ title }}</h1>
      </div>
      <a-menu v-model:selectedKeys="selectedKeys" mode="horizontal" :items="menuItems" @click="handleMenuClick" />
    </div>
    <div class="kp-header-right">
      <a-space>
        <a-tooltip :title="t('header.search')">
          <a-input-search v-model:value="searchValue" :placeholder="t('header.searchPlaceholder')" style="width: 200px"
            @search="handleSearch" />
        </a-tooltip>
        <a-tooltip :title="t('header.fullscreen')">
          <fullscreen-outlined @click="toggleFullscreen" />
        </a-tooltip>
        <a-tooltip :title="t('header.theme')">
          <kp-theme />
        </a-tooltip>
        <a-tooltip :title="t('header.locale')">
          <kp-locale />
        </a-tooltip>
        <a-dropdown>
          <a-space>
            <a-avatar :src="userInfo.avatar" />
            <span>{{ userInfo.nickName }}</span>
          </a-space>
          <template #overlay>
            <a-menu>
              <a-menu-item key="profile">
                <user-outlined />
                {{ t('header.profile') }}
              </a-menu-item>
              <a-menu-item key="settings">
                <setting-outlined />
                {{ t('header.settings') }}
              </a-menu-item>
              <a-menu-divider />
              <a-menu-item key="logout" @click="handleLogout">
                <logout-outlined />
                {{ t('header.logout') }}
              </a-menu-item>
            </a-menu>
          </template>
        </a-dropdown>
      </a-space>
    </div>
  </a-layout-header>
</template>

<script lang="ts" setup>
import { ref, computed, h } from 'vue'
import { useRouter } from 'vue-router'
import { useI18n } from 'vue-i18n'
import { useAuthStore } from '@/stores/auth'
import { useLocaleStore } from '@/stores/locale'
import { useThemeStore } from '@/stores/theme'
import {
  FullscreenOutlined,
  UserOutlined,
  SettingOutlined,
  LogoutOutlined,
  DashboardOutlined
} from '@ant-design/icons-vue'
import KpTheme from '@/components/common/KpTheme/index.vue'
import KpLocale from '@/components/common/KpLocale/index.vue'

const { t } = useI18n()
const router = useRouter()
const authStore = useAuthStore()
const localeStore = useLocaleStore()
const themeStore = useThemeStore()

const title = ref('Kunpo.Cur')
const searchValue = ref('')
const selectedKeys = ref<string[]>([])

const userInfo = computed(() => ({
  nickName: authStore.user?.nickName || 'Guest',
  avatar: authStore.user?.avatar || ''
}))

const menuItems = computed(() => [
  {
    key: 'dashboard',
    label: t('menu.dashboard'),
    icon: () => h(DashboardOutlined)
  },
  {
    key: 'system',
    label: t('menu.system'),
    icon: () => h(SettingOutlined),
    children: [
      {
        key: 'user',
        label: t('menu.user')
      },
      {
        key: 'role',
        label: t('menu.role')
      }
    ]
  }
])

const handleMenuClick = ({ key }: { key: string }) => {
  router.push(`/${key}`)
}

const handleSearch = (value: string) => {
  console.log('search:', value)
}

const toggleFullscreen = () => {
  if (!document.fullscreenElement) {
    document.documentElement.requestFullscreen()
  } else {
    document.exitFullscreen()
  }
}

const handleLogout = async () => {
  await authStore.logout()
  router.push('/login')
}
</script>

<style lang="less" scoped>
.kp-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 0 24px;
  background: #fff;
  box-shadow: 0 1px 4px rgba(0, 21, 41, 0.08);

  &-left {
    display: flex;
    align-items: center;
  }

  &-logo {
    display: flex;
    align-items: center;
    margin-right: 24px;

    img {
      height: 32px;
      margin-right: 8px;
    }

    h1 {
      margin: 0;
      font-size: 18px;
      font-weight: 600;
    }
  }

  &-right {
    display: flex;
    align-items: center;
  }
}

:deep(.ant-menu-horizontal) {
  border-bottom: none;
}
</style>