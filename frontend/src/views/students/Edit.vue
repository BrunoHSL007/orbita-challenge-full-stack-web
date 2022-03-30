<template>
  <v-container fluid>
    <v-form @submit.prevent="create">
      <v-row>
        <v-col>
          <v-subheader>Nome</v-subheader>
        </v-col>
        <v-col cols="9">
          <v-text-field outlined v-model="name"></v-text-field>
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <v-subheader>E-mail</v-subheader>
        </v-col>
        <v-col cols="9">
          <v-text-field outlined v-model="email"></v-text-field>
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <v-subheader>RA</v-subheader>
        </v-col>
        <v-col cols="9">
          <v-text-field outlined v-model="id"></v-text-field>
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <v-subheader>CPF</v-subheader>
        </v-col>
        <v-col cols="9">
          <v-text-field outlined v-model="cpf"></v-text-field>
        </v-col>
      </v-row>
      <v-row>
        <v-col align="end">
          <v-btn to="/" class="grey lighten-2">
            Cancelar
          </v-btn>
          <v-btn class="grey">
            Salvar
          </v-btn>
        </v-col>
      </v-row>
    </v-form>
  </v-container>
</template>
<script>
  import Student from '../../services/students'
  export default{
    methods:{
      create(){
        Student.create(this.student).then(response =>{
          alert('Salvo com sucesso')
          console.log(response)
        })
      }
    }
  }
</script>
