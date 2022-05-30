import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];

  widthImg: number = 150;
  marginImg: number = 2;
  exibirImagem: boolean = true;
  private _filtroLista: string = '';
  public eventosFiltrados: any = [];

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    console.log(this.filtroLista);
    this.eventosFiltrados = this._filtroLista ? this.filtrarEventos(this._filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string}) =>
        evento.tema.toLocaleLowerCase().indexOf (filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(private http: HttpClient) {
  }

  alterarImagem() {
    this.exibirImagem = !this.exibirImagem;
  }

  ngOnInit(): void {
    this.getEventos();
  }

  public getFoto(): string {
    console.log("\\assets\\" + this.eventos[0].imagemURL);
    return "\\assets\\" + this.eventos[0].imagemURL;
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response
        this.eventosFiltrados = response;
      },
      error => console.log(error)
    );
    //  this.eventos = [
    //    { tema: 'Angular w', local: 'São Paulo'},
    //    { tema: 'Java'   , local: 'Bahia'    },
    //    { tema: 'C#'     , local: 'Minas'    }
    //  ];
  }




}
