<template>
  <div class="kp-screen">
    <el-button :type="type" :size="size" :icon="isFullscreen ? 'FullScreen' : 'Aim'" @click="toggle">
      {{ isFullscreen ? t('common.exitFullscreen') : t('common.fullscreen') }}
    </el-button>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue'
import { useI18n } from 'vue-i18n'
import { FullScreen, Aim } from '@element-plus/icons-vue'

const props = withDefaults(defineProps<{
  type?: 'primary' | 'success' | 'warning' | 'danger' | 'info'
  size?: 'large' | 'default' | 'small'
}>(), {
  type: 'primary',
  size: 'default'
})

const { t } = useI18n()
const isFullscreen = ref(false)

const toggle = () => {
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

<style scoped>
.kp-screen {
  display: inline-block;
}
</style>