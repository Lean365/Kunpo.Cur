<template>
  <el-header class="kp-header">
    <div class="header-left">
      <slot name="left">
        <el-icon class="collapse-btn" @click="toggleCollapse">
          <component :is="collapseIcon" />
        </el-icon>
      </slot>
    </div>
    <div class="header-right">
      <slot name="right">
        <el-dropdown @command="handleLanguageChange">
          <span class="el-dropdown-link">
            {{ currentLanguage === 'zh-CN' ? '中文' : 'English' }}
            <el-icon class="el-icon--right"><arrow-down /></el-icon>
          </span>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="zh-CN">中文</el-dropdown-item>
              <el-dropdown-item command="en-US">English</el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
        <el-dropdown>
          <span class="el-dropdown-link">
            {{ t('common.admin') }}
            <el-icon class="el-icon--right"><arrow-down /></el-icon>
          </span>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item @click="handleLogout">{{ t('common.logout') }}</el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </slot>
    </div>
  </el-header>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import { useRouter } from 'vue-router/dist/vue-router'
import { useI18n } from 'vue-i18n'
import { Expand, Fold, ArrowDown } from '@element-plus/icons-vue'

const props = defineProps<{
  isCollapse?: boolean
}>()

const emit = defineEmits<{
  (e: 'update:isCollapse', value: boolean): void
  (e: 'logout'): void
}>()

const router = useRouter()
const { locale, t } = useI18n()

const currentLanguage = computed(() => locale.value)

const collapseIcon = computed(() => props.isCollapse ? Expand : Fold)

const toggleCollapse = () => {
  emit('update:isCollapse', !props.isCollapse)
}

const handleLanguageChange = (lang: string) => {
  locale.value = lang
}

const handleLogout = () => {
  emit('logout')
  router.push('/login')
}
</script>

<style scoped>
.kp-header {
  background-color: #fff;
  border-bottom: 1px solid #dcdfe6;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 20px;
  height: 60px;
}

.header-left,
.header-right {
  display: flex;
  align-items: center;
  gap: 20px;
}

.collapse-btn {
  font-size: 20px;
  cursor: pointer;
  color: #909399;
}

.collapse-btn:hover {
  color: var(--el-color-primary);
}

.el-dropdown-link {
  cursor: pointer;
  display: flex;
  align-items: center;
  color: #606266;
}

.el-dropdown-link:hover {
  color: var(--el-color-primary);
}
</style>