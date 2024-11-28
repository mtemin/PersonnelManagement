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
    expenseId:number,
    amount:number,
    isApproved:boolean
    title:string
    description:string,
    companyId:number,
    employeeId:number,
}

type LeaveDay = {
    leaveDayId:number,
    employeeId: number,
    title: string,
    companyId:string,
    description:string,
    isApproved:boolean,
    type:string,
    startDate:string,
    endDate:string,
}
