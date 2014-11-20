using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamB23.FairyEngine.Entities;

namespace SteamB23.FairyEngine.Components
{
    public interface IEntityService
    {
        void Add(Entity entity);
        bool Remove(Entity entity);

    }
}
