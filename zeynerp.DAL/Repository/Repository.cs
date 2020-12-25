using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using zeynerp.Entities;

namespace zeynerp.DAL.Repository
{
    public class Repository<T> : Singleton, IRepository<T> where T : class
    {
        private DbSet<T> contextObj;
        public Repository(string db_name) : base(db_name)
        {
            contextObj = databaseContext.Set<T>();
        }
        public int Delete(T Obj)
        {
            contextObj.Remove(Obj);
            return Save();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return contextObj.Where(where).FirstOrDefault();
        }

        public int Insert(T Obj)
        {
            contextObj.Add(Obj);

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

        // SİLİNECEK
        public float GetRemainder()
        {
            List<float> remainders = new List<float>();
            foreach(var item in databaseContext.Remainders)
            {
                remainders.Add(item.remainder);
            }
            return remainders.LastOrDefault();
           
        }

        // SİLİNECEK
        public int UpdatePassword(Employee employee, string newPass)
        {
            employee.Password = newPass;
            employee.Repassword = newPass;
            return Save();

        }

        public int UpdateRemainder(Employee employee,float remainder)
        {
            Remainder _remainder=new Remainder{ 
            remainder=remainder,
            paymentDate=DateTime.Now,
            };
            databaseContext.Remainders.Add(_remainder);
            return databaseContext.SaveChanges() ;

        }
        public List<T> List()
        {
            return contextObj.ToList();
        }
       public  List<T> List(Expression<Func<T, bool>> where)
        {
            return contextObj.Where(where).ToList();
        }

        public List<CompanyAuthorized> GetAuthorized(int id)
        {
            return databaseContext.CompanyAuthorizeds.Where(x => x.CompanyId == id).ToList();
        }
        public int Save()
        {
            return databaseContext.SaveChanges();
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

        public int UpdateCompany(Company Comp)
        { 
            databaseContext.Entry(Comp).State = EntityState.Modified;
            return databaseContext.SaveChanges();
        }
        public int deneme()
        {
            int sonKayit=databaseContext.Companies.Max(x => x.Id);
            return sonKayit;
        }

    }
}
