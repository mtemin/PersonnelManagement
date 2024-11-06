import * as domain from "domain";
import { useParams } from "react-router-dom";
import useItemQuery, {useCompanyQuery} from "@/hooks/useCompanyQuery.ts";
import EmployeeTable from "@/components/EmployeeTable.tsx";
import useEmployeesByCompanyIdQuery, {useItemsByCompanyIdQuery} from "@/hooks/useItemsByCompanyId.ts";

function CompanyProfile() {
    const  {companyId}  = useParams();
    const {data,isLoading,isError}:{data:Company,isLoading:any,isError:any} = useCompanyQuery(companyId);
    const {data: employeesData, isLoading: employeesIsLoading, isError: employeesIsError} = useItemsByCompanyIdQuery("Employee",data?.companyId);

    if (isLoading) return <div>Loading company...</div>;
    if(employeesIsLoading) return <div>Loading employees of {data?.name} ...</div>;

    if (isError) return <div>Error fetching company</div>;
    if(employeesIsError) return <div>Error fetching employees of {data?.name}</div>;


    return (
        <main className="container font-medium mx-auto mt-10 ">
            <h3 className="text-4xl mb-8">
            {data?.name}
            </h3>
            <div className="flex h-[40rem]">
                <section className="p-5 border border-border rounded overflow-scroll mr-2 ">
                    <p className="text-xl">Employees</p>
                    <EmployeeTable key={employeesData?.id} itemCollection={employeesData}/>
                </section>
            <div className="flex flex-col ml-2 max-h-[100vh]">
                <section className="bg-card border border-border p-5 rounded overflow-scroll mb-4">
                    <p className="text-xl">Expenses</p>
                    <EmployeeTable key={employeesData?.id} itemCollection={employeesData}/>
                </section>
                <section className="bg-card border border-border p-5 rounded overflow-scroll">
                    <p className="text-xl">Leave days</p>
                    <EmployeeTable key={employeesData?.id} itemCollection={employeesData}/>
                </section>
            </div>
            </div>
        </main>
    );
}

export default CompanyProfile;
