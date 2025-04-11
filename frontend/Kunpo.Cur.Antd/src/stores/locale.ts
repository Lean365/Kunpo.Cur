import { defineStore } from 'pinia'
import { ref } from 'vue'
import zhCN from 'ant-design-vue/es/locale/zh_CN'
import enUS from 'ant-design-vue/es/locale/en_US'

export const useLocaleStore = defineStore('locale', () => {
  const locale = ref(localStorage.getItem('locale') || 'zh-CN')
  const antLocale = ref(locale.value === 'zh-CN' ? zhCN : enUS)

  const setLocale = (lang: string) => {
    locale.value = lang
    antLocale.value = lang === 'zh-CN' ? zhCN : enUS
    localStorage.setItem('locale', lang)
  }

  const initLocale = () => {
    const savedLocale = localStorage.getItem('locale')
    if (savedLocale) {
      setLocale(savedLocale)
    }
  }

  return {
    locale,
    antLocale,
    setLocale,
    initLocale
  }
}) 