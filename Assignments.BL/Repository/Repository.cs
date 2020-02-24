using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignments.BL
{
    public class Repository<TT> : IRepository<TT> where TT: Entity
    {
        private List<TT> data = new List<TT>();
        public TT Add(TT entity)
        {
            if (!data.Contains(entity))
            {
                data.Add(entity);
                return entity;
            }
            return null;
        }
        
        public bool Remove(TT entity)
        {
            if (data.Contains(entity))
            {
                data.Remove(entity);
                return true;
            }
            return false;
        }

        public TT GetById(string id)
        {
            return data.FirstOrDefault(item => item.ID.ToLower() == id.Trim().ToLower());
        }
    }
}
