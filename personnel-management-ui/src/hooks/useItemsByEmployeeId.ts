import {useQuery} from "@tanstack/react-query";
import {getCompanies} from "../queries/getCompanies.ts";
import {getItemsByCompanyId} from "@/queries/getItemsByCompanyId.ts";
import {getItemsByEmployeeId} from "@/queries/getItemsByEmployeeId.ts";

export function useItemsByEmployeeIdQuery(item, id) {
    const queryKey = [`${item}List`,id];

    const queryFn = async () => {
        const result = await getItemsByEmployeeId(item,id);
        return result.data;
    };

    return useQuery({queryKey, queryFn});
    // return useQuery({queryKey, queryFn, enabled: false});//render esnasında çalışmayacak
}

export default useItemsByEmployeeIdQuery;
