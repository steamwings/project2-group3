import { Component, OnInit,forwardRef } from '@angular/core';

import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';


//Component which holds ngModel or formControlName and then the children components 
//update the group components value.

@Component({
  selector: 'app-checkbox-group',
  template: `<ng-content></ng-content>`,
  providers: [{
        provide: NG_VALUE_ACCESSOR,
        useExisting: forwardRef(() => CheckboxGroupComponent),
        multi: true
      }]
   })
  export class CheckboxGroupComponent implements ControlValueAccessor {
    private _model: any;
  
    // here goes implementation of ControlValueAccessor
    private onChange: (m: any) => void;
    private onTouched: (m: any) => void;
    get model() {
        return this._model;
    }
    writeValue(value: any): void {
        this._model = value;
    }
    registerOnChange(fn: any): void {
        this.onChange = fn;
    }
    registerOnTouched(fn: any): void {
        this.onTouched = fn;
    }
    
    set(value: any) {
        this._model = value;
        this.onChange(this._model);
    }
  
    addOrRemove(value: any) {
      if (this.contains(value)) {
          this.remove(value);
      } else {
          this.add(value);
      }
    }
  
    contains(value: any): boolean {
      if (this._model instanceof Array) {
          return this._model.indexOf(value) > -1;
      } else if (!!this._model) {
          return this._model === value;
      }
  
      return false;
    }
  
    // implementation for add and remove

    private add(value: any) {
      if (!this.contains(value)) {
         if (this._model instanceof Array) {
             this._model.push(value);
         } else {
             this._model = [value];
         }
         this.onChange(this._model);
      }
   }
   private remove(value: any) {
      const index = this._model.indexOf(value);
      if (!this._model || index < 0) {
         return;
      }
      this._model.splice(index, 1);
      this.onChange(this._model);
   }
  
  }