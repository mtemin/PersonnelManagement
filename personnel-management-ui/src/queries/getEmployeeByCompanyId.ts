// noinspection JSAnnotator

import axios from "axios";

export async function getEmployeesByCompanyId(companyId:number) {
    return axios({
        url: `https://localhost:44393/GetEmployeesByCompanyId${companyId}`,
        method: 'get',
        headers: {"content-type": "application/json"},
        // data: {"query": getCompaniesQuery}
    })

}
