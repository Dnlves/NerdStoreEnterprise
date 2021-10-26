using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Pedidos.Domain.Vouchers;

namespace NSE.Pedidos.Infra.Data.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PedidosContext _context;

        public VoucherRepository(PedidosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();


        public async Task<Voucher> ObterVoucherPorCodigo(string codigo)
        {
            return await _context.Vouchers.FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}