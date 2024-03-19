import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { departmentDTO } from 'src/app/core/interfaces/departmentDTO';

@Component({
  selector: 'app-department-form',
  templateUrl: './department-form.component.html',
  styleUrls: ['./department-form.component.scss']
})
export class DepartmentFormComponent {

  constructor(
    private formBuilder: FormBuilder) {}

  @Output()
  onSubmit: EventEmitter<departmentDTO> = new EventEmitter<departmentDTO>()

  nameMinLength: number = 5
  descriptionMinLength: number = 50

  form: FormGroup = this.formBuilder.group({
    name: [
      '',
      {
        validators: [
          Validators.required,
          Validators.minLength(this.nameMinLength)
        ]
      }
    ],
    description: [
      '',
      {
        validators: [
          Validators.required,
          Validators.minLength(this.descriptionMinLength)
        ]
      }
    ]
  })

  // Submit Department
  submitChanges() {
    this.onSubmit.emit(this.form.value)
  }

  // Validate Name Field
  getNameErrorMessage(field:string){
    let translatedField: string = 'Nombre'
    let name = this.form.get(field)

    if(name?.touched) {
      
      if(name?.hasError('required'))
        return `El campo ${translatedField} es obligatorio`
  
      if(name?.hasError('minlength'))
        return `El campo ${translatedField} debe tener al menos ${this.nameMinLength} dígitos`
    }

    return ''
  }

  // Validate Description Field
  getDescriptionErrorMessage(field:string){
    let translatedField: string = 'Descripción'
    var description = this.form.get('description')

    if(description?.touched) {

      if(description?.hasError('required'))
        return `El campo ${translatedField} es obligatorio`

      if(description?.hasError('minlength'))
        return `El campo ${translatedField} debe tener al menos ${this.descriptionMinLength} dígitos`
    }

    return ''
  }
}
