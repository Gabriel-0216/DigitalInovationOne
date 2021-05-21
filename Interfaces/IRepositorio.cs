using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series
{
    public interface IRepositorio<T>
    {

        List<T> lista();

        T retornaPorId(int id);

        void Inserir(T entidade);

        void Excluir(int id);

        void Atualiza(int id, T entidade);

        int ProximoId();


    }
}
