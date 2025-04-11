<template>
  <div class="service-container">
    <a-row :gutter="24">
      <a-col :span="24">
        <a-card title="我们的服务">
          <a-tabs v-model:activeKey="activeTab">
            <a-tab-pane key="1" tab="企业服务">
              <div class="service-content">
                <h3>企业级应用开发</h3>
                <p>为企业提供定制化的应用开发服务，包括但不限于：</p>
                <ul>
                  <li>企业资源规划（ERP）系统</li>
                  <li>客户关系管理（CRM）系统</li>
                  <li>供应链管理（SCM）系统</li>
                  <li>人力资源管理系统</li>
                </ul>

                <h3>技术咨询服务</h3>
                <p>提供专业的技术咨询服务，帮助企业：</p>
                <ul>
                  <li>制定数字化转型战略</li>
                  <li>优化现有系统架构</li>
                  <li>提升系统性能和安全性</li>
                  <li>实现技术升级和改造</li>
                </ul>
              </div>
            </a-tab-pane>
            <a-tab-pane key="2" tab="价格方案">
              <a-table :columns="columns" :data-source="data" :pagination="false">
                <template #bodyCell="{ column, record }">
                  <template v-if="column.key === 'action'">
                    <a-button type="primary" size="small">立即咨询</a-button>
                  </template>
                </template>
              </a-table>
            </a-tab-pane>
          </a-tabs>
        </a-card>
      </a-col>
    </a-row>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import type { TableColumnsType } from 'ant-design-vue'

const activeTab = ref('1')

const columns: TableColumnsType = [
  {
    title: '服务类型',
    dataIndex: 'type',
    key: 'type'
  },
  {
    title: '基础版',
    dataIndex: 'basic',
    key: 'basic'
  },
  {
    title: '专业版',
    dataIndex: 'professional',
    key: 'professional'
  },
  {
    title: '企业版',
    dataIndex: 'enterprise',
    key: 'enterprise'
  },
  {
    title: '操作',
    key: 'action'
  }
]

const data = [
  {
    key: '1',
    type: '企业应用开发',
    basic: '¥10,000起',
    professional: '¥50,000起',
    enterprise: '¥100,000起'
  },
  {
    key: '2',
    type: '技术咨询',
    basic: '¥5,000/天',
    professional: '¥8,000/天',
    enterprise: '¥15,000/天'
  }
]
</script>

<style lang="less" scoped>
.service-container {
  padding: 24px;

  .service-content {
    h3 {
      margin-top: 24px;
      margin-bottom: 16px;
      font-size: 16px;
      font-weight: 600;
      color: #333;

      &:first-child {
        margin-top: 0;
      }
    }

    p {
      margin-bottom: 16px;
      line-height: 1.8;
      color: #666;
    }

    ul {
      margin-bottom: 16px;
      padding-left: 20px;
      color: #666;

      li {
        margin-bottom: 8px;
        line-height: 1.6;
      }
    }
  }
}
</style>