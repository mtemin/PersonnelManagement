import React from 'react';
import {Link} from "react-router-dom";
import {
    Home, HousePlus,
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
                        {/*<DropdownMenuItem><a href="/settings">Settings</a> </DropdownMenuItem>*/}
                        <DropdownMenuSeparator />
                        <DropdownMenuItem>Logout</DropdownMenuItem>
                    </DropdownMenuContent>
                </DropdownMenu>

                <DashboardItem name="Add Company" icon={<HousePlus/>} link={"add-company"}></DashboardItem>
                <DashboardItem name="Add Employee" icon={<UserPlus/>} link={"add-employee"}></DashboardItem>

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
