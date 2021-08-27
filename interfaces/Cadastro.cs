using System.Collections.Generic;

namespace CRUD
{
    public interface Cadastro<T>
    {
        List<T> lista();
        T RetornoId(int id);
        void Inserir(T entidade);
        void Excluir(int id);
        void Atualizar(int id, T entidade);
        int ProximoId();
    }
}