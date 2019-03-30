<template>
  <div>
    <b-row>
      <b-col md="2" offset-md="10">
        <a href="#">Adicionar Livro</a>
      </b-col>
    </b-row>
    <br />
    <b-row>
      <b-col md="12">
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Nome do Livro</th>
                <th>Preço</th>
                <th>Tipo do Livro</th>
                <th>Autor do Livro</th>
                <th>Detalhes</th>
                <th>Atualizar</th>
                <th>Remover</th>
              </tr>
            </thead>
            <tbody>
              <livros-list-row
               v-for="livros in livros"
               :key="livros.id"
               :livros="livros"
               @details="detailsLivros"
               @update="updateLivros"
               @delete="deleteLivros"/>
            </tbody>
          </table>
        </div>
      </b-col>
    </b-row>
  </div>
</template>
<script>
import LivrosService from '@/api-services/livros.service'
import LivrosListRow from '@/components/livros/LivrosListRow'
export default {
  name: 'LivrosList',
  components: {
    LivrosListRow
  },
  data () {
    return {
      livros: []
    }
  },
  created () {
    LivrosService.getAll().then((response) => {
      this.livros = response.data
    })
  },
  methods: {
    detailsLivros (livroId) {
      console.log('details', livroId)
    },
    updateLivros (livroId) {
      console.log('update', livroId)
    },
    deleteLivros (livroId) {
      console.log('delete', livroId)
    }
  }
}
</script>
