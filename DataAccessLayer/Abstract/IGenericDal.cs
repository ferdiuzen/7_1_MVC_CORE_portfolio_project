using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class //Class larda generik kullanımda T yerine class ismi yazılır T gördüğü yerde klass okunur
    {
        void Insert(T t);//p yi about için referans olarak tanımladık
        void Update(T t);//T class ismi yerine generiktir , t referans yerine
        void Delete(T t);
        List<T> GetList();
        T GetByID(int id);
    }
}
