import { createI18n } from 'vue-i18n'
import type { App } from 'vue'
import zhCN from '@/locales/zh-CN'
import enUS from '@/locales/en-US'

const i18n = createI18n({
  legacy: false,
  locale: 'zh-CN',
  fallbackLocale: 'en-US',
  messages: {
    'zh-CN': zhCN,
    'en-US': enUS
  }
})

export function setupI18n(app: App) {
  app.use(i18n)
} 