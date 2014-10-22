using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SteamB23.FairyEngine.Entities;


namespace SteamB23.FairyEngine.Components
{
    public class EntityManager:GameComponent,ICollection<Entity>
    {
        List<Entity> entities = new List<Entity>();
        
        public EntityManager(Game game) : base(game)
        {
        }
        #region ICollection 구현
        public void Add(Entity item)
        {
            entities.Add(item);
            Game.Components.Add(item);
        }
        public bool Remove(Entity item)
        {
            entities.Remove(item);
            return Game.Components.Remove(item);
        }


        public void Clear()
        {
            foreach (var temp in entities)
            {
                Game.Components.Remove(temp);
            }
            entities.Clear();
        }

        public bool Contains(Entity item)
        {
            return entities.Contains(item);
        }

        public void CopyTo(Entity[] array, int arrayIndex)
        {
            entities.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                return entities.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public IEnumerator<Entity> GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return entities.GetEnumerator();
        }
        #endregion
    }
}
