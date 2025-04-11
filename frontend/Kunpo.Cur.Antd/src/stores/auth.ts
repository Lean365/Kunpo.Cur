import { defineStore } from 'pinia'
import { ref } from 'vue'
import { message } from 'ant-design-vue'
import { request } from '@/utils/request'
import router from '@/router'

export const useAuthStore = defineStore('auth', () => {
  const user = ref<any>(null)
  const token = ref<string | null>(localStorage.getItem('token'))

  const login = async (values: { username: string; password: string }) => {
    try {
      const response = await request.post('/api/auth/login', values)
      const { token: newToken, user: userData } = response.data
      
      // 存储 token
      token.value = newToken
      localStorage.setItem('token', newToken)
      
      // 存储用户信息
      user.value = userData
      
      message.success('登录成功')
      router.push('/')
      
      return userData
    } catch (error: any) {
      message.error(error.response?.data?.message || '登录失败')
      throw error
    }
  }

  const logout = () => {
    token.value = null
    user.value = null
    localStorage.removeItem('token')
    router.push('/login')
  }

  const checkAuth = async () => {
    if (!token.value) {
      return false
    }

    try {
      const response = await request.get('/api/auth/me')
      user.value = response.data
      return true
    } catch (error) {
      token.value = null
      localStorage.removeItem('token')
      return false
    }
  }

  return {
    user,
    token,
    login,
    logout,
    checkAuth
  }
}) 