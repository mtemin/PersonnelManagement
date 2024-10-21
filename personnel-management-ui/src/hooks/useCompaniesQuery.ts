import {useQuery} from "@tanstack/react-query";
import {getCompanies} from "../queries/getCompanies.ts";

export function useCompaniesQuery() {
    const queryKey = ['companies'];

    const queryFn = async () => {
        const result = await getCompanies();
        return result.data;
    };

    return useQuery({queryKey, queryFn});
    // return useQuery({queryKey, queryFn, enabled: false});//render esnasında çalışmayacak
}

export default useCompaniesQuery;
