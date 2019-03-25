using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   
        public class BaseRepository<T> where T : class
        {
            NewsContext db;

            public BaseRepository(NewsContext FromDb)
            {
                db = FromDb;
            }

            public virtual List<T> BringItAll()
            {
                return db.Set<T>().ToList();
            }
            public virtual T BringOne(int id)
            {
                return db.Set<T>().Find(id);
            }
            public virtual void Add(T newObject)
            {
                db.Set<T>().Add(newObject);
                db.SaveChanges();
            }
            public virtual void Clear(int id)
            {
                var deleted =BringOne(id);
                db.Set<T>().Remove(deleted);
                db.SaveChanges();
            }
            public virtual void Update(IEntity newObject)
             {
                 var old = BringOne(newObject.Id);

                 db.Entry(old).CurrentValues.SetValues(newObject);
                 db.Entry(old).State = EntityState.Modified;
                 db.SaveChanges();
             }
        }
    }
