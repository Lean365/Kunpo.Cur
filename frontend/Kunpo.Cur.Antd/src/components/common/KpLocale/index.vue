<template>
  <a-tooltip placement="left" title="语言">
    <a-dropdown>
      <a-button type="text">
        <template #icon>
          <GlobalOutlined />
        </template>
      </a-button>
      <template #overlay>
        <a-menu @click="handleLocaleChange">
          <a-menu-item key="zh-CN">
            <span>简体中文</span>
          </a-menu-item>
          <a-menu-item key="en-US">
            <span>English</span>
          </a-menu-item>
        </a-menu>
      </template>
    </a-dropdown>
  </a-tooltip>
</template>

<script lang="ts" setup>
import { GlobalOutlined } from '@ant-design/icons-vue'
import { useLocaleStore } from '@/stores/locale'
import { useI18n } from 'vue-i18n'
import type { MenuClickEventHandler } from 'ant-design-vue/es/menu/src/interface'

const localeStore = useLocaleStore()
const { locale } = useI18n()

const handleLocaleChange: MenuClickEventHandler = ({ key }) => {
  const lang = key.toString()
  localeStore.setLocale(lang)
  locale.value = lang
}
</script>