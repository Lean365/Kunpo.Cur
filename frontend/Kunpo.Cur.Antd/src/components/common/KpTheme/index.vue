<template>
  <a-tooltip placement="left" title="主题">
    <a-dropdown>
      <a-button type="text">
        <template #icon>
          <BulbOutlined />
        </template>
      </a-button>
      <template #overlay>
        <a-menu @click="handleThemeChange">
          <a-menu-item key="light">
            <template #icon>
              <BulbOutlined />
            </template>
            <span>浅色主题</span>
          </a-menu-item>
          <a-menu-item key="dark">
            <template #icon>
              <BulbFilled />
            </template>
            <span>深色主题</span>
          </a-menu-item>
        </a-menu>
      </template>
    </a-dropdown>
  </a-tooltip>
</template>

<script lang="ts" setup>
import { BulbOutlined, BulbFilled } from '@ant-design/icons-vue'
import { useThemeStore } from '@/stores/theme'
import { theme as antTheme } from 'ant-design-vue'
import type { MenuClickEventHandler } from 'ant-design-vue/es/menu/src/interface'

const themeStore = useThemeStore()

const handleThemeChange: MenuClickEventHandler = ({ key }) => {
  themeStore.setTheme(key as 'light' | 'dark')
}
</script>