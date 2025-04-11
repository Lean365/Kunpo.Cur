<template>
  <div class="slide-verify">
    <div class="slide-verify-container">
      <div class="slide-verify-bg" :style="{ backgroundImage: `url(${bgImage})` }">
        <div class="slide-verify-slider" :style="{ left: `${sliderLeft}px` }">
          <div class="slide-verify-slider-mask" :style="{ width: `${sliderLeft}px` }"></div>
          <div class="slide-verify-slider-button" @mousedown="onSliderMouseDown">
            <RightOutlined />
          </div>
        </div>
      </div>
      <div class="slide-verify-tip">{{ t('login.captcha') }}</div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue'
import { useI18n } from 'vue-i18n'
import { RightOutlined } from '@ant-design/icons-vue'

const { t } = useI18n()
const emit = defineEmits(['success', 'fail'])

// 背景图片
const bgImage = ref('https://picsum.photos/300/150')
// 滑块位置
const sliderLeft = ref(0)
// 是否正在拖动
const isDragging = ref(false)
// 开始拖动时的X坐标
const startX = ref(0)
// 开始拖动时的滑块位置
const startLeft = ref(0)

// 鼠标按下事件
const onSliderMouseDown = (e: MouseEvent) => {
  isDragging.value = true
  startX.value = e.clientX
  startLeft.value = sliderLeft.value
  document.addEventListener('mousemove', onMouseMove)
  document.addEventListener('mouseup', onMouseUp)
}

// 鼠标移动事件
const onMouseMove = (e: MouseEvent) => {
  if (!isDragging.value) return

  const moveX = e.clientX - startX.value
  const newLeft = Math.max(0, Math.min(260, startLeft.value + moveX))
  sliderLeft.value = newLeft
}

// 鼠标松开事件
const onMouseUp = () => {
  if (!isDragging.value) return

  isDragging.value = false
  document.removeEventListener('mousemove', onMouseMove)
  document.removeEventListener('mouseup', onMouseUp)

  // 验证是否成功（这里简单判断是否滑到最右边）
  if (sliderLeft.value >= 250) {
    emit('success')
  } else {
    emit('fail')
    // 重置滑块位置
    sliderLeft.value = 0
  }
}

// 组件卸载时移除事件监听
onUnmounted(() => {
  document.removeEventListener('mousemove', onMouseMove)
  document.removeEventListener('mouseup', onMouseUp)
})
</script>

<style lang="less" scoped>
.slide-verify {
  width: 100%;
  margin-bottom: 24px;

  .slide-verify-container {
    position: relative;
    width: 300px;
    height: 150px;
    margin: 0 auto;

    .slide-verify-bg {
      position: relative;
      width: 100%;
      height: 100%;
      background-size: cover;
      background-position: center;
      border-radius: 4px;
      overflow: hidden;

      .slide-verify-slider {
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;

        .slide-verify-slider-mask {
          position: absolute;
          top: 0;
          left: 0;
          height: 100%;
          background-color: rgba(0, 0, 0, 0.2);
        }

        .slide-verify-slider-button {
          position: absolute;
          top: 50%;
          left: 0;
          width: 40px;
          height: 40px;
          margin-top: -20px;
          background-color: #fff;
          border-radius: 50%;
          box-shadow: 0 2px 8px rgba(0, 0, 0, 0.15);
          cursor: pointer;
          display: flex;
          align-items: center;
          justify-content: center;
          transition: all 0.3s;

          &:hover {
            background-color: #f5f5f5;
          }

          &:active {
            background-color: #e6e6e6;
          }
        }
      }
    }

    .slide-verify-tip {
      margin-top: 8px;
      text-align: center;
      color: rgba(0, 0, 0, 0.45);
    }
  }
}
</style>