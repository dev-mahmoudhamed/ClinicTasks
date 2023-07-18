import { AbstractControl, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ClinicService } from './clinic.service';
import { Clinic, Specialization } from '../Models/Clinic';
import { Component } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
@Component({
  selector: 'app-clinics',
  templateUrl: './clinics.component.html',
  styleUrls: ['./clinics.component.scss']
})
export class ClinicsComponent {
  clinics: Clinic[] = [];
  specializations: Specialization[] = [];
  clinicSelected: Clinic = {} as Clinic;

  clinicForm = this.fb.group({
    name: ['', Validators.required],
    address: ['', Validators.required],
    phoneNumber: ['', [Validators.required, Validators.pattern("^[0-9]*$"),
    Validators.minLength(10)]],
    specializationId: new FormControl(),
  });

  constructor(private clinicService: ClinicService, private fb: FormBuilder,
    private confirmationService: ConfirmationService) { }
  ngOnInit(): void {
    this.getClinics();
    this.GetSpecializations();
  }
  fillForm() {
    this.clinicForm.setValue({
      name: this.clinicSelected.name,
      address: this.clinicSelected.address,
      phoneNumber: this.clinicSelected.phoneNumber,
      specializationId: this.clinicSelected.specialization.id,
    })
  }

  GetSpecializations() {
    this.clinicService.getAllSpecializations().subscribe({
      next: result => {
        this.specializations = result;
      }
    });
  }

  getClinics() {
    this.clinicService.getAllClinics().subscribe({
      next: result => {
        this.clinics = result;
        console.log(result);
      }
    });
  }
  onSubmit() {
    if (this.clinicSelected?.id) {
      this.updateClinic(this.clinicSelected.id);
    } else {
      this.addClinic();

    }
  }
  addClinic() {
    console.log(this.clinicForm.value);
    this.clinicService.addClinic(this.clinicForm.value).subscribe({
      next: (response) => {
        this.getClinics();

      },
      error: (err) => console.log(err.error)
    });
  }

  editClinic(id: any) {
    this.clinicSelected.id = id;
    this.clinicService.getClinic(+id).subscribe({
      next: result => {
        this.clinicSelected = result;
        console.log(result);
        this.fillForm();
      }
    });
  }

  updateClinic(id: any) {
    this.clinicService.updateClinic(id, this.clinicForm.value).subscribe({
      next: (result) => {
        // console.log(result);
        this.clinicForm.reset();
        this.clinicSelected = {} as Clinic;
        this.getClinics();
      },
      error: err => console.log(err)
    });
  }

  deleteClinic(id: any) {
    this.clinicService.deleteClinic(+id).subscribe({
      next: result => {
        console.log(result);
        this.getClinics();
      },
      error: (err) => console.log(err)
    });
  }


  showConfirmation(id: any): void {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete?',
      accept: () => {
        this.deleteClinic(id);
        this.clinicForm.reset();
        console.log('Delete confirmed');
      },
      reject: () => {
        console.log('Delete cancelled');
      }
    });
  }
}
