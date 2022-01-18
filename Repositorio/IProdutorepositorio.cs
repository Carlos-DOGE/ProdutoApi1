using System.Collections.Generic;
using System.Threading.Tasks;
using ProdutoApi.Models;

namespace ProdutoApi.Repositorio
{
    public interface IProdutoRepositorio
    {
        Task<Produto> get(int id);
        Task<IEnumerable<Produto>> GetAll();
        Task Add(Produto produto);
        Task delete(int id);
        Task Update(Produto produto);
    }
}