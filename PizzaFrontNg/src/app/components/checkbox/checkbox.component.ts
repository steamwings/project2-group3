import { Component, OnInit,Input,Host } from '@angular/core';

import { CheckboxGroupComponent } from '../checkbox-group/checkbox-group.component';

@Component({
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrls: ['./checkbox.component.css']
})

export class CheckboxComponent {

  ngOnInit() {
  }

  @Input() value: any;

  constructor(@Host() private checkboxGroup: CheckboxGroupComponent) {
  }

  toggleCheck() {
    this.checkboxGroup.addOrRemove(this.value);
  }

  isChecked() {
    return this.checkboxGroup.contains(this.value);
  }
}