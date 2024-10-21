import {TableCell, TableRow} from "@/components/ui/table.tsx";
import {Badge} from "@/components/ui/badge.tsx";
import {
    DropdownMenu,
    DropdownMenuContent, DropdownMenuItem,
    DropdownMenuLabel,
    DropdownMenuTrigger
} from "@/components/ui/dropdown-menu.tsx";
import {Button} from "@/components/ui/button.tsx";
import {MoreHorizontal} from "lucide-react";
import useCompanyQuery from "@/hooks/useCompanyQuery.ts";
import axios from "axios";
import useCompanyNameQuery from "@/hooks/useCompanyNameQuery.ts";

function TableItemEmployee({item}: { item: Employee }) {
    const {
        data: companyData,
        isLoading: isCompanyLoading,
        isError: isCompanyError,
        error
    } = useCompanyQuery(item.companyId);

    function deleteEmployee(id:number){

            const confirmDelete = window.confirm(`Are you sure you want to delete employee named ${item.name}?`);
            if (confirmDelete) {
                axios.delete(`https://localhost:44393/DeleteEmployee/${id}`)
                    .then(response => {
                        console.log(`Employee with ID ${id} deleted successfully.`);
                        // Optionally, update the state to remove the deleted employee from the UI
                    })
                    .catch(error => {
                        console.error(`Error deleting employee with ID ${id}:`, error);
                        // Optionally, inform the user about the error
                    });
            }
    }
    return (
        <TableRow>
            <TableCell className="font-medium">
                {item.name}
            </TableCell>
            <TableCell>
                {item.surname}
            </TableCell>
            <TableCell className="hidden md:table-cell">

                {companyData &&
                <a className="underline" href={`company/${companyData.companyId}`}>
                    {companyData.name}
                </a>
                }
            </TableCell>
            <TableCell className="hidden md:table-cell">
                {item.title}
            </TableCell>

            <TableCell>
                <DropdownMenu>
                    <DropdownMenuTrigger asChild>
                        <Button
                            aria-haspopup="true"
                            size="icon"
                            variant="ghost"
                        >
                            <MoreHorizontal className="h-4 w-4"/>
                            <span className="sr-only">Toggle menu</span>
                        </Button>
                    </DropdownMenuTrigger>
                    <DropdownMenuContent align="end">
                        <DropdownMenuLabel>Actions</DropdownMenuLabel>
                        <DropdownMenuItem className="cursor-pointer">Edit</DropdownMenuItem>
                        <DropdownMenuItem className="cursor-pointer" onClick={() => {
                            deleteEmployee(item.employeeId)
                        }}>
                            Delete
                        </DropdownMenuItem>
                    </DropdownMenuContent>
                </DropdownMenu>
            </TableCell>
        </TableRow>
    );
}

export default TableItemEmployee;
