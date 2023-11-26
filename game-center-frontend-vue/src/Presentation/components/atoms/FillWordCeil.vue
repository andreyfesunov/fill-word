<script lang="ts">
import { Component, Prop, Vue } from "vue-facing-decorator";

@Component
export default class FillWordCeil extends Vue {
  @Prop({ type: Boolean, default: false }) active!: boolean;
  @Prop({ type: String, required: true }) letter!: string;
}
</script>

<template>
  <div class="fill-word-ceil" :class="{ 'fill-word-ceil--active': active }">
    <span class="fill-word-ceil__text">{{ letter }}</span>
  </div>
</template>

<style scoped lang="scss">
.fill-word-ceil {
  background-color: var(--md-sys-color-surface-container-low);
  box-shadow: 2px 2px 2px var(--md-sys-color-shadow);
  width: 90px;
  aspect-ratio: 1 / 1;

  display: grid;
  place-items: center;
  user-select: none;

  &__text {
    font-size: 45px;
    color: var(--md-sys-color-primary);
  }

  &--active {
    background-color: var(--md-sys-color-primary-fixed);
    transform: translate(1.5px, 1.5px);
    box-shadow: 0.5px 0.5px 2px var(--md-sys-color-shadow);
  }
}
</style>
