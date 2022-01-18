using ProdutoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProdutoApi.Data;
using System.Threading.Tasks;
using System;
using ProdutoApi.Repositorio;

namespace ProdutoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutosController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _produtoRepositorio.get(id);
            if(produto == null)
                return NotFound();
            
            return Ok(produto);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            var produtos = await _produtoRepositorio.GetAll();
            return Ok(produtos);            
        }

        [HttpPost]
        public async Task<ActionResult> CriarProduto(Produto produto)
        {
            Produto produtos = new()
            {
                productCode = produto.productCode,
                context = produto.context,
                unitPrice = produto.unitPrice,
                priceList = produto.priceList
            };
            await _produtoRepositorio.Add(produtos);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeletarProduto(int id)
        {
            await _produtoRepositorio.delete(id);
            return Ok();
        }
    }   
}