import {Table, TableBody, TableHead, TableHeader, TableRow} from "@/components/ui/table.tsx";
import TableItemEmployee from "@/components/TableItemEmployee.tsx";

function EmployeeTable({itemCollection,key}:{itemCollection:any[],key:number}) {
    return (
        <Table>
            <TableHeader>
                <TableRow>
                    <TableHead>Name</TableHead>
                    <TableHead>Surname</TableHead>
                    <TableHead className="hidden md:table-cell">
                        Company
                    </TableHead>
                    <TableHead className="hidden md:table-cell">
                        Job Title
                    </TableHead>
                    <TableHead>
                        <span className="sr-only">Actions</span>
                    </TableHead>
                </TableRow>
            </TableHeader>
            <TableBody>
                {itemCollection.map((item:any,index:number) =>
                    <TableItemEmployee key={key} item={item}/>
                )}

            </TableBody>
        </Table>
    );
}

export default EmployeeTable;
