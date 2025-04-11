<template>
  <div class="analysis-container">
    <a-row :gutter="16">
      <a-col :span="16">
        <a-card title="访问趋势">
          <template #extra>
            <a-radio-group v-model:value="timeRange" size="small">
              <a-radio-button value="week">本周</a-radio-button>
              <a-radio-button value="month">本月</a-radio-button>
              <a-radio-button value="year">全年</a-radio-button>
            </a-radio-group>
          </template>
          <div class="chart-container">
            <!-- 这里可以集成图表库，如 ECharts -->
            <div class="chart-placeholder">访问趋势图表</div>
          </div>
        </a-card>
      </a-col>
      <a-col :span="8">
        <a-card title="访问来源">
          <div class="chart-container">
            <!-- 这里可以集成图表库，如 ECharts -->
            <div class="chart-placeholder">访问来源饼图</div>
          </div>
        </a-card>
      </a-col>
    </a-row>
    <a-row :gutter="16" class="mt-16">
      <a-col :span="12">
        <a-card title="热门页面">
          <a-table :columns="columns" :data-source="data" :pagination="false" size="small">
            <template #bodyCell="{ column, record }">
              <template v-if="column.key === 'trend'">
                <span :class="['trend', record.trend > 0 ? 'up' : 'down']">
                  {{ record.trend > 0 ? '↑' : '↓' }} {{ Math.abs(record.trend) }}%
                </span>
              </template>
            </template>
          </a-table>
        </a-card>
      </a-col>
      <a-col :span="12">
        <a-card title="用户分布">
          <a-table :columns="columns" :data-source="data" :pagination="false" size="small">
            <template #bodyCell="{ column, record }">
              <template v-if="column.key === 'trend'">
                <span :class="['trend', record.trend > 0 ? 'up' : 'down']">
                  {{ record.trend > 0 ? '↑' : '↓' }} {{ Math.abs(record.trend) }}%
                </span>
              </template>
            </template>
          </a-table>
        </a-card>
      </a-col>
    </a-row>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import type { TableColumnsType } from 'ant-design-vue'

const timeRange = ref('week')

const columns: TableColumnsType = [
  {
    title: '页面',
    dataIndex: 'page',
    key: 'page'
  },
  {
    title: '访问量',
    dataIndex: 'visits',
    key: 'visits'
  },
  {
    title: '趋势',
    dataIndex: 'trend',
    key: 'trend'
  }
]

const data = [
  {
    key: '1',
    page: '首页',
    visits: 1234,
    trend: 12
  },
  {
    key: '2',
    page: '分析页',
    visits: 567,
    trend: -3
  },
  {
    key: '3',
    page: '监控页',
    visits: 890,
    trend: 8
  }
]
</script>

<style lang="less" scoped>
.analysis-container {
  padding: 24px;

  .mt-16 {
    margin-top: 16px;
  }

  .chart-container {
    height: 300px;
    display: flex;
    align-items: center;
    justify-content: center;
    background: #f5f5f5;
    border-radius: 4px;

    .chart-placeholder {
      color: #999;
    }
  }

  .trend {
    &.up {
      color: #52c41a;
    }

    &.down {
      color: #f5222d;
    }
  }
}
</style>