<template>
  <b-container fluid>
    <div class="form-wrapper">
      <b-form @submit.prevent="createLivros">
        <b-form-group
          :label-cols="2"
          breakpoint="md"
          horizontal
          label="Nome do Livro:"
          for="nome">
          <b-col :md="5">
            <b-input
              id="nome"
              v-model="formData.nome"
              maxlength="150"
              required />
          </b-col>
        </b-form-group>

        <b-form-group
          :label-cols="2"
          breakpoint="md"
          horizontal
          label="Preço:"
          for="preco">
          <b-col :md="5">
            <b-input
              id="preco"
              v-model="formData.preco"
              type="number"
              required />
          </b-col>
        </b-form-group>

        <b-form-group
          :label-cols="2"
          breakpoint="md"
          horizontal
          label="Tipo:"
          for="tipo">
          <b-col :md="5">
            <b-input
              id="tipo"
              v-model="formData.tipo"
              maxlength="80"
              required />
          </b-col>
        </b-form-group>
        <b-form-group
          :label-cols="2"
          breakpoint="md"
          horizontal
          label="Autor:"
          for="autor">
          <b-col :md="5">
            <b-input
              id="autor"
              v-model="formData.autor"
              maxlength="100"
              required />
          </b-col>
        </b-form-group>
        <br ><br >

        <b-col
          :md="5"
          offset="4">
          <b-button
            type="submit"
            variant="info">Salvar</b-button>
          <b-button
            :to="{ name: 'LivrosList' }"
            variant="danger">Cancelar</b-button>
        </b-col>
      </b-form>
    </div>
    <b-modal
      ref="alertModal"
      :title="alertModalTitle"
      :ok-only="true"
      @ok="onAlertModalOkClick">
      <p class="my-4">{{ alertModalContent }}</p>
    </b-modal>
  </b-container>
</template>
<script>
import LivrosService from '@/api-services/livros.service'
export default {
  name: 'LivrosCreate',
  data () {
    return {
      formData: {
        nome: '',
        preco: '',
        tipo: '',
        autor: ''
      },
      alertModalTitle: '',
      alertModalContent: '',
      isSuccessfully: false
    }
  },
  methods: {
    createLivros () {
      LivrosService.create(this.formData).then(() => {
        this.isSuccessfully = true
        this.alertModalTitle = 'Sucesso'
        this.alertModalContent = 'Adicionou o livro com sucesso.'
        this.$refs.alertModal.show()

        this.formData = {
          nome: '',
          preco: '',
          tipo: '',
          autor: ''
        }
      }).catch((error) => {
        this.isSuccessfully = false
        this.alertModalTitle = 'Error'
        this.alertModalContent = error.response.data
        this.$refs.alertModal.show()
      })
    },
    onAlertModalOkClick () {
      if (this.isSuccessfully) {
        this.$router.push({ name: 'LivrosList' })
      }
    }
  }
}
</script>
<style>
.form-wrapper {
  margin-top: 20px;
  min-height: 20px;
  padding: 19px;
  margin-bottom: 20px;
  background-color: #f5f5f5;
  border: 1px solid #e3e3e3;
  border-radius: 4px;
  box-shadow: inset 0 1px 1px rgba(0,0,0,.05);
}
</style>
