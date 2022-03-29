import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'students',
    component: () => import('../views/students/List.vue')
  },
  {
    path: '/edit-student',
    name: 'edit-student',
    component: () => import( '../views/students/Edit.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
