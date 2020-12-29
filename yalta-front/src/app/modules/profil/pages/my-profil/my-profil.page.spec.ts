import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { MyProfilPage } from './my-profil.page';

describe('profilPage', () => {
  let component: MyProfilPage;
  let fixture: ComponentFixture<MyProfilPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [MyProfilPage],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(MyProfilPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
