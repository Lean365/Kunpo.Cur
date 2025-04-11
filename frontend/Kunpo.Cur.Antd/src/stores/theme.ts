import { defineStore } from 'pinia'
import { theme as antTheme } from 'ant-design-vue'

export const useThemeStore = defineStore('theme', {
  state: () => ({
    algorithm: antTheme.defaultAlgorithm
  }),
  actions: {
    setTheme(type: 'light' | 'dark') {
      this.algorithm = type === 'dark' ? antTheme.darkAlgorithm : antTheme.defaultAlgorithm
      localStorage.setItem('theme', type)
    },
    initTheme() {
      const savedTheme = localStorage.getItem('theme') as 'light' | 'dark' | null
      if (savedTheme) {
        this.setTheme(savedTheme)
      }
    }
  }
}) 