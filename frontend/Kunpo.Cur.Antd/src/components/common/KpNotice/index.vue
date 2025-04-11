<template>
  <a-dropdown :trigger="['click']" placement="bottomRight">
    <a-badge :count="unreadCount" :offset="[-5, 5]">
      <a-button type="text">
        <template #icon>
          <bell-outlined />
        </template>
      </a-button>
    </a-badge>
    <template #overlay>
      <a-tabs v-model:activeKey="activeTab" centered>
        <a-tab-pane key="notification" :tab="t('header.notification')">
          <a-list :data-source="notifications" :loading="loading">
            <template #renderItem="{ item }">
              <a-list-item>
                <a-list-item-meta>
                  <template #avatar>
                    <a-avatar :icon="item.icon" :style="{ backgroundColor: item.color }" />
                  </template>
                  <template #title>
                    <span>{{ item.title }}</span>
                  </template>
                  <template #description>
                    <span>{{ item.description }}</span>
                    <div class="notice-time">{{ item.time }}</div>
                  </template>
                </a-list-item-meta>
              </a-list-item>
            </template>
          </a-list>
        </a-tab-pane>
        <a-tab-pane key="message" :tab="t('header.message')">
          <a-list :data-source="messages" :loading="loading">
            <template #renderItem="{ item }">
              <a-list-item>
                <a-list-item-meta>
                  <template #avatar>
                    <a-avatar :src="item.avatar" />
                  </template>
                  <template #title>
                    <span>{{ item.title }}</span>
                  </template>
                  <template #description>
                    <span>{{ item.content }}</span>
                    <div class="notice-time">{{ item.time }}</div>
                  </template>
                </a-list-item-meta>
              </a-list-item>
            </template>
          </a-list>
        </a-tab-pane>
        <a-tab-pane key="todo" :tab="t('header.todo')">
          <a-list :data-source="todos" :loading="loading">
            <template #renderItem="{ item }">
              <a-list-item>
                <a-list-item-meta>
                  <template #avatar>
                    <a-avatar :icon="item.icon" :style="{ backgroundColor: item.color }" />
                  </template>
                  <template #title>
                    <span>{{ item.title }}</span>
                  </template>
                  <template #description>
                    <span>{{ item.description }}</span>
                    <div class="notice-time">{{ item.time }}</div>
                  </template>
                </a-list-item-meta>
              </a-list-item>
            </template>
          </a-list>
        </a-tab-pane>
      </a-tabs>
    </template>
  </a-dropdown>
</template>

<script lang="ts" setup>
import { ref, computed } from 'vue'
import { useI18n } from 'vue-i18n'
import { BellOutlined } from '@ant-design/icons-vue'

const { t } = useI18n()

const activeTab = ref('notification')
const loading = ref(false)

// 模拟通知数据
const notifications = [
  {
    id: 1,
    title: t('notification.systemUpdate'),
    description: t('notification.systemUpdateDesc'),
    time: '10分钟前',
    icon: 'notification',
    color: '#1890ff'
  },
  {
    id: 2,
    title: t('notification.securityAlert'),
    description: t('notification.securityAlertDesc'),
    time: '30分钟前',
    icon: 'warning',
    color: '#ff4d4f'
  }
]

// 模拟消息数据
const messages = [
  {
    id: 1,
    title: t('message.newMessage'),
    content: t('message.newMessageContent'),
    time: '1小时前',
    avatar: 'https://api.dicebear.com/7.x/miniavs/svg?seed=1'
  },
  {
    id: 2,
    title: t('message.reply'),
    content: t('message.replyContent'),
    time: '2小时前',
    avatar: 'https://api.dicebear.com/7.x/miniavs/svg?seed=2'
  }
]

// 模拟待办事项数据
const todos = [
  {
    id: 1,
    title: t('todo.task1'),
    description: t('todo.task1Desc'),
    time: '今天',
    icon: 'check-circle',
    color: '#52c41a'
  },
  {
    id: 2,
    title: t('todo.task2'),
    description: t('todo.task2Desc'),
    time: '今天',
    icon: 'clock-circle',
    color: '#faad14'
  }
]

// 计算未读消息总数
const unreadCount = computed(() => {
  return notifications.length + messages.length + todos.length
})
</script>

<style lang="less" scoped>
.notice-time {
  color: rgba(0, 0, 0, 0.45);
  font-size: 12px;
  margin-top: 4px;
}

:deep(.ant-dropdown-menu) {
  padding: 0;
}

:deep(.ant-tabs-nav) {
  margin: 0;
}

:deep(.ant-list-item) {
  padding: 12px 24px;
  cursor: pointer;
  transition: all 0.3s;

  &:hover {
    background-color: rgba(0, 0, 0, 0.02);
  }
}
</style>