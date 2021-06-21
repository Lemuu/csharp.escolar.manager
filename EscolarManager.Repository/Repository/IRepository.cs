using System.Collections.Generic;

namespace EscolarManager.Repository
{
    interface IRepository<T>
    {
        public bool Table();
        public bool Insert(T data);
        public void Update(T data);
        public List<T> FindAll();
        public bool Delete(T data);
    }
}
