import { Action, Module, Mutation, VuexModule } from "vuex-class-modules";
import {
  FillWordGameStatus,
  IFillWordAttemptRequest,
  IFillWordGame,
} from "@domain/FillWord/FillWord.models";
import { fillWordAdapter } from "@adapter/FillWord/FillWord.adapter";
import store from "@presentation/store";
import { Modules } from "@presentation/store/modules";

@Module
export default class FillWord extends VuexModule {
  private _game: IFillWordGame = {
    id: 0,
    answers: [],
    matrix: [],
  };
  private _minSize = 3;
  private _maxSize = 8;
  private _size = Math.round((this._minSize + this._maxSize) / 2);
  private _status: null | FillWordGameStatus = null;

  get game() {
    return this._game;
  }

  get size() {
    return this._size;
  }

  get status() {
    return this._status;
  }

  @Mutation
  public setGame(game: IFillWordGame) {
    this._game = game;
  }

  @Mutation
  private setSize(size: number) {
    this._size = size;
  }

  @Mutation
  public toggleCeil(model: { row: number; col: number }) {
    this._game.matrix[model.row][model.col].active =
      !this._game.matrix[model.row][model.col].active;
  }

  @Mutation
  public setStatus(status: null | FillWordGameStatus) {
    this._status = status;
  }

  @Action
  public async createGame() {
    const gameBackend = await fillWordAdapter.createGame({ size: this.size });
    this.setGame({
      answers: gameBackend.answers,
      matrix: gameBackend.matrix.map((row) =>
        row.map((ceil) => ({
          content: ceil.content,
          id: ceil.id,
          active: false,
        }))
      ),
      id: gameBackend.id,
    });
    this.setStatus(null);
  }

  @Action
  async changeSize(size: number) {
    this.setSize(size);
    await this.createGame();
  }

  @Action
  async attempt(model: IFillWordAttemptRequest) {
    const response = await fillWordAdapter.attempt(model);
    this.setStatus(response.status);
    return response.status;
  }
}

export const fillWordModule = new FillWord({ store, name: Modules.FILL_WORD });
