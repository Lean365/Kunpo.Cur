<template>
  <a-tooltip :title="t('header.settings')">
    <a-button type="text" @click="showDrawer">
      <template #icon>
        <setting-outlined />
      </template>
    </a-button>
  </a-tooltip>

  <a-drawer v-model:open="open" :title="t('header.settings')" placement="right" :width="320">
    <a-divider>{{ t('settings.theme') }}</a-divider>
    <div class="setting-item">
      <span>{{ t('settings.themeMode') }}</span>
      <a-radio-group v-model:value="themeStore.algorithm" button-style="solid">
        <a-radio-button :value="antTheme.defaultAlgorithm">
          {{ t('settings.light') }}
        </a-radio-button>
        <a-radio-button :value="antTheme.darkAlgorithm">
          {{ t('settings.dark') }}
        </a-radio-button>
      </a-radio-group>
    </div>

    <a-divider>{{ t('settings.layout') }}</a-divider>
    <div class="setting-item">
      <span>{{ t('settings.sidebarWidth') }}</span>
      <a-slider v-model:value="sidebarWidth" :min="200" :max="300" :step="10" @change="handleSidebarWidthChange" />
    </div>

    <a-divider>{{ t('settings.other') }}</a-divider>
    <div class="setting-item">
      <span>{{ t('settings.fixedHeader') }}</span>
      <a-switch v-model:checked="fixedHeader" @change="handleFixedHeaderChange" />
    </div>
    <div class="setting-item">
      <span>{{ t('settings.fixedSidebar') }}</span>
      <a-switch v-model:checked="fixedSidebar" @change="handleFixedSidebarChange" />
    </div>
  </a-drawer>
</template>

<script lang="ts" setup>
import { ref } from 'vue'
import { useI18n } from 'vue-i18n'
import { useThemeStore } from '@/stores/theme'
import { theme as antTheme } from 'ant-design-vue'
import { SettingOutlined } from '@ant-design/icons-vue'

const { t } = useI18n()
const themeStore = useThemeStore()
const open = ref(false)
const sidebarWidth = ref(256)
const fixedHeader = ref(true)
const fixedSidebar = ref(true)

const showDrawer = () => {
  open.value = true
}

const handleSidebarWidthChange = (value: number) => {
  localStorage.setItem('sidebarWidth', value.toString())
}

const handleFixedHeaderChange = (checked: boolean) => {
  localStorage.setItem('fixedHeader', checked.toString())
}

const handleFixedSidebarChange = (checked: boolean) => {
  localStorage.setItem('fixedSidebar', checked.toString())
}

// 初始化设置
onMounted(() => {
  const savedSidebarWidth = localStorage.getItem('sidebarWidth')
  const savedFixedHeader = localStorage.getItem('fixedHeader')
  const savedFixedSidebar = localStorage.getItem('fixedSidebar')

  if (savedSidebarWidth) {
    sidebarWidth.value = parseInt(savedSidebarWidth)
  }
  if (savedFixedHeader) {
    fixedHeader.value = savedFixedHeader === 'true'
  }
  if (savedFixedSidebar) {
    fixedSidebar.value = savedFixedSidebar === 'true'
  }
})
</script>

<style lang="less" scoped>
.setting-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 16px;
}
</style>