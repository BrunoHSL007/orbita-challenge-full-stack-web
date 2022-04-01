<template>
  <div>
    <v-container>
      <v-row>
        <v-col>
          <v-text-field
            label="Digite sua busca"
            outlined
          v-model="phrase"></v-text-field>
        </v-col>
        <v-col>
          <v-btn @click="searchItems"><v-icon>mdi-magnify</v-icon></v-btn>          
        </v-col>
        <v-col><v-btn to="/edit-student">Cadastrar</v-btn></v-col>        
      </v-row>
    </v-container>
    <v-container
      class="grey lighten-1"
    >
      <v-row
        align="center"
        no-gutters
      >
        <v-col align="center">
          Registro Acadêmico
        </v-col>
        <v-col align="center">
          Nome
        </v-col>
        <v-col align="center">
          CPF
        </v-col>
        <v-col align="center">
          Ações
        </v-col>
      </v-row>
    </v-container>

    <v-divider class="grey"></v-divider>

    <v-list two-line>
      <v-list-item-group>
        <template v-for="(student, index) in students">
          <v-list-item :key="student.id">
            <v-row align="center">
              <v-col align="center">
                <v-list-item-content>
                  <v-list-item-title v-text="student.id"></v-list-item-title>
                </v-list-item-content>
              </v-col>

              <v-col align="center">
                <v-list-item-content>
                  <v-list-item-title v-text="student.name"></v-list-item-title>
                </v-list-item-content>
              </v-col>

              <v-col align="center">
                <v-list-item-content>
                  <v-list-item-title v-text="student.cpf"></v-list-item-title>
                </v-list-item-content>
              </v-col>

              <v-col>
                <v-list-item-content>
                  
                  <v-btn :to="'/edit-student?id='+student.id" icon color="grey lighten-1">
                    <v-icon>mdi-pencil</v-icon>
                  </v-btn>

                  <v-btn @click="onDelete(student.id)" icon color="red lighten-2">
                    <v-icon>mdi-delete</v-icon>
                  </v-btn>

                </v-list-item-content>
              </v-col>
            </v-row>
          </v-list-item>

          <v-divider
            v-if="index < student.length"
            :key="index"
          ></v-divider>
        </template>
      </v-list-item-group>
    </v-list>

  </div>
</template>
<script>
  import Student from '../../services/students'

  export default {
    name: 'Home',

    components: {
    },

    data(){
      return {
        phrase : '',
        students: []
      };
    },
    methods: {
      searchItems() {
          Student.list(this.phrase).then(response =>{
          this.students = response.data
          console.log(response.data)
        })
      },
      onDelete(id) {
        if (confirm("Você deseja remover o produto?")){
          Student.delete(id).then(response =>{
            console.log(response)
            alert('Removido com sucesso!')
            this.searchItems()
          })
          .catch(error => {
            console.log(error)
            alert('Erro ao remover!')          
          })
        }
      }
    },
    mounted(){
      Student.list(this.phrase).then(response =>{
          console.log(response.data)
          this.students = response.data
        })
    }
  }
</script>
