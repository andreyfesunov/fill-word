<script lang="ts">
import { Component, Prop, Vue } from "vue-facing-decorator";
import {
  FillWordGameStatus,
  IFillWordGame,
} from "@domain/FillWord/FillWord.models";
import FillWordCeil from "@presentation/components/atoms/FillWordCeil.vue";
import { ID } from "@domain/SharedKernel.types";
import { WordPattern } from "@api/FillWord/Mock/Infrastructure/Patterns.db";
import { fillWordModule } from "@presentation/store/modules/fill-word";

@Component({
  components: { FillWordCeil },
})
export default class FillWordField extends Vue {
  @Prop({ required: true }) model!: IFillWordGame;
  private draw = false;
  private line: number[] = [];

  public getKey(rowIndex: number, colIndex: number): string {
    return rowIndex.toString() + colIndex.toString();
  }

  public get gridClass(): string {
    return "fill-word-field-" + this.model.matrix.length.toString();
  }

  public onMouseUp(): void {
    if (!this.draw) return;

    this.draw = false;
    const hasWord = fillWordModule.attempt({
      id: this.model.id,
      ids: this.line,
    });

    hasWord.then((status) => {
      if (status !== FillWordGameStatus.WRONG_MOVE) {
        this.line = [];
        //
        // if (status === FillWordGameStatus.END_GAME) {
        // }
      } else {
        this.clearTimeLine();
      }
    });
  }

  private onMouseDown(row: number, ceil: number): void {
    this.draw = true;
    if (this.isActive(row, ceil)) return;
    this.activate(row, ceil);
  }

  private onMouseOver(row: number, ceil: number): void {
    if (!this.draw) {
      return;
    }

    if (
      !this.isActive(row, ceil) &&
      this.lastCeilLengthEqualOneCeil(row, ceil)
    ) {
      this.activate(row, ceil);
    } else {
      if (this.isPrevCeil(row, ceil)) {
        const lastCeilId: ID = this.lastCeil();
        const lastCeilCoords = this.findInMatrix(lastCeilId);

        this.disable(lastCeilCoords[0], lastCeilCoords[1]);
        this.removeLastMoveInTimeline();
      }
    }
  }

  private isActive(row: number, ceil: number): boolean {
    return this.model.matrix[row][ceil].active;
  }

  private activate(row: number, ceil: number): void {
    fillWordModule.toggleCeil({ row: row, col: ceil });

    this.addTimeline(row, ceil);
  }

  private disable(row: number, ceil: number) {
    fillWordModule.toggleCeil({ row: row, col: ceil });
  }

  private addTimeline(row: number, ceil: number): void {
    this.line.push(this.model.matrix[row][ceil].id);
  }

  private lastCeilLengthEqualOneCeil(row: number, ceil: number): boolean {
    const lastCeilId: ID = this.lastCeil();
    const lastCeilCoords = this.findInMatrix(lastCeilId);
    const lastRow = lastCeilCoords[0];
    const lastCeil = lastCeilCoords[1];

    return (
      ((lastRow === row - 1 || lastRow === row + 1) && lastCeil === ceil) ||
      ((lastCeil === ceil - 1 || lastCeil === ceil + 1) && lastRow === row)
    );
  }

  private removeLastMoveInTimeline(): void {
    this.line.splice(this.line.length - 1, 1);
  }

  private prevCeil(): ID | null {
    return this.line[this.line.length - 2];
  }

  private lastCeil(): ID {
    return this.line[this.line.length - 1];
  }

  private isPrevCeil(row: number, ceil: number): boolean {
    if (!this.prevCeil()) return false;

    return this.prevCeil() === this.model.matrix[row][ceil].id;
  }

  private clearTimeLine(): void {
    this.line.forEach((id) => {
      this.model.matrix.forEach((row, rowIndex) => {
        const el = row.find((model, colIndex) => {
          if (model.id === id) {
            fillWordModule.toggleCeil({ row: rowIndex, col: colIndex });
          }
        });
      });
    });

    this.line = [];
  }

  private findInMatrix(id: ID): WordPattern {
    let coords: WordPattern | null = null;
    this.model.matrix.forEach((row, rowIndex) =>
      row.forEach((ceil, ceilIndex) => {
        if (ceil.id === id) {
          coords = [rowIndex, ceilIndex];
        }
      })
    );

    if (coords !== null) {
      return coords;
    }

    throw new Error("Not found element with such id");
  }
}
</script>

<template>
  <div :class="gridClass" @mouseleave="onMouseUp">
    <template v-for="(row, rowIndex) in model.matrix">
      <FillWordCeil
        v-for="(col, colIndex) in row"
        :letter="col.content"
        :active="col.active"
        :key="getKey(rowIndex, colIndex)"
        @mouseover="onMouseOver(rowIndex, colIndex)"
        @mousedown="onMouseDown(rowIndex, colIndex)"
        @mouseup="onMouseUp"
      ></FillWordCeil>
    </template>
  </div>
</template>

<style scoped lang="scss">
$grid-size: (3, 4, 5, 6, 7, 8);
@each $value in $grid-size {
  .fill-word-field-#{$value} {
    display: grid;
    gap: 6px;

    width: min-content;
    grid-template-columns: repeat(#{$value}, 1fr);
    grid-auto-rows: repeat(#{$value}, 1fr);
  }
}
</style>
