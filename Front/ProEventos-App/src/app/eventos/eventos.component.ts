import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any;

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.geteventos();
  }

  public geteventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => this.eventos = response,
      error => console.log(error)
    );
    // this.eventos = [
    //   { Tema: 'Angular w', Local: 'São Paulo'},
    //   { Tema: 'Java'   , Local: 'Bahia'    },
    //   { Tema: 'C#'     , Local: 'Minas'    }
    // ];
  }


}
