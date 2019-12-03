import { BenefitCategory } from './BenefitCategory';

export class Person {
    FirstName: string;
    LastName: string;
    BenefitCategory: BenefitCategory[];

    constructor() {
        this.FirstName = "";
        this.LastName = "";
    }
}