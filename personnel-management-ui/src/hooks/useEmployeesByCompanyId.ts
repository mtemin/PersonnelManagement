import {useQuery} from "@tanstack/react-query";
import {getCompanies} from "../queries/getCompanies.ts";
import {getEmployeesByCompanyId} from "@/queries/getEmployeeByCompanyId.ts";

export function useEmployeesByCompanyIdQuery(companyId) {
    const queryKey = ['employees',companyId];

    const queryFn = async () => {
        const result = await getEmployeesByCompanyId(companyId);
        return result.data;
    };

    return useQuery({queryKey, queryFn});
    // return useQuery({queryKey, queryFn, enabled: false});//render esnasında çalışmayacak
}

export default useEmployeesByCompanyIdQuery;
