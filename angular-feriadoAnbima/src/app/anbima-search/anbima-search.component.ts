import { ListFeriados } from './../shared/list-feriados';
import { Component, OnInit, Input } from '@angular/core';
import { RestApiService } from '../shared/rest-api.service';
import {DatePipe} from '@angular/common'
import { FeriadoDto } from '../shared/feriado-dto';


@Component({
  selector: 'app-anbima-search',
  templateUrl: './anbima-search.component.html',
  styleUrls: ['./anbima-search.component.css']
})
export class AnbimaSearchComponent implements OnInit {
  @Input() buscaFeriado = {ano : ' ' }
  ResponseFeriadosAnbima !: any  ;
  Feriados :any  = [];
  ano !: Number;

  constructor(public restApi : RestApiService) { }

  ngOnInit(): void {}
  
  pesquisaAno(){
    this.ano = Number(this.buscaFeriado.ano)
      if(this.ano > 2000 && this.ano < 2078){
      this.restApi.getFeriadosAnbima(this.ano).subscribe((data : {})  => {
        this.ResponseFeriadosAnbima = data;
      }) }
      else{
        return window.alert("Digite um ano entre 2001 e 2078");
      }
    if(this.ResponseFeriadosAnbima.isSucess == true){
      this.Feriados = this.ResponseFeriadosAnbima.feriados;
      console.log(this.Feriados)
      window.alert(`Sucesso`)
    }
  }

}
