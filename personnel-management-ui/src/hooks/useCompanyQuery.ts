import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import {getCompany} from "@/queries/getCompany.ts";

export function useCompanyQuery(companyId) {
    const queryKey = ['company', companyId];

    const queryFn = async () => {
        const response = await getCompany(companyId);
        return response.data;
    };

    return useQuery({ queryKey, queryFn, enabled: !!companyId }); // Only run if companyId is truthy
}

export default useCompanyQuery;
