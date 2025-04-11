<template>
  <a-layout class="basic-layout">
    <a-layout-header class="header">
      <KpHeader />
    </a-layout-header>
    <a-layout>
      <a-layout-sider class="sider">
        <KpSider />
      </a-layout-sider>
      <a-layout-content class="content">
        <router-view />
      </a-layout-content>
    </a-layout>
    <a-layout-footer class="footer">
      <KpFooter />
    </a-layout-footer>
  </a-layout>
</template>

<script setup lang="ts">
// 组件会自动导入，不需要手动导入
</script>

<style lang="less" scoped>
.basic-layout {
  min-height: 100vh;

  .header {
    position: fixed;
    z-index: 1;
    width: 100%;
    padding: 0;
    height: 64px;
    line-height: 64px;
  }

  .sider {
    position: fixed;
    left: 0;
    top: 64px;
    bottom: 0;
    overflow: auto;
  }

  .content {
    margin: 64px 0 0 200px;
    padding: 24px;
    min-height: 280px;
  }

  .footer {
    text-align: center;
    margin-left: 200px;
  }
}
</style>