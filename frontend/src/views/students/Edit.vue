<template>
  <v-container fluid>
    <v-form>
      <v-row>
        <v-col>
          <v-subheader>Nome</v-subheader>
        </v-col>
        <v-col cols="9">
          <v-text-field outlined v-model="student.name"></v-text-field>
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <v-subheader>E-mail</v-subheader>
        </v-col>
        <v-col cols="9">
          <v-text-field outlined v-model="student.email"></v-text-field>
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <v-subheader>RA</v-subheader>
        </v-col>
        <v-col cols="9">
          <v-text-field disabled outlined v-model="student.id"></v-text-field>
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <v-subheader>CPF</v-subheader>
        </v-col>
        <v-col cols="9">
          <v-text-field v-if="id>=0" disabled outlined v-model="student.cpf"></v-text-field>
          <v-text-field v-else outlined v-mask="'###.###.###-##'" v-model="student.cpf"></v-text-field>
        </v-col>
      </v-row>
      <v-row>
        <v-col align="end">
          <v-btn to="/" class="grey lighten-2">
            Cancelar
          </v-btn>
          <v-btn @click="onCreate" class="grey">
            Salvar
          </v-btn>
        </v-col>
      </v-row>
    </v-form>
  </v-container>
</template>
<script>
  import Student from '../../services/students'
  import {mask} from 'vue-the-mask'

  export default{
    directives: {mask},
    data(){
      return {
        id: -1,
        student: {
          name: '',
          email: '',
          id: '',
          cpf: ''
        }
      };
    },
    methods:{
      onCreate(){
        Student.create(this.student).then(response =>{
          console.log(response)
          alert('Salvo com sucesso!')
          this.$router.push('/') 
        })
        .catch(error => {
          console.log(error)
          alert('Erro ao salvar!')          
        })
      }
    },
    mounted(){
      this.id = this.$route.query.id
      if (this.id>=0){
        Student.get(this.id).then(response => {
          console.log(response)
          this.student = response.data
        })
      }
    }
  }
</script>
