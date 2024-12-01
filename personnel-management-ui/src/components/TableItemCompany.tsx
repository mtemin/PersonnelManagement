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
import {Link} from "react-router-dom";

function TableItemCompany({company}:{company:Company}) {


    return (
        <TableRow>
            <TableCell className="text-lg font-medium py-4 text-center ">
            </TableCell>
            <TableCell className="text-lg font-medium py-4">
                <Link to={`/company/${company.companyId}`} className="duration-300 hover:text-blue-500">
                {company.name}
                </Link>
            </TableCell>

            <TableCell className="text-center">
                <DropdownMenu>
                    <DropdownMenuTrigger asChild>
                        <Button
                            aria-haspopup="true"
                            size="icon"
                            variant="ghost">
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
