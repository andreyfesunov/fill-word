import {Injectable} from "@angular/core";
import {Config} from "../../../core/config";
import {Observable} from "rxjs";
import {
  IFillWord,
  IFillWordAttemptRequest,
  IFillWordAttemptResponse,
  IFillWordCreateRequest
} from "../models/fill-word";
import {HttpClient} from "@angular/common/http";

@Injectable()
export class FillWordApiService {
  private readonly root = this.config.apiRoot + "/FillWord";

  constructor(
    private readonly config: Config,
    private readonly httpClient: HttpClient
  ) {
  }

  public FindById(id: string): Observable<IFillWord> {
    return this.httpClient.get<IFillWord>(`${this.root}/${id}`);
  }

  public Attempt(request: IFillWordAttemptRequest): Observable<IFillWordAttemptResponse> {
    return this.httpClient.post<IFillWordAttemptResponse>(this.root, request);
  }

  public List(): Observable<IFillWord[]> {
    return this.httpClient.get<IFillWord[]>(this.root);
  }

  public Create(request: IFillWordCreateRequest): Observable<IFillWord> {
    return this.httpClient.put<IFillWord>(this.root, request);
  }
}
