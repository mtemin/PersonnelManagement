import * as domain from "domain";
import { useParams } from "react-router-dom";
import useCompanyQuery from "@/hooks/useCompanyQuery.ts";
import CustomTable from "@/components/CustomTable.tsx";
import useEmployeesByCompanyIdQuery from "@/hooks/useEmployeesByCompanyId.ts";
import {Table, TableBody, TableHead, TableHeader, TableRow} from "@/components/ui/table.tsx";
import TableItemEmployee from "@/components/TableItemEmployee.tsx";
function CompanyProfile() {
    const  {companyId}  = useParams();
    const {data,isLoading,isError}:{data:Company,isLoading:any,isError:any} = useCompanyQuery(companyId);
    const {data: employeesData, isLoading: employeesIsLoading, isError: employeesIsError} = useEmployeesByCompanyIdQuery(data?.companyId);
    if (isLoading) return <div>Loading company...</div>;
    if(employeesIsLoading) return <div>Loading employees of {data?.name} ...</div>;
    if (isError) return <div>Error fetching company</div>;
    if(employeesIsError) return <div>Error fetching employees of {data?.name}</div>;
    console.log(employeesData)

    return (
        <main className="container font-medium mx-auto mt-10">
            <h3 className="text-4xl">
            {data?.name}
            </h3>
            <section>
                <p className="text-xl">Employees</p>

                    <Table>
                        <TableHeader>
                            <TableRow>
                                {/*<TableHead className="hidden w-[100px] sm:table-cell">*/}
                                {/*    <span className="sr-only">img</span>*/}
                                {/*</TableHead>*/}
                                <TableHead>Name</TableHead>
                                <TableHead>Surname</TableHead>
                                <TableHead className="hidden md:table-cell">
                                    Company
                                </TableHead>
                                <TableHead className="hidden md:table-cell">
                                    Job Title
                                </TableHead>
                                <TableHead>
                                    <span className="sr-only">Actions</span>
                                </TableHead>
                            </TableRow>
                        </TableHeader>
                        <TableBody>
                            {employeesData && employeesData?.map((item:any,index:number) =>
                                <TableItemEmployee key={index} item={item}/>
                            )}

                        </TableBody>
                    </Table>
            </section>
        </main>
    );
}

export default CompanyProfile;
