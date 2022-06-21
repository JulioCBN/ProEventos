import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {

  modalRef?: BsModalRef;

  public eventoId = 0;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  public widthImg: number = 150;
  public marginImg: number = 2;
  public exibirImagem: boolean = true;
  private filtroListado: string = '';

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string){
    this.filtroListado = value;
    console.log(this.filtroLista);
    this.eventosFiltrados = this.filtroListado ? this.filtrarEventos(this.filtroListado) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string}) =>
        evento.tema.toLocaleLowerCase().indexOf (filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private router: Router,
    private spinner: NgxSpinnerService) { }


  public alterarImagem(): void {
    this.exibirImagem = !this.exibirImagem;
  }

  public ngOnInit() {
    this.spinner.show();
    this.carregaEventos();
  }

  public getFoto(): string {
    console.log("\\assets\\" + this.eventos[0].imagemURL);
    return "\\assets\\" + this.eventos[0].imagemURL;
  }

  public carregaEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos
        this.eventosFiltrados = eventos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os eventos!', 'Error!');
      },
      complete: () => this.spinner.hide()
    });
  }

  openModal(event: any, template: TemplateRef<any>, eventoId: number): void {
    event.stopPropagation();
    this.eventoId = eventoId;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.spinner.show();

    this.eventoService.deleteEventos(this.eventoId).subscribe(
      (result: any) => {
        console.log(result);
        if (result.ok)
        {
          this.toastr.success('O registro foi excluído com sucesso!', 'Exclusão', {
            positionClass: 'toast-top-center',
            //warning: 'toast-warning',
            timeOut: 1500,
            //success: 'toast-success',
          });
          this.spinner.hide();
          this.carregaEventos();
        }
      },
      (error: any) => {
        console.log(error)
        this.toastr.error(`erro ao tentar deletar o evento ${this.eventoId}`, "Erro", {
          timeOut: 2000,
        });
        this.spinner.hide();
      },
      () => this.spinner.hide()
    )
  }

  decline(): void {
    this.modalRef?.hide();
  }

  detalheEvento(id: number): void{
    this.router.navigate([`eventos/detalhe/${id}`])
  }
}
