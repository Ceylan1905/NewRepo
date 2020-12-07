using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using zeynerp.Entities;

namespace zeynerp.DAL.Repository
{
    public class UserRepository<T> : IRepository<T> where T : class
    {
        UserContext userContext = new UserContext();
        public int Delete(T Obj)
        {
            userContext.Set<T>().Remove(Obj);
            return Save();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return userContext.Set<T>().Where(where).FirstOrDefault();
        }

        public int Insert(T Obj)
        {
            userContext.Set<T>().Add(Obj);

            if (Obj is BaseEntity)
            {
                BaseEntity obj = Obj as BaseEntity;
                DateTime now = DateTime.Now;

                obj.CreatedDate = now;
                obj.ModifiedDate = now;
                obj.ModifiedUser = "System";
            }

            return Save();
        }

        public List<T> List()
        {
            return userContext.Set<T>().ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return userContext.Set<T>().Where(where).ToList();
        }

        public int UpdatePass(string email,  string newPass)
        {
            var user = userContext.Users.FirstOrDefault(x => x.Email == email);
            if(user!=null)
            {
                user.Password = newPass;
                user.Repassword = newPass;
                return Save();
            }

            return 0;
           
        }
        public int Save()
        {
            return userContext.SaveChanges();
        }

        public int Update(T Obj)
        {
            if (Obj is BaseEntity)
            {
                BaseEntity obj = Obj as BaseEntity;

                obj.ModifiedDate = DateTime.Now;
                obj.ModifiedUser = "System";
            }
            return Save();
        }
    }
}
