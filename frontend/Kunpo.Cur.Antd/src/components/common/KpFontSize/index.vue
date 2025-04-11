<template>
  <a-tooltip :title="t('header.fontSize')">
    <a-dropdown>
      <a-button type="text">
        <template #icon>
          <font-size-outlined />
        </template>
      </a-button>
      <template #overlay>
        <a-menu @click="handleFontSizeChange">
          <a-menu-item key="small">
            <span>{{ t('header.fontSizeSmall') }}</span>
          </a-menu-item>
          <a-menu-item key="default">
            <span>{{ t('header.fontSizeDefault') }}</span>
          </a-menu-item>
          <a-menu-item key="large">
            <span>{{ t('header.fontSizeLarge') }}</span>
          </a-menu-item>
        </a-menu>
      </template>
    </a-dropdown>
  </a-tooltip>
</template>

<script lang="ts" setup>
import { useI18n } from 'vue-i18n'
import { FontSizeOutlined } from '@ant-design/icons-vue'

const { t } = useI18n()

const handleFontSizeChange = ({ key }: { key: string }) => {
  const html = document.documentElement
  switch (key) {
    case 'small':
      html.style.fontSize = '12px'
      break
    case 'default':
      html.style.fontSize = '14px'
      break
    case 'large':
      html.style.fontSize = '16px'
      break
  }
  localStorage.setItem('fontSize', key)
}
</script>