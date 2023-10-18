using ControleContatos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);

        List<ContatoModel> BuscarTodos();

        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}