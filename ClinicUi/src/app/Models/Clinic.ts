export interface Clinic {
    id: number;
    name: string;
    address: string;
    phoneNumber: string;
    specialization: Specialization;
}

export interface Specialization {
    id: number;
    name: string;
}