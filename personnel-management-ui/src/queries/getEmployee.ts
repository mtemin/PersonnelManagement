// noinspection JSAnnotator

import axios from "axios";

export async function getEmployee(id) {
    return axios({
        url: `https://localhost:44393/GetEmployee/${id}`,
        method: 'get',
        headers: {"content-type": "application/json"},
    })

}
