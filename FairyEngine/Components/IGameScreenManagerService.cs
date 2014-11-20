using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamB23.FairyEngine.Graphics;

namespace SteamB23.FairyEngine.Components
{
    public interface IGameScreenService
    {
        void Add(GameSprite gameSprite);
        void Add(GameSprite gameSprite, LayerType layerType);
        bool Remove(GameSprite gameSprite);
        void Clear();
    }
}
