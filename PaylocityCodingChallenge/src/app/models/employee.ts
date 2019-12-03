import { Person } from './person';
import { Dependent } from './dependent';

export class Employee extends Person {
    EmployeeId: number
    Dependents: Dependent[] = [];
    AnnualCost: number;
    AnnualSalary: number;
    BenefitCost: number;
}