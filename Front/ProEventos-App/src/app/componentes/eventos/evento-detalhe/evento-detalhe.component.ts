import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Evento } from '@app/models/Evento';
import { EventoService } from '@app/services/evento.service';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})

export class EventoDetalheComponent implements OnInit {

  evento = {} as Evento;
  public form!: FormGroup;
  estadoSalvar: string = 'post';

  constructor(private fb: FormBuilder,
              private localeService: BsLocaleService,
              private router: ActivatedRoute,
              private eventoService: EventoService,
              private spinner: NgxSpinnerService,
              private toastr: ToastrService
              ) {
    this.localeService.use("pt-br");
  }

  public carregaEvento(): void {
    const eventoIdParam = this.router.snapshot.paramMap.get('id');
    console.log(this.eventoService.getEventoById(1));

    if (eventoIdParam != null) {
      this.estadoSalvar = 'put';
      this.spinner.show();
      this.eventoService.getEventoById(+eventoIdParam).subscribe(
        (evento: Evento) => {
          this.evento = {...evento}
          this.form.patchValue(this.evento);
        },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error("Erro ao tentar carregar evento", "Erro!");
          console.log(error);
        },
        () => {
          this.spinner.hide();
        }
      );
    }

  }

  ngOnInit(): void {
    this. carregaEvento();
    this.validation();
  }

  private validation(): void {
    this.form = this.fb.group({
      tema      : ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local     : ['', [Validators.required]],
      dateEvento: ['', [Validators.required]],
      qtdPessoas: ['', [Validators.required, Validators.min(3), Validators.max(1000)]],
      imagemURL : ['', [Validators.required]],
      telefone  : ['', [Validators.required]],
      email     : ['', [Validators.required, Validators.email]],
    })

    // this.form = new FormGroup({
    //   tema      : new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
    //   local     : new FormControl('', [Validators.required]),
    //   dateEvento: new FormControl('', [Validators.required]),
    //   qtdPessoas: new FormControl('', [Validators.required, Validators.max(1000)]),
    //   imagemURL : new FormControl('', [Validators.required]),
    //   telefone  : new FormControl('', [Validators.required]),
    //   email     : new FormControl('', [Validators.required, Validators.email]),
    // });
  }

  public get f(): any { //{ [key: string]: AbstractControl } {
    return this.form.controls;
  }

  get bsConfig(): any {
    return {
      isAnimated: true,
      adaptivePosition: true,
      dateInputFormat: 'DD-MM-YYYY HH:mm',
      containerClass: 'theme-default',
      showWeekNumbers: false
    };
  }

  public resetForm(): void {
    this.form.reset();
  }
  public cssValidator(campoForm: FormControl): any {
    return {'is-invalid': campoForm.errors && campoForm.touched};
  }

  salvarAleteracao() {
    this.spinner.show();
    if (this.form.valid) {

      this.evento = (this.estadoSalvar === 'post')
        ? {...this.form.value}
        : {...this.form.value, id: this.evento.id};

      this.eventoService[(this.estadoSalvar === 'put'? 'put': 'post')](this.evento).subscribe(
        (result: any) => {
          if (result.ok)
          {
            this.toastr.success('O registro foi salvo com sucesso!', 'Atenção', { positionClass: 'toast-top-center', timeOut: 2000, progressBar: false });
          }
        },
        (error: string) => {
          this.toastr.error(`Erro ao tentar salvar o evento ${this.estadoSalvar === 'put' ? this.evento.id: ''}`, "Erro", { timeOut: 2000 });
        },
        () => this.spinner.hide(),
      ).add(() => this.spinner.hide());
    }
  }
}
