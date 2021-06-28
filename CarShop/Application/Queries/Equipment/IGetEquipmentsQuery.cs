using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Equipment
{
    public interface IGetEquipmentsQuery : IQuery<EquipmentSearch,EquipmentDto>
    {
    }
}
