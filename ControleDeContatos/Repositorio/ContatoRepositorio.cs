using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public void Editar(ContatoModel contato)
        {
            try
            {
                _bancoContext.Contatos.Update(contato);
                _bancoContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new System.Exception("Erro ao editar contato!");
            }
        }

        public bool Apagar(int id)
        {
            ContatoModel contato = _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);

            try
            {
                _bancoContext.Contatos.Remove(contato);
                _bancoContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
    }
}
