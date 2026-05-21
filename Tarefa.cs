using System;

namespace PROJETO_POO_CRUD.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string TextoTarefa { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Concluida { get; set; }
    }
}