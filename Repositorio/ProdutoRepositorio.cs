using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProdutoApi.Data;
using ProdutoApi.Models;

namespace ProdutoApi.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly IDatacontext _context;
        public ProdutoRepositorio(IDatacontext context)
        {
            _context = context;

        }
        public async Task Add(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }
        public async Task delete(int id)
        {
            var DeletarItem = await _context.Produtos.FindAsync(id);
            if(DeletarItem == null)
                throw new NullReferenceException();

            _context.Produtos.Remove(DeletarItem);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> get(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task Update(Produto produto)
        {
            var UpdateItem = await _context.Produtos.FindAsync(produto.Id);
            if (UpdateItem == null)
                throw new NullReferenceException();
            UpdateItem.context = produto.context;
            UpdateItem.unitPrice = produto.unitPrice;
            await _context.SaveChangesAsync();
        }
    }
}