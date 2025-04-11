<template>
  <div class="monitor-container">
    <a-row :gutter="16">
      <a-col :span="8">
        <a-card title="CPU使用率">
          <div class="chart-container">
            <!-- 这里可以集成图表库，如 ECharts -->
            <div class="chart-placeholder">CPU使用率图表</div>
          </div>
          <div class="metric-info">
            <div class="metric-value">45%</div>
            <div class="metric-label">当前使用率</div>
          </div>
        </a-card>
      </a-col>
      <a-col :span="8">
        <a-card title="内存使用率">
          <div class="chart-container">
            <!-- 这里可以集成图表库，如 ECharts -->
            <div class="chart-placeholder">内存使用率图表</div>
          </div>
          <div class="metric-info">
            <div class="metric-value">3.2GB/8GB</div>
            <div class="metric-label">已使用/总内存</div>
          </div>
        </a-card>
      </a-col>
      <a-col :span="8">
        <a-card title="磁盘使用率">
          <div class="chart-container">
            <!-- 这里可以集成图表库，如 ECharts -->
            <div class="chart-placeholder">磁盘使用率图表</div>
          </div>
          <div class="metric-info">
            <div class="metric-value">256GB/512GB</div>
            <div class="metric-label">已使用/总容量</div>
          </div>
        </a-card>
      </a-col>
    </a-row>
    <a-row :gutter="16" class="mt-16">
      <a-col :span="12">
        <a-card title="系统日志">
          <a-timeline>
            <a-timeline-item color="green">系统启动成功 - 2024-01-01 08:00:00</a-timeline-item>
            <a-timeline-item color="blue">数据库连接成功 - 2024-01-01 08:00:01</a-timeline-item>
            <a-timeline-item color="blue">缓存服务启动 - 2024-01-01 08:00:02</a-timeline-item>
            <a-timeline-item color="blue">API服务启动 - 2024-01-01 08:00:03</a-timeline-item>
          </a-timeline>
        </a-card>
      </a-col>
      <a-col :span="12">
        <a-card title="告警信息">
          <a-list :data-source="alerts" :pagination="false">
            <template #renderItem="{ item }">
              <a-list-item>
                <a-list-item-meta>
                  <template #title>
                    <span :class="['alert-title', item.level]">{{ item.title }}</span>
                  </template>
                  <template #description>
                    <span class="alert-time">{{ item.time }}</span>
                  </template>
                </a-list-item-meta>
              </a-list-item>
            </template>
          </a-list>
        </a-card>
      </a-col>
    </a-row>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

interface AlertItem {
  title: string
  time: string
  level: 'info' | 'warning' | 'error'
}

const alerts = ref<AlertItem[]>([
  {
    title: 'CPU使用率超过80%',
    time: '2024-01-01 09:00:00',
    level: 'warning'
  },
  {
    title: '内存使用率超过90%',
    time: '2024-01-01 09:30:00',
    level: 'error'
  },
  {
    title: '磁盘空间不足',
    time: '2024-01-01 10:00:00',
    level: 'warning'
  }
])
</script>

<style lang="less" scoped>
.monitor-container {
  padding: 24px;

  .mt-16 {
    margin-top: 16px;
  }

  .chart-container {
    height: 200px;
    display: flex;
    align-items: center;
    justify-content: center;
    background: #f5f5f5;
    border-radius: 4px;
    margin-bottom: 16px;

    .chart-placeholder {
      color: #999;
    }
  }

  .metric-info {
    text-align: center;

    .metric-value {
      font-size: 24px;
      font-weight: 600;
      color: #1890ff;
    }

    .metric-label {
      font-size: 14px;
      color: #999;
      margin-top: 4px;
    }
  }

  .alert-title {
    &.info {
      color: #1890ff;
    }

    &.warning {
      color: #faad14;
    }

    &.error {
      color: #f5222d;
    }
  }

  .alert-time {
    color: #999;
    font-size: 12px;
  }
}
</style>