using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments.BL
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(string id);

        T Add(T entity);

        bool Remove(T entity);

    }
}
