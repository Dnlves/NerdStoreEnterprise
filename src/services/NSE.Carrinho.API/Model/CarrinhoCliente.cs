using System;
using System.Collections.Generic;

namespace NSE.Carrinho.API.Model
{
    public class CarrinhoCliente
    {

        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public List<CarrinhoItem> Itens { get; set; } = new List<CarrinhoItem>();
        

        public CarrinhoCliente(Guid id, Guid clienteId)
        {
            Id = id;
            ClienteId = clienteId;
        }
        
        public CarrinhoCliente()
        {
            
        }
          
    }
}