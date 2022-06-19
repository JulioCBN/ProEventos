import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})

export class RegistrationComponent implements OnInit {
  
  public form!: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  private validation(): void {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('senha','confirmaSenha')
    }

    this.form = this.fb.group({
      primeiroNome  : ['', [Validators.required, Validators.minLength(4), Validators.maxLength(10)]],
      ultimoNome    : ['', [Validators.required]],
      email         : ['', [Validators.required, Validators.email]],
      userName      : ['', [Validators.required]],
      senha         : ['', [Validators.required, Validators.minLength(6)]],
      confirmaSenha : ['', [Validators.required]],
    }, formOptions);
  }

  public get f(): any {
    return this.form.controls;
  }

  public resetForm(): void {
    this.form.reset();
  }
}
