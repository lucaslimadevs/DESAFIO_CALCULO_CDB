import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CalculadoraCdbService {

  constructor(private http: HttpClient) {}

  calcular(valor: any, prazo: any) {
    return this.http.post(`${environment.urlApi}/api/Cdb/Calcular`, { valor: valor, meses: prazo } );
  }
}
