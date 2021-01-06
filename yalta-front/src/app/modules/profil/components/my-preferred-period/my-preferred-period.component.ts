import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-my-preferred-period',
  templateUrl: './my-preferred-period.component.html',
  styleUrls: ['./my-preferred-period.component.scss'],
})
export class MyPreferredPeriodComponent implements OnInit {
  @Input()
  form: FormGroup;
  @Input()
  historyRanges;
  @Input()
  geographicalAreas;
  @Input()
  showAddPeriod = false;
  @Input()
  showRemovePeriod = false;

  @Output()
  emitAddPeriod = new EventEmitter<any>();
  @Output()
  emitRemovePeriod = new EventEmitter<any>();

  year = new Date().getFullYear();

  constructor() { }

  ngOnInit() {

  }

  onLowerRangeChange(event) {
    this.form.controls['range'].setValue({ lower: event.detail.value, upper: this.form.value.range.upper });
  }

  onUpperRangeChange(event) {
    this.form.controls['range'].setValue({ lower: this.form.value.range.lower, upper: event.detail.value });
  }

  onPreRangeSelect(event) {
    this.form.controls['range'].setValue(event.detail.value.range);
  }

  onAreaSelect(event) {
    // TODO see if the ask to write itself the areas
    console.log(event);
  }

  addPeriod() {
    this.emitAddPeriod.emit();
  }

  removePeriod() {
    this.emitRemovePeriod.emit();
  }

}
