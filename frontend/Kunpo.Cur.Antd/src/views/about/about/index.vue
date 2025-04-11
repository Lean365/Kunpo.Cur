<template>
  <div class="about-container">
    <a-row :gutter="24">
      <a-col :span="16">
        <a-card title="关于我们">
          <div class="about-content">
            <h2>公司简介</h2>
            <p>Kunpo.Cur 是一家专注于企业级应用开发的科技公司，致力于为客户提供高质量、高效率的数字化解决方案。</p>

            <h2>我们的使命</h2>
            <p>通过技术创新，帮助企业实现数字化转型，提升运营效率，创造更大的商业价值。</p>

            <h2>我们的愿景</h2>
            <p>成为企业数字化转型的引领者，打造行业标杆，推动产业升级。</p>
          </div>
        </a-card>
      </a-col>
      <a-col :span="8">
        <a-card title="联系方式">
          <a-descriptions :column="1">
            <a-descriptions-item label="公司地址">北京市海淀区中关村科技园</a-descriptions-item>
            <a-descriptions-item label="联系电话">010-12345678</a-descriptions-item>
            <a-descriptions-item label="电子邮箱">contact@kunpo.cur</a-descriptions-item>
            <a-descriptions-item label="工作时间">周一至周五 9:00-18:00</a-descriptions-item>
          </a-descriptions>
        </a-card>
      </a-col>
    </a-row>
  </div>
</template>

<script setup lang="ts">
// 页面逻辑
</script>

<style lang="less" scoped>
.about-container {
  padding: 24px;

  .about-content {
    h2 {
      margin-top: 24px;
      margin-bottom: 16px;
      font-size: 18px;
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
  }
}
</style>