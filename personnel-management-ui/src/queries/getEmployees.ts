// noinspection JSAnnotator

import axios from "axios";

export async function getEmployees() {
    return axios({
        url: `https://localhost:44393/GetAllEmployees`,
        method: 'get',
        headers: {"content-type": "application/json"},
        // data: {"query": getEmployeesQuery}
    })

}
