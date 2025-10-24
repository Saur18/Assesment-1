import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environment';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { CommissionCalculationResponse } from '../data/commission-calculation-response';
import { CommissionCalculationRequest } from '../data/commission-calculation-request';

@Injectable({
  providedIn: 'root'
})
export class CommissionServiceService {

  endpoint = environment;

  constructor(private httpClient: HttpClient) { }

    processError(err: any) {
    let message = '';
    if (err.error instanceof ErrorEvent) {
      message = err.error.message;
    } else {
      message = `Error Code: ${err.status}\nMessage: ${err.message}`;
    }
    
    return throwError(() => new Error(message));
  }

    getTotalCommission(request: CommissionCalculationRequest): Observable<CommissionCalculationResponse> {
    return this.httpClient.post<CommissionCalculationResponse>(this.endpoint, request)
      .pipe(
        retry(1),
        catchError(this.processError)
      )
  }

}
