import { createRouter, createWebHistory } from 'vue-router'
import TaskManagementPage from '../pages/TaskManagementPage.vue'
import RealtimeDashboardPage from '../pages/RealtimeDashboardPage.vue'

const routes = [
  { path: '/', redirect: '/tasks' },
  { path: '/tasks', name: 'tasks', component: TaskManagementPage },
  { path: '/dashboard', name: 'dashboard', component: RealtimeDashboardPage }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
