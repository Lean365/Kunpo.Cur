<template>
  <div class="kp-user">
    <el-dropdown @command="handleCommand">
      <div class="user-info">
        <el-avatar :size="32" :src="avatar" />
        <span class="username">{{ username }}</span>
        <el-icon class="el-icon--right"><arrow-down /></el-icon>
      </div>
      <template #dropdown>
        <el-dropdown-menu>
          <el-dropdown-item command="profile">
            <el-icon>
              <user />
            </el-icon>
            {{ t('common.profile') }}
          </el-dropdown-item>
          <el-dropdown-item command="setting">
            <el-icon>
              <setting />
            </el-icon>
            {{ t('common.setting') }}
          </el-dropdown-item>
          <el-dropdown-item divided command="logout">
            <el-icon><switch-button /></el-icon>
            {{ t('common.logout') }}
          </el-dropdown-item>
        </el-dropdown-menu>
      </template>
    </el-dropdown>
  </div>
</template>

<script setup lang="ts">
import { useI18n } from 'vue-i18n'
import { User, Setting, SwitchButton, ArrowDown } from '@element-plus/icons-vue'

const props = withDefaults(defineProps<{
  username?: string
  avatar?: string
}>(), {
  username: 'Admin',
  avatar: ''
})

const emit = defineEmits<{
  (e: 'command', command: string): void
}>()

const { t } = useI18n()

const handleCommand = (command: string) => {
  emit('command', command)
}
</script>

<style scoped>
.kp-user {
  display: inline-block;
}

.user-info {
  display: flex;
  align-items: center;
  cursor: pointer;
  padding: 0 8px;
}

.username {
  margin: 0 8px;
  font-size: 14px;
  color: #606266;
}
</style>