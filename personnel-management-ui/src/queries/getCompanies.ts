// noinspection JSAnnotator

import axios from "axios";

export async function getCompanies() {
    return axios({
        url: `https://localhost:44393/GetAllCompanies`,
        method: 'get',
        headers: {"content-type": "application/json"},
        // data: {"query": getCompaniesQuery}
    })

}
