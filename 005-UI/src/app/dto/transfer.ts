import { Stock } from "./stock";

export class Transfer {
    event: string = "TRANSFER";
	target: Target;
	origin: Origin;
	amount: any;
}

export class Target {
    bank: string;
    branch: string; 
    account: string; 
}

export class Origin {
    bank: string;
    branch: string; 
    cpf: string; 
}