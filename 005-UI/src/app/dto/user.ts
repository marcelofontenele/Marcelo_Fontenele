import { Stock } from "./stock";

export class User {
    login: string;
    password: string;

    accountAmount: string;
    positions: Stock[];
    consolidatedAmount: string;

    constructor() {
        this.positions = [];
    }
}