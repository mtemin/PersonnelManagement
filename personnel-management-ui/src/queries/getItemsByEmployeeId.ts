// noinspection JSAnnotator

import axios from "axios";

export async function getItemsByEmployeeId(item,employeeId) {
    return axios({
        url: `https://localhost:44393/Get${item}sByEmployeeId/${employeeId}`,
        method: 'get',
        headers: {"content-type": "application/json"},
        // data: {"query": getCompaniesQuery}
    })

}
