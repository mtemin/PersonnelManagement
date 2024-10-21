import { useQuery } from "@tanstack/react-query";
import axios from "axios";

export function useCompanyQuery(companyId) {
    const queryKey = ['company', companyId];

    const queryFn = async () => {
        const response = await axios.get(`https://localhost:44393/GetCompany/${companyId}`);
        return response.data; // Assuming the response contains the company data
    };

    return useQuery({ queryKey, queryFn, enabled: !!companyId }); // Only run if companyId is truthy
}

export default useCompanyQuery;
