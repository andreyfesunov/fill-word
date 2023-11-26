<script lang="ts">
import { Component, Vue } from "vue-facing-decorator";
import FillWordField from "@presentation/components/molecules/FillWordField.vue";
import { fillWordModule } from "@presentation/store/modules/fill-word";
import FillWordScalingGame from "@presentation/components/organisms/FillWordScalingGame.vue";

@Component({
  components: { FillWordScalingGame, FillWordField },
})
export default class TestPage extends Vue {
  public get size() {
    return fillWordModule.size;
  }

  public get game() {
    return fillWordModule.game;
  }

  public created() {
    this.recalc();
  }

  public sizeChange(event: Event) {
    fillWordModule.changeSize((event.target as HTMLInputElement).valueAsNumber);
  }

  public recalc() {
    fillWordModule.createGame().then(() => console.log(fillWordModule.game));
  }
}
</script>

<template>
  <FillWordScalingGame
    :model="game"
    :max-size="8"
    :min-size="3"
    :size="size"
    @scale-change="sizeChange"
  ></FillWordScalingGame>
</template>

<style scoped lang="scss"></style>
