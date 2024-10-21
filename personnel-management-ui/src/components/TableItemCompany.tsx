import {TableCell, TableRow} from "@/components/ui/table.tsx";
import {Badge} from "@/components/ui/badge.tsx";
import {
    DropdownMenu,
    DropdownMenuContent, DropdownMenuItem,
    DropdownMenuLabel,
    DropdownMenuTrigger
} from "@/components/ui/dropdown-menu.tsx";
import {Button} from "@/components/ui/button.tsx";
import {MoreHorizontal, SquareArrowOutUpRight} from "lucide-react";

function TableItemCompany({item}:{item:Company}) {


    return (
        <TableRow>


            <TableCell className="flex justify-center mt-2">
                <a className="cursor-pointer" href={`company/${item.companyId}`}>
                    <SquareArrowOutUpRight className="max-h-8" />
                </a>
            </TableCell>
            <TableCell className="text-lg font-medium py-4">
                {item.name}
            </TableCell>

            <TableCell className="hidden md:table-cell">
                {/*{item.employees}*/}
            </TableCell>

            <TableCell>

                <DropdownMenu>
                    <DropdownMenuTrigger asChild>
                        <Button
                            aria-haspopup="true"
                            size="icon"
                            variant="ghost"
                        >
                            <MoreHorizontal className="h-4 w-4" />
                            <span className="sr-only">Toggle menu</span>
                        </Button>
                    </DropdownMenuTrigger>
                    <DropdownMenuContent align="end">
                        <DropdownMenuLabel>Actions</DropdownMenuLabel>
                        <DropdownMenuItem>Edit Company</DropdownMenuItem>
                        <DropdownMenuItem>Delete Company</DropdownMenuItem>
                    </DropdownMenuContent>
                </DropdownMenu>

            </TableCell>
        </TableRow>
    );
}

export default TableItemCompany;
