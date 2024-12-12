import {Table, TableBody, TableHead, TableHeader, TableRow} from "@/components/ui/table.tsx";
import TableItemExpense from "@/components/TableItemExpense.tsx";

function EmployeeTable(
    {itemCollection, headers, className}:
    {itemCollection?:any[],key:number,headers:string[], className?:string}
) {
    return (
        <Table className={className}>
            <TableHeader>
                <TableRow>
                    {headers.map((item:any,index:number) =>
                        <TableHead key={index}>{item}</TableHead>
                    )}
                    <TableHead>
                        <span className="sr-only">Actions</span>
                    </TableHead>
                </TableRow>
            </TableHeader>
            <TableBody>
                {itemCollection.map((item:Expense) =>
                    <TableItemExpense key={item.expenseId} item={item}/>
                )}

            </TableBody>
        </Table>
    );
}

export default EmployeeTable;
