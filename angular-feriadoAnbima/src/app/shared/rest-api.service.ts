import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ListFeriados } from './list-feriados';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { FeriadoDto } from './feriado-dto';

@Injectable({
  providedIn: 'root'
})
export class RestApiService {
  //Define o caminho da API
  apiURL = 'https://localhost:5001/api/FeriadosAnbima'

  constructor(private http : HttpClient) { }

  // Http Options 
 httpOptions = { 
  headers: new HttpHeaders({ 
  'Content-Type': 'application/json' ,
  'Access-Control-Allow-Origin':'*',
  }) 
  }
 

  //HttpClient API método get() => Busca a lista de feriados
  getFeriadosAnbima(ano: Number): Observable<ListFeriados> {
    return this.http.get<ListFeriados>(`${this.apiURL}/${ano}` , this.httpOptions)
      .pipe(retry(1), catchError(this.handlerError))
  }

  //Error handling(manipulador de erro)
  handlerError(error : any){
    let errorMessage = '';
    if(error.error instanceof ErrorEvent){
      //Get client-side error
      errorMessage = error.error.message;
    }if(error.status == 0){
      errorMessage = `Erro ao se comunicar com a api, tente novamente mais tarde`
    }
    else{
      //get server-side error (manipulador de erro do servidor)
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }

}
