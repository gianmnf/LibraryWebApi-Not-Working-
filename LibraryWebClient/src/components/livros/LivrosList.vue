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
    <b-modal
      ref="deleteConfirmModal"
      title="Confirme sua Ação"
      @ok="onDeleteConfirm"
      @hide="onDeleteModalHide">
      <p class="my-4">Deseja apagar este livro?</p>
    </b-modal>

    <b-modal
      ref="alertModal"
      :title="alertModalTitle"
      :ok-only="true">
      <p class="my-4">{{ alertModalContent }}</p>
    </b-modal>
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
      livros: [],
      selectedLivrosId: null,
      alertModalTitle: '',
      alertModalContent: ''
    }
  },
  created () {
    LivrosService.getAll().then((response) => {
      this.livros = response.data
    })
  },
  methods: {
    detailsLivros (livroId) {
      this.$router.push({ name: 'LivrosDetails', params: { id: livroId } })
    },
    updateLivros (livroId) {
      console.log('update', livroId)
    },
    deleteLivros (livroId) {
      this.selectedLivrosId = livroId
      this.$refs.deleteConfirmModal.show()
    },
    fetchLivros () {
      LivrosService.getAll().then((response) => {
        this.livros = response.data
      })
    },
    onDeleteConfirm () {
      LivrosService.delete(this.selectedLivrosId).then(() => {
        this.alertModalTitle = 'Sucesso'
        this.alertModalContent = 'Livro removido com sucesso.'
        this.$refs.alertModal.show()
        this.fetchLivros()
      }).catch((error) => {
        this.alertModalTitle = 'Erro'
        this.alertModalContent = error.response.data
        this.$refs.alertModal.show()
      })
    },
    onDeleteModalHide () {
      this.selectedLivrosId = null
    }
  }
}
</script>
