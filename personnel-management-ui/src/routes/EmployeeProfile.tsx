import EmployeeTable from "@/components/EmployeeTable.tsx";
import {useParams} from "react-router-dom";
import useItemsByEmployeeIdQuery from "@/hooks/useItemsByEmployeeId.ts";
import useEmployeeQuery from "@/hooks/useEmployeeQuery.ts";
import {getItemsByCompanyId} from "@/queries/getItemsByCompanyId.ts";

function EmployeeProfile() {
    const  {employeeId}  = useParams();
    console.log(employeeId)
    const {data,isLoading,isError}:{data:Employee,isLoading:any,isError:any} = useEmployeeQuery(employeeId);
    // const {data: certificateData, isLoading: certificateIsLoading, isError: certificateIsError} = useItemsByEmployeeIdQuery("Certificate",employeeId);
    // const {data: leaveDaysData, isLoading: leaveDaysIsLoading, isError: leaveDaysIsError} = useItemsByEmployeeIdQuery("LeaveDay",employeeId);
    // const {data: educationData, isLoading: educationIsLoading, isError: educationIsError} = useItemsByEmployeeIdQuery("Education",employeeId);
    // if(certificateIsLoading) return "is loading"
    // if(leaveDaysIsLoading) return "is loading"
    // if(educationIsLoading) return "is loading"
    return (
        <main className="container font-medium mx-auto mt-10 ">
            <div id="profile" className="text-center my-10">

                <p className="text-3xl">{data?.name}&nbsp;{data?.surname}</p>
                {/*<p className="text-2xl italic">{data?.title}</p>*/}
                <p className="flex justify-center items-center mx-auto mt-10">
                    Working as <span>&nbsp;{data?.title}&nbsp;</span> in the company <span>&nbsp;{}&nbsp;</span>
                </p>
            </div>
            <div className="flex h-[40rem]">
                <section className="p-5 border border-border rounded overflow-scroll mr-2 ">
                    <p className="text-xl">Employees</p>
                    {/*<EmployeeTable key={certificateData?.id} itemCollection={certificateData}/>*/}
                </section>
                <div className="flex flex-col ml-2 max-h-[100vh]">
                    <section className="bg-card border border-border p-5 rounded overflow-scroll mb-4">
                        <p className="text-xl">Expenses</p>
                        {/*<EmployeeTable key={leaveDaysData?.id} itemCollection={leaveDaysData}/>*/}
                    </section>
                    <section className="bg-card border border-border p-5 rounded overflow-scroll">
                        <p className="text-xl">Leave days</p>
                        {/*<EmployeeTable key={educationData?.id} itemCollection={educationData}/>*/}
                    </section>
                </div>
            </div>
        </main>
    );
}

export default EmployeeProfile;
