import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})

export class EventoDetalheComponent implements OnInit {
  public form!: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  private validation(): void {
    this.form = this.fb.group({
      tema      : ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local     : ['', [Validators.required]],
      dateEvento: ['', [Validators.required]],
      qtdPessoas: ['', [Validators.required, Validators.max(1000)]],
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

  public resetForm(): void {
    this.form.reset();
  }
}
