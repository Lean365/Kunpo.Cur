<template>
  <div class="dashboard-container">
    <a-row :gutter="16">
      <a-col :span="6">
        <a-card>
          <template #title>总用户数</template>
          <template #extra>
            <UserOutlined />
          </template>
          <div class="card-content">
            <div class="number">1,234</div>
            <div class="trend up">↑ 12%</div>
          </div>
        </a-card>
      </a-col>
      <a-col :span="6">
        <a-card>
          <template #title>总订单数</template>
          <template #extra>
            <ShoppingCartOutlined />
          </template>
          <div class="card-content">
            <div class="number">567</div>
            <div class="trend up">↑ 8%</div>
          </div>
        </a-card>
      </a-col>
      <a-col :span="6">
        <a-card>
          <template #title>总收入</template>
          <template #extra>
            <DollarOutlined />
          </template>
          <div class="card-content">
            <div class="number">¥89,654</div>
            <div class="trend up">↑ 15%</div>
          </div>
        </a-card>
      </a-col>
      <a-col :span="6">
        <a-card>
          <template #title>总访问量</template>
          <template #extra>
            <EyeOutlined />
          </template>
          <div class="card-content">
            <div class="number">8,901</div>
            <div class="trend down">↓ 3%</div>
          </div>
        </a-card>
      </a-col>
    </a-row>
  </div>
</template>

<script setup lang="ts">
import {
  UserOutlined,
  ShoppingCartOutlined,
  DollarOutlined,
  EyeOutlined
} from '@ant-design/icons-vue'
</script>

<style lang="less" scoped>
.dashboard-container {
  padding: 24px;
}

.card-content {
  .number {
    font-size: 24px;
    font-weight: 600;
  }

  .trend {
    font-size: 14px;
    margin-top: 8px;

    &.up {
      color: #52c41a;
    }

    &.down {
      color: #f5222d;
    }
  }
}
</style>