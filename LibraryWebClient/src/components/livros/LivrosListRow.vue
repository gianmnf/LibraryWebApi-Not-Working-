<template>
  <tr>
    <td>{{ livros.nome }}</td>
    <td>{{ livros.preco }}</td>
    <td>{{ livros.tipo }}</td>
    <td>{{ livros.autor }}</td>
    <td>
      <b-button variant="light"
      @click="onDetailsClick">Detalhes</b-button>
    </td>
    <td>
      <b-button variant="success"
      @click="onUpdateClick">Atualizar</b-button>
    </td>
    <td>
      <b-button variant="danger"
      @click="onDeleteClick">Remover</b-button>
    </td>
  </tr>
</template>
<script>
export default {
  name: 'LivrosListRow',
  props: ['livros'],
  methods: {
    onDetailsClick () {
      this.$emit('details', this.livros.id)
    },
    onUpdateClick () {
      this.$emit('update', this.livros.id)
    },
    onDeleteClick () {
      this.$emit('delete', this.livros.id)
    }
  }
}
</script>
