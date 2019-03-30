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
              <tr v-for="livros in livros" :key="livros.id">
                <td>{{ livros.nome }}</td>
                <td>{{ livros.preco }}</td>
                <td>{{ livros.tipo }}</td>
                <td>{{ livros.autor }}</td>
                <td>
                  <b-button variant="light">Detalhes</b-button>
                </td>
                <td>
                  <b-button variant="success">Atualizar</b-button>
                </td>
                <td>
                  <b-button variant="danger">Remover</b-button>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </b-col>
    </b-row>
  </div>
</template>
<script>
import LivrosService from '@/api-services/livros.service'
export default {
  name: 'LivrosList',
  data () {
    return {
      livros: []
    }
  },
  created () {
    LivrosService.getAll().then((response) => {
      this.livros = response.data
    })
  }
}
</script>
