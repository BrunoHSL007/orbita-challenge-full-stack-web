import { http } from "./config"

export default {
    list: (phrase) => {
        console.log(phrase)
        return http.get('students',{ params: { "phrase": phrase} })
    },

    create: (student) => {
        return http.post('students',student)
    },

    edit: (student, id) => {
        return http.put(`students/${id}`,student)
    },

    get: (id) => {
        return http.get(`students/${id}`)
    },

    delete: (id) => {
        return http.delete(`students/${id}`)
    }
}