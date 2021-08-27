using System;
using System.Collections.Generic;

namespace CRUD
{
    public class Repositorio : Cadastro<Pessoas>
    {
        private List<Pessoas> Listagem = new List<Pessoas>();
        public void Atualizar(int id, Pessoas entidade)
        {
            Listagem[id] = entidade;
        }
        public void Excluir(int id)
        {
            Listagem[id].Exclui();
        }

        public void Inserir(Pessoas entidade)
        {
            Listagem.Add(entidade);
        }

        public List<Pessoas> lista()
        {
            return Listagem;
        }

        public int ProximoId()
        {
            return Listagem.Count;
        }

        public Pessoas RetornoId(int id)
        {
            return Listagem[id];
        }
    }
}