// noinspection JSAnnotator

import axios from "axios";

export async function getCompany(id:number) {
    return axios({
        url: `https://localhost:44393/GetCompany/${id}`,
        method: 'get',
        headers: {"content-type": "application/json"},
    })

}
