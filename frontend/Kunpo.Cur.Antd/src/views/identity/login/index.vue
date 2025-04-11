<template>
  <a-layout class="login-container">
    <div class="login-actions">
      <KpLocale />
      <KpTheme />
    </div>
    <a-layout-content class="login-content">
      <a-row :gutter="0">
        <a-col :span="12">
          <a-card class="login-card">
            <div class="login-banner">
              <img src="@/assets/images/logo.svg" alt="logo" />
              <h1>Kunpo.Cur</h1>
              <h2>{{ t('login.slogan') }}</h2>
              <p>{{ t('login.description') }}</p>
            </div>
          </a-card>
        </a-col>
        <a-col :span="12">
          <a-card class="login-card">
            <div class="login-form-container">
              <div class="login-form-header">
                <h3>{{ t('login.welcome') }}</h3>
                <p>{{ t('login.tip') }}</p>
              </div>
              <a-form :model="formState" name="login" @finish="onFinish">
                <a-form-item name="username" :rules="[{ required: true, message: t('login.usernameRequired') }]">
                  <a-input v-model:value="formState.username" :placeholder="t('login.username')">
                    <template #prefix>
                      <UserOutlined />
                    </template>
                  </a-input>
                </a-form-item>
                <a-form-item name="password" :rules="[{ required: true, message: t('login.passwordRequired') }]">
                  <a-input-password v-model:value="formState.password" :placeholder="t('login.password')">
                    <template #prefix>
                      <LockOutlined />
                    </template>
                  </a-input-password>
                </a-form-item>
                <a-form-item>
                  <SlideVerify @success="onVerifySuccess" @fail="onVerifyFail" />
                </a-form-item>
                <a-form-item>
                  <a-checkbox v-model:checked="formState.remember">{{ t('login.remember') }}</a-checkbox>
                  <a class="login-form-forgot" href="">{{ t('login.forgot') }}</a>
                </a-form-item>
                <a-form-item>
                  <a-button type="primary" html-type="submit" :loading="loading" block :disabled="!isVerified">
                    {{ t('login.submit') }}
                  </a-button>
                </a-form-item>
              </a-form>
            </div>
          </a-card>
        </a-col>
      </a-row>
    </a-layout-content>
  </a-layout>
</template>

<script setup lang="ts">
import { ref, reactive } from 'vue'
import { useRouter } from 'vue-router'
import { useI18n } from 'vue-i18n'
import { UserOutlined, LockOutlined } from '@ant-design/icons-vue'
import { message } from 'ant-design-vue'
import SlideVerify from './component/SlideVerify.vue'

const { t } = useI18n()
const router = useRouter()
const loading = ref(false)
const isVerified = ref(false)

const formState = reactive({
  username: '',
  password: '',
  remember: true
})

const onVerifySuccess = () => {
  isVerified.value = true
}

const onVerifyFail = () => {
  isVerified.value = false
  message.error(t('login.captchaError'))
}

const onFinish = async (values: any) => {
  if (!isVerified.value) {
    message.error(t('login.captchaRequired'))
    return
  }

  loading.value = true
  try {
    // TODO: 实现登录逻辑
    await new Promise(resolve => setTimeout(resolve, 1000))
    message.success(t('login.success'))
    router.push('/dashboard')
  } catch (error) {
    message.error(t('login.error'))
  } finally {
    loading.value = false
  }
}
</script>

<style lang="less" scoped>
.login-container {
  min-height: 100vh;
  position: relative;

  .login-actions {
    position: absolute;
    top: 80px;
    right: 80px;
    display: flex;
    gap: 16px;
  }

  .login-content {
    display: flex;
    align-items: center;
    justify-content: center;
    min-height: 100vh;
    padding: 20px;

    .login-card {
      height: 100%;
      min-height: 500px;
      display: flex;
      align-items: center;
      justify-content: center;

      .login-banner {
        text-align: center;
        max-width: 500px;
        margin: 0 auto;

        img {
          height: 80px;
          margin-bottom: 24px;
        }

        h1 {
          margin: 0 0 16px;
          font-size: 36px;
          font-weight: 600;
        }

        h2 {
          margin: 0 0 16px;
          font-size: 24px;
          font-weight: 500;
        }

        p {
          margin: 0;
          font-size: 16px;
          line-height: 1.6;
        }
      }

      .login-form-container {
        width: 100%;
        padding: 40px;

        .login-form-header {
          text-align: center;
          margin-bottom: 40px;

          h3 {
            margin: 0 0 8px;
            font-size: 24px;
            font-weight: 600;
          }

          p {
            margin: 0;
            font-size: 14px;
          }
        }

        .login-form-forgot {
          float: right;
        }
      }
    }
  }
}

@media (max-width: 768px) {
  .login-container {
    .login-actions {
      top: 20px;
      right: 20px;
    }

    .login-content {
      .login-card {
        min-height: auto;

        .login-banner {
          img {
            height: 60px;
          }

          h1 {
            font-size: 28px;
          }

          h2 {
            font-size: 20px;
          }
        }

        .login-form-container {
          padding: 20px;
        }
      }
    }
  }
}
</style>
