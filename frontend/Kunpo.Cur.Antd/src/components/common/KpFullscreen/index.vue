<template>
  <a-tooltip :title="isFullscreen ? t('header.exitFullscreen') : t('header.fullscreen')">
    <a-button type="text" @click="toggleFullscreen">
      <template #icon>
        <fullscreen-outlined v-if="!isFullscreen" />
        <fullscreen-exit-outlined v-else />
      </template>
    </a-button>
  </a-tooltip>
</template>

<script lang="ts" setup>
import { ref, onMounted, onUnmounted } from 'vue'
import { useI18n } from 'vue-i18n'
import { FullscreenOutlined, FullscreenExitOutlined } from '@ant-design/icons-vue'

const { t } = useI18n()
const isFullscreen = ref(false)

const toggleFullscreen = () => {
  if (!document.fullscreenElement) {
    document.documentElement.requestFullscreen()
  } else {
    document.exitFullscreen()
  }
}

const handleFullscreenChange = () => {
  isFullscreen.value = !!document.fullscreenElement
}

onMounted(() => {
  document.addEventListener('fullscreenchange', handleFullscreenChange)
})

onUnmounted(() => {
  document.removeEventListener('fullscreenchange', handleFullscreenChange)
})
</script>