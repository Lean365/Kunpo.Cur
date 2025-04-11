import { createI18n } from 'vue-i18n'
import loginZhCN from './identity/login/zh-CN'
import loginEnUS from './identity/login/en-US'
import commonZhCN from './common/zh-CN'
import commonEnUS from './common/en-US'

const messages = {
  'zh-CN': {
    ...loginZhCN,
    ...commonZhCN
  },
  'en-US': {
    ...loginEnUS,
    ...commonEnUS
  }
}

const savedLocale = localStorage.getItem('locale') || 'zh-CN'

const i18n = createI18n({
  legacy: false,
  locale: savedLocale,
  fallbackLocale: 'en-US',
  messages,
  sync: true,
  silentTranslationWarn: true,
  missingWarn: false
})

export default i18n 