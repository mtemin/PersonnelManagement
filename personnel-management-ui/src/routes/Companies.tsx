import {
    File,
    Home,
    LineChart,
    ListFilter,
    MoreHorizontal,
    Package,
    Package2,
    PanelLeft,
    PlusCircle,
    Search,
    Settings,
    ShoppingCart,
    Users2,
} from "lucide-react"

import { Badge } from "@/components/ui/badge"
// import {
//     Breadcrumb,
//     BreadcrumbItem,
//     BreadcrumbLink,
//     BreadcrumbList,
//     BreadcrumbPage,
//     BreadcrumbSeparator,
// } from "@/components/ui/breadcrumb"
import { Button } from "@/components/ui/button"
import {
    Card,
    CardContent,
    CardDescription,
    CardFooter,
    CardHeader,
    CardTitle,
} from "@/components/ui/card"
import {
    DropdownMenu,
    DropdownMenuCheckboxItem,
    DropdownMenuContent,
    DropdownMenuItem,
    DropdownMenuLabel,
    DropdownMenuSeparator,
    DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import { Input } from "@/components/ui/input"
import { Sheet, SheetContent, SheetTrigger } from "@/components/ui/sheet"
import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
} from "@/components/ui/table"
import {
    Tabs,
    TabsContent,
    TabsList,
    TabsTrigger,
} from "@/components/ui/tabs"
import {
    Tooltip,
    TooltipContent, TooltipProvider,
    TooltipTrigger,
} from "@/components/ui/tooltip"
import {Link} from "react-router-dom";
import TableItemCompany from "@/components/TableItemCompany.tsx";
import DashboardTab from "@/components/DashboardTab.tsx";
import useCompaniesQuery from "@/hooks/useCompaniesQuery.ts";

export const description =
    "An products dashboard with a sidebar navigation. The sidebar has icon navigation. The content area has a breadcrumb and search in the header. It displays a list of products in a table with actions."

export function Companies() {

    const {
        data: companyData,
        isLoading: isCompanyLoading,
        isError: isCompanyError,
        error
    } = useCompaniesQuery();

    if (isCompanyLoading) return <div>Loading companies...</div>;

    if (isCompanyError) return <div>Error fetching companies: {error}</div>;



    return (
        <main className="flex min-h-screen w-full flex-col bg-muted/40">
            <DashboardTab/>
            <div className="flex flex-col pl-10 container mx-auto sm:gap-4 sm:py-4 ">
                <header className="sticky top-0 z-30 flex h-14 items-center gap-4 border-b bg-background px-4 sm:static sm:h-auto sm:border-0 sm:bg-transparent sm:px-6">
                    {/*<div className="relative ml-auto flex-1 md:grow-0">*/}
                    {/*    <Search className="absolute left-2.5 top-2.5 h-4 w-4 text-muted-foreground" />*/}
                    {/*    <Input*/}
                    {/*        type="search"*/}
                    {/*        placeholder="Search..."*/}
                    {/*        className="w-full rounded-lg bg-background pl-8 md:w-[200px] lg:w-[336px]"*/}
                    {/*    />*/}
                    {/*</div>*/}

                </header>
                <main className="grid flex-1 items-start gap-4 sm:px-6 sm:py-0 md:gap-8 max-sm:m-4">
                    <Tabs defaultValue="all">
                        <TabsContent value="all">
                            <Card x-chunk="dashboard-06-chunk-0">
                                <CardHeader>
                                    <CardTitle>Companies</CardTitle>
                                    <CardDescription>
                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ab aut deleniti dicta dolores, error et illo inventore ipsam laudantium magni nam natus, nesciunt omnis praesentium quidem quisquam suscipit velit vero!
                                    </CardDescription>
                                </CardHeader>
                                <CardContent>
                                    <Table>
                                        <TableHeader>
                                            <TableRow>
                                                {/*<TableHead className="w-[100px] sm:table-cell">*/}
                                                {/*    <span className="sr-only">img</span>*/}
                                                {/*</TableHead>*/}
                                                <TableHead className="max-w-6 ">Detail page</TableHead>
                                                <TableHead>Name</TableHead>
                                                <TableHead className="hidden md:table-cell">
                                                    Employees
                                                </TableHead>
                                                <TableHead>
                                                    <span className="sr-only">Actions</span>
                                                </TableHead>
                                            </TableRow>
                                        </TableHeader>
                                        <TableBody>
                                            {companyData.map((company:Company) =>
                                           <TableItemCompany key={company.companyId} item={company}/>
                                            )}

                                        </TableBody>
                                    </Table>
                                </CardContent>
                                <CardFooter>
                                    <div className="text-xs text-muted-foreground">
                                        Displaying
                                        &nbsp;
                                        <strong>{companyData.length}</strong>
                                        &nbsp;
                                        products
                                    </div>
                                </CardFooter>
                            </Card>
                        </TabsContent>
                    </Tabs>
                </main>
            </div>
        </main>
    )
}
