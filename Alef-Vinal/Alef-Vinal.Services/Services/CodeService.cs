using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alef_Vinal.DataAccess.Domain.Entities;
using Alef_Vinal.DataAccess.Domain.Interfaces;
using Alef_Vinal.Services.DTOs;
using Alef_Vinal.Services.Services.Interfaces;
using Alef_Vinal.Services.Validation;
using Microsoft.AspNetCore.JsonPatch;

namespace Alef_Vinal.Services.Services
{
    public class CodeService : ICodeService
    {
        private readonly IUnitOfWork uow;
        private readonly MapperService mapper;
        private readonly ValueCodeValidator validator;

        public CodeService(IUnitOfWork uow)
        {
            this.uow = uow;
            mapper = new MapperService();
            validator = new ValueCodeValidator();
        }

        public void Create(ValueCodeDto valueCodeDto)
        {
            if (!validator.Validate(valueCodeDto).IsValid)
            {
                throw new ArgumentException(validator.Validate(valueCodeDto).Errors.First().ErrorMessage);
            }

            var code = mapper.Map<ValueCodeDto, ValueCode>(valueCodeDto);
            uow.ValueCode.Create(code);
            uow.Save();
        }

        public ValueCodeDto Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "id should be greater than zero");
            }

            var code = uow.ValueCode.Get(id);
            return mapper.Map<ValueCode, ValueCodeDto>(code);
        }

        public ValueCodeDto GetByCode(int code)
        {
            if (code <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(code), "code should be greater than zero");
            }

            var codeR = uow.ValueCode.GetByCode(code);
            return mapper.Map<ValueCode, ValueCodeDto>(codeR);
        }

        public IEnumerable<ValueCodeDto> GetAll()
        {
            var codes = uow.ValueCode.GetAll();

            return mapper.Map<IQueryable<ValueCode>, IEnumerable<ValueCodeDto>>(codes).ToList();
        }

        public void Update(int id, JsonPatchDocument<ValueCodeDto> valueCodePatch)
        {
            var codeOrigin = uow.ValueCode.Get(id);

            var codeDto = mapper.Map<ValueCode, ValueCodeDto>(codeOrigin);

            valueCodePatch.ApplyTo(codeDto);

            mapper.Map(codeDto, codeOrigin);

            uow.ValueCode.Update(codeOrigin);
            uow.Save();
        }
    }
}
