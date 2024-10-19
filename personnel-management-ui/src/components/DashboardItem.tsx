import {Tooltip, TooltipContent, TooltipProvider, TooltipTrigger} from "@/components/ui/tooltip.tsx";
import {Link} from "react-router-dom";
import {Users2} from "lucide-react";

function DashboardItem({name,icon,link}:{name:any,icon:any,link:string}) {
    return (
        <TooltipProvider><Tooltip>
        <TooltipTrigger asChild>
            <Link
                to={`/${link.toLowerCase()}`}
                className="flex h-9 w-9 items-center justify-center rounded-lg text-muted-foreground transition-colors hover:text-foreground md:h-8 md:w-8"
            >
                {/*<Users2 className="h-5 w-5"/>*/}
                {icon}
                <span className="sr-only">{name}</span>
            </Link>
        </TooltipTrigger>
        <TooltipContent side="right">{name}</TooltipContent>
    </Tooltip></TooltipProvider>
    );
}

export default DashboardItem;
