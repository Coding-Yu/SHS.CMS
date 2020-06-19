<template>
  <div id="app">
    <router-view />
  </div>
</template>

<script>
export default {
  name: 'App',
  mounted() {
    const script = document.createElement('script')
    script.src = 'https://s9.cnzz.com/z_stat.php?id=1278866934&web_id=1278866934'
    script.language = 'JavaScript'
    document.body.appendChild(script)
  },
  watch: {
    '$route'() {
      if (window._czc) {
        const location = window.location
        const contentUrl = location.pathname + location.hash
        const refererUrl = '/'
        window._czc.push(['_trackPageview', contentUrl, refererUrl])
      }
    }
  }
}
</script>
