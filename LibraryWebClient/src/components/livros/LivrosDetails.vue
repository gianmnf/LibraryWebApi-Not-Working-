<template>
  <div>
    <div class="well">
      <div class="row">
        <div class="col-md-3">
          <strong>Nome do Livro:</strong>
        </div>
        <div class="col-md-3">
          {{ livros.nome }}
        </div>
      </div>
      <div class="row">
        <div class="col-md-3">
          <strong>Preço:</strong>
        </div>
        <div class="col-md-3">
          {{ livros.preco }}
        </div>
      </div>
      <div class="row">
        <div class="col-md-3">
          <strong>Tipo:</strong>
        </div>
        <div class="col-md-3">
          <span class="text-info">{{ livros.tipo }}</span>
        </div>
      </div>
      <div class="row">
        <div class="col-md-3">
          <strong>Autor:</strong>
        </div>
        <div class="col-md-3">
          <span class="text-info">{{ livros.autor }}</span>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import LivrosService from '@/api-services/livros.service'

export default {
  name: 'LivrosDetails',
  data () {
    return {
      livros: {}
    }
  },
  created () {
    LivrosService.getLivros(this.$router.currentRoute.params.id).then(response => {
      this.livros = response.data
    })
  }
}
</script>
