import {Table, TableBody, TableHead, TableHeader, TableRow} from "@/components/ui/table.tsx";
import TableItemEmployee from "@/components/TableItemEmployee.tsx";
import TableItemExpense from "@/components/TableItemExpense.tsx";

function EmployeeTable({itemCollection,key}:{itemCollection:any[],key:number}) {
    return (
        <Table>
            <TableHeader>
                <TableRow>
                    <TableHead className="hidden md:table-cell">
                        Is Approved
                    </TableHead>
                    <TableHead className="hidden md:table-cell">
                        Employee Id
                    </TableHead>
                    <TableHead className="hidden md:table-cell">
                        Amount
                    </TableHead>
                    <TableHead className="hidden md:table-cell">
                        Title
                    </TableHead>
                    <TableHead className="hidden md:table-cell">
                        Description
                    </TableHead>
                    <TableHead>
                        <span className="sr-only">Actions</span>
                    </TableHead>
                </TableRow>
            </TableHeader>
            <TableBody>
                {itemCollection.map((item:any,index:number) =>
                    <TableItemExpense key={key} item={item}/>
                )}

            </TableBody>
        </Table>
    );
}

export default EmployeeTable;
