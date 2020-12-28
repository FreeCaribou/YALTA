import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { TemplateCenterColComponent } from './template-center-col.component';

describe('TemplateCenterColComponent', () => {
  let component: TemplateCenterColComponent;
  let fixture: ComponentFixture<TemplateCenterColComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TemplateCenterColComponent],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(TemplateCenterColComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
