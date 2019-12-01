import { Person } from './person';
import { Dependent } from './dependent';

export class Employee extends Person {
    EmployeeId: number
    Dependents: Dependent[];
    CompensationRate: number;
    AnnualCost: number;

    constructor() {
        super()
        this.Dependents = [];
    }
}