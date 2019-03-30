<template>
  <p class="homeText">
    Bem-vindo ao CRUD Livraria!
  </p>
</template>
<script>
// import LivrosService from '@/api-services/livros.service'
export default {
  name: 'Home'
  /* Testando Conexão com backend
  created () {
    LivrosService.getAll().then((response) => {
      console.log(response.data)
    }).catch((error) => {
      console.log(error.response.data)
    })
  } */
}
</script>
<style scoped>
.homeText{
    font-size: 35px;
    color: red;
    text-align: center;
    position: relative;
    top:30px;
    text-shadow: 2px 2px 2px gray;
}
</style>
