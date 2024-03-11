import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Componente1Component } from "./componente1/componente1.component";
import { Componente2Component } from "./componente2/componente2.component";
import { Componente3Component } from "./componente3/componente3.component";
import { Componente4Component } from "./componente4/componente4.component";


@NgModule({
    declarations: [
        AppComponent
    ],
    providers: [
        provideClientHydration()
    ],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        Componente1Component,
        Componente2Component,
        Componente3Component,
        Componente4Component
    ]
})
export class AppModule { }
