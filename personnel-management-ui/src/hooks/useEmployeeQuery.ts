import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import {getEmployee} from "@/queries/getEmployee.ts";

export function useEmployeeQuery(employeeId) {
    const queryKey = ['employee', employeeId];

    const queryFn = async () => {
        const response = await getEmployee(employeeId);
        return response.data;
    };

    return useQuery({ queryKey, queryFn, enabled: !!employeeId }); // Only run if companyId is truthy
}

export default useEmployeeQuery;
