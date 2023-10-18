using ControleContatos.Data.Configuration;
using ControleContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();

        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            var buscaContato = ListarPorId(contato.Id);
            if(buscaContato == null)
            {
                throw new Exception("Houve um erro na atualização do contato");
            }

            buscaContato.Nome = contato.Nome;
            buscaContato.Email = contato.Celular;
            buscaContato.Celular = contato.Celular;

            _bancoContext.Contatos.Update(buscaContato);
            _bancoContext.SaveChanges();
            return buscaContato;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarPorId(id);
            if (contatoDb == null)
            {
                throw new Exception("Houve um erro na atualização do contato");
            }

            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}