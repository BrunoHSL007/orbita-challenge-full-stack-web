import { http } from "./config"

export default {
    list: () => {
        return http.get('students')
    },

    create: () => {
        return http.post('students')
    }
}