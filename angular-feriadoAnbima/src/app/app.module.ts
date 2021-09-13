import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AnbimaSearchComponent } from './anbima-search/anbima-search.component';
//Importando para o consumo da api
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
//Importando o DatePipe
import { CommonModule } from '@angular/common';
import { DataFormata } from './shared/pipe-dataFormatada';

@NgModule({
  declarations: [
    AppComponent,
    AnbimaSearchComponent,
    DataFormata
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
