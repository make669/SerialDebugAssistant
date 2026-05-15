import { createRouter, createWebHistory } from 'vue-router'
import RealtimeDashboardView from '../views/RealtimeDashboardView.vue'

const routes = [
  {
    path: '/',
    name: 'dashboard',
    component: RealtimeDashboardView,
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router
