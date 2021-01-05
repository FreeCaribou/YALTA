import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { MyPreferredPeriodComponent } from './my-preferred-period.component';

describe('MyPreferredPeriodComponent', () => {
  let component: MyPreferredPeriodComponent;
  let fixture: ComponentFixture<MyPreferredPeriodComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyPreferredPeriodComponent ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(MyPreferredPeriodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
