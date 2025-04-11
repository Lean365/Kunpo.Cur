<template>
  <div class="login-container">
    <el-card class="login-card">
      <template #header>
        <div class="login-header">
          <img src="@/assets/logo.png" class="login-logo" alt="logo" />
          <h2 class="login-title">Kunpo.Cur</h2>
        </div>
      </template>
      <el-form ref="formRef" :model="formData" :rules="rules" label-width="0" size="large" @keyup.enter="handleLogin">
        <el-form-item prop="username">
          <el-input v-model="formData.username" :placeholder="$t('common.username')">
            <template #prefix>
              <el-icon><i-ep-user /></el-icon>
            </template>
          </el-input>
        </el-form-item>
        <el-form-item prop="password">
          <el-input v-model="formData.password" type="password" :placeholder="$t('common.password')" show-password>
            <template #prefix>
              <el-icon><i-ep-lock /></el-icon>
            </template>
          </el-input>
        </el-form-item>
        <el-form-item>
          <div class="login-options">
            <el-checkbox v-model="rememberMe">{{ $t('login.rememberMe') }}</el-checkbox>
            <el-dropdown @command="handleLanguageChange" trigger="click">
              <span class="language-switch">
                {{ currentLanguage === 'zh-CN' ? '中文' : 'English' }}
                <el-icon><i-ep-caret-bottom /></el-icon>
              </span>
              <template #dropdown>
                <el-dropdown-menu>
                  <el-dropdown-item command="zh-CN">中文</el-dropdown-item>
                  <el-dropdown-item command="en-US">English</el-dropdown-item>
                </el-dropdown-menu>
              </template>
            </el-dropdown>
          </div>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" :loading="loading" class="login-button" @click="handleLogin">
            {{ $t('common.login') }}
          </el-button>
        </el-form-item>
      </el-form>
    </el-card>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, computed } from 'vue'
import { useRouter } from 'vue-router/dist/vue-router'
import { useI18n } from 'vue-i18n'
import type { FormInstance } from 'element-plus'
import { ElMessage } from 'element-plus'

interface LoginForm {
  username: string
  password: string
}

const router = useRouter()
const { t, locale } = useI18n()
const formRef = ref<FormInstance>()
const loading = ref(false)
const rememberMe = ref(false)

const formData = reactive<LoginForm>({
  username: '',
  password: ''
})

const currentLanguage = computed(() => locale.value)

const rules = {
  username: [
    { required: true, message: t('login.usernameRequired'), trigger: 'blur' }
  ],
  password: [
    { required: true, message: t('login.passwordRequired'), trigger: 'blur' }
  ]
}

const handleLanguageChange = (lang: string) => {
  locale.value = lang
}

const handleLogin = async () => {
  if (!formRef.value) return

  await formRef.value.validate(async (valid: boolean) => {
    if (valid) {
      loading.value = true
      try {
        // TODO: 实现登录逻辑
        ElMessage.success(t('login.loginSuccess'))
        router.push('/')
      } catch (error) {
        ElMessage.error(t('login.loginFailed'))
      } finally {
        loading.value = false
      }
    }
  })
}
</script>

<style scoped>
.login-container {
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: #f5f7fa;
  background-image: linear-gradient(135deg, #f5f7fa 0%, #c3cfe2 100%);
}

.login-card {
  width: 400px;
  border-radius: 8px;
}

.login-card :deep(.el-card__header) {
  padding: 0;
}

.login-header {
  padding: 20px;
  text-align: center;
  background: linear-gradient(to right, #3498db, #2980b9);
  border-radius: 8px 8px 0 0;
}

.login-logo {
  width: 64px;
  height: 64px;
  margin-bottom: 10px;
}

.login-title {
  margin: 0;
  color: #fff;
  font-size: 24px;
}

.login-options {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.language-switch {
  cursor: pointer;
  display: flex;
  align-items: center;
  gap: 4px;
  color: #606266;
}

.login-button {
  width: 100%;
}

:deep(.el-input__wrapper) {
  padding-left: 11px;
}

:deep(.el-input__prefix) {
  margin-right: 8px;
}
</style>