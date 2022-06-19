import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GrupoAcessoComponent } from './grupo-acesso.component';

describe('GrupoAcessoComponent', () => {
  let component: GrupoAcessoComponent;
  let fixture: ComponentFixture<GrupoAcessoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GrupoAcessoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GrupoAcessoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
