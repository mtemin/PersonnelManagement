import {useQuery} from "@tanstack/react-query";
import {getEmployees} from "../queries/getEmployees";

export function useEmployeesQuery() {
    const queryKey = ['employees'];

    const queryFn = async () => {
        const result = await getEmployees();
        return result.data;
    };

    return useQuery({queryKey, queryFn});
    // return useQuery({queryKey, queryFn, enabled: false});//render esnasında çalışmayacak
}

export default useEmployeesQuery;
