import {TableCell, TableRow} from "@/components/ui/table.tsx";
import { DotFilledIcon } from "@radix-ui/react-icons"
import {
    DropdownMenu,
    DropdownMenuContent, DropdownMenuItem,
    DropdownMenuLabel,
    DropdownMenuTrigger
} from "@/components/ui/dropdown-menu.tsx";
import {Button} from "@/components/ui/button.tsx";
import {MoreHorizontal} from "lucide-react";
import axios from "axios";
import useCompanyQuery from "@/hooks/useCompanyQuery.ts";

function TableItemExpense({item}: { item: Expense }) {
    const {
        data: companyData,
        isLoading: isCompanyLoading,
        isError: isCompanyError,
        error
    } = useCompanyQuery(item.companyId);

    function deleteExpense(id: number) {

        const confirmDelete = window.confirm(`Are you sure you want to delete item log titled : ${item.title}?`);
        if (confirmDelete) {
            axios.delete(`https://localhost:44393/DeleteExpense/${id}`)
                .then(response => {
                    console.log(`Expense with ID ${id} deleted successfully.`);
                })
                .catch(error => {
                    console.error(`Error deleting item with ID ${id}:`, error);
                });
        }
    }

    return (
        <>
            <TableRow>
                <TableCell className="hidden md:table-cell">
                    {item.isApproved
                        ? <DotFilledIcon className="text-green-700 w-10 h-10"/>
                        : <DotFilledIcon className="text-rose-700 w-10 h-10"/>
                    }
                </TableCell>
                <TableCell>
                    <a className="underline" href={`employee/${item.employeeId}`}>
                        {item.employeeId}
                    </a>
                </TableCell>
                <TableCell className="font-medium">
                    {item.amount}
                </TableCell>
                <TableCell>
                    {item.title}
                </TableCell>
                <TableCell className="hidden md:table-cell">
                    {item.description}
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
                                deleteExpense(item.expenseId)
                            }}>
                                Delete
                            </DropdownMenuItem>
                        </DropdownMenuContent>
                    </DropdownMenu>
                </TableCell>
            </TableRow>
        </>
    );
}

export default TableItemExpense;
