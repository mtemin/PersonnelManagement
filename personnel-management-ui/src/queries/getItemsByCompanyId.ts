// noinspection JSAnnotator

import axios from "axios";

export async function getItemsByCompanyId(item:string, companyId:number) {
    return axios({
        url: `https://localhost:44393/Get${item}sByCompanyId/${companyId}`,
        method: 'get',
        headers: {"content-type": "application/json"},
        // data: {"query": getCompaniesQuery}
    })

}
