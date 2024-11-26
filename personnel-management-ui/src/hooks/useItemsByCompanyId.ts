import {useQuery} from "@tanstack/react-query";
import {getCompanies} from "../queries/getCompanies.ts";
import {getItemsByCompanyId} from "@/queries/getItemsByCompanyId.ts";

export function useItemsByCompanyIdQuery(item,companyId) {
    const queryKey = [item,companyId];

    const queryFn = async () => {
        const result = await getItemsByCompanyId(item,companyId);
        return result.data;
    };

    return useQuery({queryKey, queryFn});
    // return useQuery({queryKey, queryFn, enabled: false});//render esnasında çalışmayacak
}

export default useItemsByCompanyIdQuery;
