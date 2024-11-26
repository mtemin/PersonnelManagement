type Company = {
    companyId:number,
    name:string,
}

type Employee = {
    employeeId: number,
    name: string,
    surname: string,
    title: string,
    companyId: number,
}

type Expense = {
    amount:number,
    isApproved:boolean,
    title:string
    description:string,
    companyId:number,
    employeeId:number,
}
