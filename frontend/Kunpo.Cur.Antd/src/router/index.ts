import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: '/login'
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('@/views/identity/login/index.vue'),
      meta: {
        title: '登录',
        requiresAuth: false
      }
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: () => import('@/views/dashboard/home/index.vue'),
      meta: {
        title: '仪表盘',
        icon: 'DashboardOutlined',
        requiresAuth: true
      }
    },
    {
      path: '/dashboard/analysis',
      name: 'dashboard-analysis',
      component: () => import('@/views/dashboard/analysis/index.vue'),
      meta: {
        title: '分析页',
        requiresAuth: true
      }
    },
    {
      path: '/dashboard/monitor',
      name: 'dashboard-monitor',
      component: () => import('@/views/dashboard/monitor/index.vue'),
      meta: {
        title: '监控页',
        requiresAuth: true
      }
    },
    {
      path: '/about',
      name: 'about',
      component: () => import('@/views/about/about/index.vue'),
      meta: {
        title: '关于',
        icon: 'InfoCircleOutlined',
        requiresAuth: true
      }
    },
    {
      path: '/about/service',
      name: 'about-service',
      component: () => import('@/views/about/service/index.vue'),
      meta: {
        title: '服务',
        requiresAuth: true
      }
    },
    {
      path: '/about/privacy',
      name: 'about-privacy',
      component: () => import('@/views/about/privacy/index.vue'),
      meta: {
        title: '隐私政策',
        requiresAuth: true
      }
    }
  ]
})

// 路由守卫
router.beforeEach((to, from, next) => {
  const isAuthenticated = localStorage.getItem('token') // 这里需要根据实际情况修改
  const requiresAuth = to.matched.some(record => record.meta.requiresAuth)

  if (requiresAuth && !isAuthenticated) {
    next('/login')
  } else if (to.path === '/login' && isAuthenticated) {
    next('/dashboard')
  } else {
    next()
  }
})

export default router 