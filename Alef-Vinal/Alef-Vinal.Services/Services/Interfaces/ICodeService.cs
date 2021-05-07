using System;
using System.Collections.Generic;
using System.Text;
using Alef_Vinal.Services.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace Alef_Vinal.Services.Services.Interfaces
{
    public interface ICodeService
    {
        public IEnumerable<ValueCodeDto> GetAll();
        public ValueCodeDto Get(int id);
        public ValueCodeDto GetByCode(int code);

        public void Create(ValueCodeDto valueCodeDto);

        public void Update(int id, JsonPatchDocument<ValueCodeDto> valueCodePatch);
    }
}
