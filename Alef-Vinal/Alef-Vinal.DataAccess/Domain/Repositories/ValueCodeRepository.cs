using System.Linq;
using Alef_Vinal.DataAccess.Domain.Entities;
using Alef_Vinal.DataAccess.Domain.Interfaces;

namespace Alef_Vinal.DataAccess.Domain.Repositories
{
    public class ValueCodeRepository : IRepository<ValueCode, int>
    {
        private readonly Alef_VinalContext context;

        public ValueCodeRepository(Alef_VinalContext context)
        {
            this.context = context;
        }

        public IQueryable<ValueCode> GetAll()
        {
            return context.Codes;
        }

        public ValueCode Get(int id)
        {
            var code = context.Codes.FirstOrDefault(c => c.Id == id);

            return code;
        }

        public void Create(ValueCode code)
        {
            context.Codes.Add(code);
        }

        public void Update(ValueCode code)
        {
            context.Update(code);
        }

        public bool CodeExists(int id)
        {
            return context.Codes.Any(c => c.Id == id);
        }

        public ValueCode GetByCode(int code)
        {
            var codeR = context.Codes.FirstOrDefault(c => c.Code == code);

            return codeR;
        }
    }
}
