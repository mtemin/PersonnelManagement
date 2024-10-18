import React from 'react';
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

function Company({company}:{company:Company}) {
    return (
        <TableRow>
            <TableCell className="hidden sm:table-cell">
                {/*<img*/}
                {/*    alt="Product img"*/}
                {/*    className="aspect-square rounded-md object-cover"*/}
                {/*    height="64"*/}
                {/*    src={`/${company.name}-logo`}*/}
                {/*    width="64"*/}
                {/*/>*/}
            </TableCell>
            <TableCell className="font-medium">
                {company.name}
            </TableCell>
            <TableCell>
                <Badge variant="outline">Draft</Badge>
            </TableCell>
            <TableCell className="hidden md:table-cell">
                $499.99
            </TableCell>
            <TableCell className="hidden md:table-cell">
                {company.employees}
            </TableCell>
            <TableCell className="hidden md:table-cell">
                2023-07-12 10:42 AM
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
                        <DropdownMenuItem>Edit</DropdownMenuItem>
                        <DropdownMenuItem>Delete</DropdownMenuItem>
                    </DropdownMenuContent>
                </DropdownMenu>
            </TableCell>
        </TableRow>
    );
}

export default Company;
