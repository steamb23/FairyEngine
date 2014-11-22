using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.FairyEngine.Components
{
    public interface IScoreService
    {
        int Rate
        {
            get;
        }
        bool OverFlow
        {
            get;
        }
        decimal ToDecimal
        {
            get;
        }
        void Add(decimal value);
        byte this[int value]
        {
            get;
        }
        int Length
        {
            get;
        }
    }
}
