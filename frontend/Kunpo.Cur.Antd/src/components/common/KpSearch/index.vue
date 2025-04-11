<template>
  <a-tooltip :title="t('header.search')">
    <a-input-search v-model:value="searchText" :placeholder="t('header.searchPlaceholder')" style="width: 200px"
      @search="onSearch">
      <template #prefix>
        <search-outlined />
      </template>
    </a-input-search>
  </a-tooltip>

  <a-modal v-model:open="visible" :title="t('header.search')" :footer="null" :width="600" @cancel="handleCancel">
    <a-tabs v-model:activeKey="activeTab">
      <a-tab-pane key="menu" :tab="t('header.searchMenu')">
        <a-list :data-source="filteredMenuItems" :loading="loading" :pagination="{ pageSize: 5 }">
          <template #renderItem="{ item }">
            <a-list-item @click="handleMenuClick(item)">
              <a-list-item-meta>
                <template #title>
                  <span>{{ item.label }}</span>
                </template>
                <template #description>
                  <span>{{ item.path }}</span>
                </template>
              </a-list-item-meta>
            </a-list-item>
          </template>
        </a-list>
      </a-tab-pane>
      <a-tab-pane key="content" :tab="t('header.searchContent')">
        <a-list :data-source="filteredContentItems" :loading="loading" :pagination="{ pageSize: 5 }">
          <template #renderItem="{ item }">
            <a-list-item @click="handleContentClick(item)">
              <a-list-item-meta>
                <template #title>
                  <span>{{ item.title }}</span>
                </template>
                <template #description>
                  <span>{{ item.description }}</span>
                </template>
              </a-list-item-meta>
            </a-list-item>
          </template>
        </a-list>
      </a-tab-pane>
    </a-tabs>
  </a-modal>
</template>

<script lang="ts" setup>
import { ref, computed } from 'vue'
import { useI18n } from 'vue-i18n'
import { useRouter } from 'vue-router'
import { SearchOutlined } from '@ant-design/icons-vue'

const { t } = useI18n()
const router = useRouter()

const searchText = ref('')
const visible = ref(false)
const activeTab = ref('menu')
const loading = ref(false)

// 模拟菜单数据
const menuItems = [
  {
    key: 'dashboard',
    label: t('menu.dashboard'),
    path: '/dashboard'
  },
  {
    key: 'user',
    label: t('menu.user'),
    path: '/system/user'
  },
  {
    key: 'role',
    label: t('menu.role'),
    path: '/system/role'
  }
]

// 模拟内容数据
const contentItems = [
  {
    id: 1,
    title: t('content.userManagement'),
    description: t('content.userManagementDesc'),
    path: '/system/user'
  },
  {
    id: 2,
    title: t('content.roleManagement'),
    description: t('content.roleManagementDesc'),
    path: '/system/role'
  }
]

const filteredMenuItems = computed(() => {
  if (!searchText.value) return []
  return menuItems.filter(item =>
    item.label.toLowerCase().includes(searchText.value.toLowerCase())
  )
})

const filteredContentItems = computed(() => {
  if (!searchText.value) return []
  return contentItems.filter(item =>
    item.title.toLowerCase().includes(searchText.value.toLowerCase()) ||
    item.description.toLowerCase().includes(searchText.value.toLowerCase())
  )
})

const onSearch = (value: string) => {
  if (value) {
    visible.value = true
    loading.value = true
    // 模拟加载延迟
    setTimeout(() => {
      loading.value = false
    }, 500)
  }
}

const handleMenuClick = (item: any) => {
  router.push(item.path)
  visible.value = false
}

const handleContentClick = (item: any) => {
  router.push(item.path)
  visible.value = false
}

const handleCancel = () => {
  visible.value = false
  searchText.value = ''
}
</script>