import {Table, TableBody, TableHead, TableHeader, TableRow} from "@/components/ui/table.tsx";
import TableItemLeaveDay from "@/components/TableItemLeaveDay.tsx";

function LeaveDayTable(
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
                {itemCollection.map((item:LeaveDay) =>
                    <TableItemLeaveDay key={item.leaveDayId} item={item}/>
                )}
            </TableBody>
        </Table>
    );
}

export default LeaveDayTable;
