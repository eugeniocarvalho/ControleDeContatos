using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);
        bool Apagar(int id);
        List<ContatoModel> BuscarTodos();
        void Editar(ContatoModel contato);
        ContatoModel ListarPorId(int id);
    }
}
