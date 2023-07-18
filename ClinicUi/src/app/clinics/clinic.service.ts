import { Injectable } from '@angular/core';
import { Clinic, Specialization } from 'app/Models/Clinic';
import { environment } from 'environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClinicService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getAllSpecializations() {
    return this.http.get<Specialization[]>(this.baseUrl + 'specializations');
  }

  getAllClinics() {
    return this.http.get<Clinic[]>(this.baseUrl + 'clinics');
  }

  getClinic(id: Number) {
    return this.http.get<Clinic>(this.baseUrl + 'clinics/' + id);
  }

  addClinic(clinic: any) {
    return this.http.post<Clinic>(this.baseUrl + 'clinics', clinic);
  }


  deleteClinic(id: number) {
    return this.http.delete(this.baseUrl + 'clinics/' + id);
  }

  updateClinic(id: number, clinic: any) {
    return this.http.put<Clinic>(this.baseUrl + 'clinics/' + id, clinic);
  }
}
