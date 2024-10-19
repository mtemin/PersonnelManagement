import React from 'react';
import {Link} from "react-router-dom";
import {
    Home,
    LineChart,
    Package,
    Package2,
    Settings,
    ShoppingCart,
    User,
    UserPlus,
    UserRound,
    Users2
} from "lucide-react";
import {Tooltip, TooltipContent, TooltipProvider, TooltipTrigger} from "@/components/ui/tooltip.tsx";
import {
    DropdownMenu,
    DropdownMenuContent, DropdownMenuItem,
    DropdownMenuLabel, DropdownMenuSeparator,
    DropdownMenuTrigger
} from "@/components/ui/dropdown-menu.tsx";
import {Button} from "@/components/ui/button.tsx";
import DashboardItem from "@/components/DashboardItem.tsx";

function DashboardTab(props) {
    return (
        <aside className="fixed inset-y-0 left-0 z-10 hidden w-14 flex-col border-r bg-background sm:flex mr-12">
            <nav className="flex flex-col items-center gap-4 px-2 sm:py-5">
                <DropdownMenu>
                    <DropdownMenuTrigger asChild>
                        <Button
                            variant="outline"
                            size="icon"
                            className="overflow-hidden rounded-full mb-8"
                        >
                            <User />
                        </Button>
                    </DropdownMenuTrigger>
                    <DropdownMenuContent align="end">
                        <DropdownMenuItem><a href="/profile">Profile</a></DropdownMenuItem>
                        <DropdownMenuSeparator />
                        <DropdownMenuItem>Settings</DropdownMenuItem>
                        <DropdownMenuItem>Support</DropdownMenuItem>
                        <DropdownMenuSeparator />
                        <DropdownMenuItem>Logout</DropdownMenuItem>
                    </DropdownMenuContent>
                </DropdownMenu>
                <Link
                    to="#"
                    className="group flex h-9 w-9 shrink-0 items-center justify-center gap-2 rounded-full bg-primary text-lg font-semibold text-primary-foreground md:h-8 md:w-8 md:text-base"
                >
                    <Package2 className="h-4 w-4 transition-all group-hover:scale-110"/>
                    <span className="sr-only">Acme Inc</span>
                </Link>

                <TooltipProvider><Tooltip>
                    <TooltipTrigger asChild>
                        <Link
                            to="#"
                            className="flex h-9 w-9 items-center justify-center rounded-lg text-muted-foreground transition-colors hover:text-foreground md:h-8 md:w-8"
                        >
                            <Home className="h-5 w-5"/>
                            <span className="sr-only">Dashboard</span>
                        </Link>
                    </TooltipTrigger>
                    <TooltipContent side="right">Dashboard</TooltipContent>
                </Tooltip></TooltipProvider>
                <TooltipProvider><Tooltip>
                    <TooltipTrigger asChild>
                        <Link
                            to="#"
                            className="flex h-9 w-9 items-center justify-center rounded-lg bg-accent text-accent-foreground transition-colors hover:text-foreground md:h-8 md:w-8"
                        >
                            <ShoppingCart className="h-5 w-5"/>
                            <span className="sr-only">Orders</span>
                        </Link>
                    </TooltipTrigger>
                    <TooltipContent side="right">Orders</TooltipContent>
                </Tooltip></TooltipProvider>
                <TooltipProvider><Tooltip>
                    <TooltipTrigger asChild>
                        <Link
                            to="#"
                            className="flex h-9 w-9 items-center justify-center rounded-lg text-muted-foreground transition-colors hover:text-foreground md:h-8 md:w-8"
                        >
                            <Package className="h-5 w-5"/>
                            <span className="sr-only">Companies</span>
                        </Link>
                    </TooltipTrigger>
                    <TooltipContent side="right">Products</TooltipContent>
                </Tooltip></TooltipProvider>
                <DashboardItem name="Add Employee" icon={<UserPlus/>} link={"employees/create"}></DashboardItem>

            </nav>
            <nav className="mt-auto flex flex-col items-center gap-4 px-2 sm:py-5">
                <TooltipProvider><Tooltip>
                    <TooltipTrigger asChild>
                        <Link
                            to="#"
                            className="flex h-9 w-9 items-center justify-center rounded-lg text-muted-foreground transition-colors hover:text-foreground md:h-8 md:w-8"
                        >
                            <Settings className="h-5 w-5"/>
                            <span className="sr-only">Settings</span>
                        </Link>
                    </TooltipTrigger>
                    <TooltipContent side="right">Settings</TooltipContent>
                </Tooltip></TooltipProvider>
            </nav>
        </aside>
    );
}

export default DashboardTab;
