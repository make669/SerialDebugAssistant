<template>
  <div class="layout">
    <header>
      <h1>Face Emotion Recognition Console</h1>
      <nav>
        <RouterLink to="/tasks">Tasks</RouterLink>
        <RouterLink to="/dashboard">Realtime Dashboard</RouterLink>
      </nav>
    </header>
    <main>
      <RouterView />
    </main>
  </div>
</template>
