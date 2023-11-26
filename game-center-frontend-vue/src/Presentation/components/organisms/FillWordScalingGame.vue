<script lang="ts">
import { Component, Prop, Vue } from "vue-facing-decorator";
import {
  FillWordGameStatus,
  IFillWordGame,
} from "@domain/FillWord/FillWord.models";
import FillWordField from "@presentation/components/molecules/FillWordField.vue";
import { fillWordModule } from "@presentation/store/modules/fill-word";

@Component({
  components: { FillWordField },
  emits: ["scaleChange"],
})
export default class FillWordScalingGame extends Vue {
  @Prop({ required: true }) model!: IFillWordGame;
  @Prop({ type: Number, required: true }) minSize!: number;
  @Prop({ type: Number, required: true }) maxSize!: number;
  @Prop({ required: true }) size!: number;

  public get status() {
    return fillWordModule.status === FillWordGameStatus.END_GAME;
  }
}
</script>

<template>
  <div class="scale-game-wrapper">
    <div class="size-scale">
      <span>{{ $t("fillWord.scale") }}</span>
      <input
        type="range"
        v-bind:min="minSize"
        v-bind:max="maxSize"
        v-bind:value="size"
        @change="$emit('scaleChange', $event)"
      />
    </div>
    <div class="game-wrapper">
      <FillWordField :model="model"></FillWordField>
    </div>
    <transition name="fade">
      <template v-if="status">
        <div class="reset">
          <span>{{ $t("fillWord.reset") }}</span>
        </div>
      </template>
    </transition>
  </div>
</template>

<style scoped lang="scss">
.size-scale {
  font-size: 18px;
  display: flex;
  flex-direction: column;
  gap: 12px;
  padding: 20px;

  color: var(--md-sys-color-primary);
  background-color: var(--md-sys-color-surface-container-high);
  border-radius: 12px;
}

.game-wrapper {
  width: min-content;
  background-color: var(--md-sys-color-surface-container-high);
  border-radius: 12px;
  padding: 20px;
}

.scale-game-wrapper {
  width: min-content;
  gap: 12px;
  display: grid;
  grid-template-columns: 1fr;
  grid-template-rows: min-content min-content;
}

.reset {
  font-size: 18px;
  display: flex;
  flex-direction: column;
  gap: 12px;
  padding: 20px;

  color: var(--md-sys-color-primary);
  background-color: var(--md-sys-color-surface-container-high);
  border-radius: 12px;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s ease;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>
