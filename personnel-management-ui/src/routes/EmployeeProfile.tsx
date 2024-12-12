import {useParams} from "react-router-dom";
import useItemsByEmployeeIdQuery from "@/hooks/useItemsByEmployeeId.ts";
import useEmployeeQuery from "@/hooks/useEmployeeQuery.ts";
import LeaveDayTable from "@/components/LeaveDayTable.tsx";
import ExpenseTable from "@/components/ExpenseTable.tsx";

function EmployeeProfile() {
    const  {employeeId}  = useParams();
    console.log(employeeId)
    const {data,isLoading,isError}:{data:Employee,isLoading:any,isError:any} = useEmployeeQuery(employeeId);

    // const {data: certificateData, isLoading: certificateIsLoading, isError: certificateIsError} = useItemsByEmployeeIdQuery("ProfessionalExperience",employeeId);
    // const {data: leaveDaysData, isLoading: leaveDaysIsLoading, isError: leaveDaysIsError} = useItemsByEmployeeIdQuery("Certificate",employeeId);
    // const {data: educationData, isLoading: educationIsLoading, isError: educationIsError} = useItemsByEmployeeIdQuery("Education",employeeId);
    const {data: expenseData, isLoading: expenseIsLoading, isError: expenseIsError} = useItemsByEmployeeIdQuery("Expense",employeeId);
    const {data: leaveDaysData, isLoading: leaveDaysIsLoading, isError: leaveDaysIsError} = useItemsByEmployeeIdQuery("LeaveDay",employeeId);
    if(leaveDaysIsLoading) return "is loading"
    if(expenseIsLoading) return "is loading"
    return (
        <main className="container font-medium mx-auto mt-10 grid grid-cols-9 gap-4 max-sm:p-8 max-sm:mt-0">
            <div id="profile-card" className="text-center col-span-3 max-sm:col-span-9 ">
                <div id="employee-bio" className="mb-4 border rounded p-4 border-amber-50 h-min">
                    <p className="text-2xl">{data?.name}&nbsp;{data?.surname}</p>
                    {/*<p className="text-2xl italic">{data?.title}</p>*/}
                    <p className="flex justify-center items-center mx-auto my-4 text-wrap">
                        &nbsp;{data?.title}&nbsp;
                    </p>
                    <p className="flex justify-center items-center mx-auto my-4 text-wrap">
                        &nbsp;{data?.companyId}&nbsp;
                    </p>
                    <p></p>
                    <div id="contact-info" className="flex flex-col items-start">
                        <p className="my-1">Has <span
                            className="font-bold text-blue-500">{leaveDaysData.length}</span> Leave Day requests</p>
                        <p className="my-1">Has <span
                            className="font-bold text-blue-500">{expenseData.length}</span> Expense requests</p>
                    </div>
                </div>
                <div id="employee-certificates" className="mb-4 border rounded p-4 border-amber-50 h-min">
                    <h4 className="text-lg">Certificates</h4>
                    <div className="certificate">
                        <div className="flex justify-between pb-1 border-b">
                            <p>Certificate Name : </p>
                            <p>SPA Eğitimi</p>
                        </div>
                        <div className="flex justify-between  pb-1 border-b">
                            <p>Issuing Organization : </p>
                            <p>Tiktok Academy</p>
                        </div>
                        <div className="flex justify-between  pb-1 border-b">
                            <p>Total Hours : </p>
                            <p>480</p>
                        </div>

                    </div>
                </div>
                <div id="employee-professional-educations" className="mb-4 border rounded p-4 border-amber-50 h-min">
                    <h4 className="text-lg">Professional Experiences</h4>
                    <div className="certificate">
                        <div className="flex justify-between pb-1 border-b">
                            <p>Company : </p>
                            <p>GOGLE PLAY</p>
                        </div>
                        <div className="flex justify-between  pb-1 border-b">
                            <p>Job Title : </p>
                            <p>Fly Hunter</p>
                        </div>

                    </div>
                </div>

            </div>
            <div id="employee-requests" className="col-span-6 max-sm:col-span-9 ">
                <p className="text-xl mb-4">Leave Day requests of {data.name}</p>
                <LeaveDayTable className="mb-6 px-2 py-6 border rounded border-amber-50 max-h-[400px]"
                               key={leaveDaysData?.id} itemCollection={leaveDaysData}
                               headers={["Is Approved", "Employee Id", "Type", "Title", "Description"]} />
                <p className="text-xl mb-4">Expense requests from {data.name}</p>

                <ExpenseTable className="mt-4 px-2 py-6 border rounded border-amber-50 max-h-[400px]"
                              key={expenseData?.id} itemCollection={expenseData}
                              headers={["Is Approved", "Employee Id", "Type", "Title", "Description"]} />


            </div>
        </main>
    );
}

export default EmployeeProfile;
