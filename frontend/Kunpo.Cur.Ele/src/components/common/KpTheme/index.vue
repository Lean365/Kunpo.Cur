<template>
  <el-dropdown @command="handleThemeChange">
    <span class="el-dropdown-link">
      <el-icon>
        <component :is="currentTheme === 'dark' ? 'Moon' : 'Sunny'" />
      </el-icon>
      <span class="theme-text">{{ currentTheme === 'dark' ? t('theme.dark') : t('theme.light') }}</span>
      <el-icon class="el-icon--right"><arrow-down /></el-icon>
    </span>
    <template #dropdown>
      <el-dropdown-menu>
        <el-dropdown-item command="light">
          <el-icon>
            <Sunny />
          </el-icon>
          {{ t('theme.light') }}
        </el-dropdown-item>
        <el-dropdown-item command="dark">
          <el-icon>
            <Moon />
          </el-icon>
          {{ t('theme.dark') }}
        </el-dropdown-item>
      </el-dropdown-menu>
    </template>
  </el-dropdown>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import { useI18n } from 'vue-i18n'
import { ArrowDown, Moon, Sunny } from '@element-plus/icons-vue'

const props = defineProps<{
  modelValue?: 'light' | 'dark'
}>()

const emit = defineEmits<{
  (e: 'update:modelValue', value: 'light' | 'dark'): void
}>()

const { t } = useI18n()

const currentTheme = computed({
  get: () => props.modelValue || 'light',
  set: (value) => emit('update:modelValue', value)
})

const handleThemeChange = (theme: 'light' | 'dark') => {
  currentTheme.value = theme
  // 更新 HTML 根元素的 class
  document.documentElement.classList.toggle('dark', theme === 'dark')
}
</script>

<style scoped>
.el-dropdown-link {
  cursor: pointer;
  display: flex;
  align-items: center;
  color: #606266;
}

.el-dropdown-link:hover {
  color: var(--el-color-primary);
}

.theme-text {
  margin: 0 4px;
}

:deep(.el-dropdown-menu__item) {
  display: flex;
  align-items: center;
  gap: 8px;
}
</style>