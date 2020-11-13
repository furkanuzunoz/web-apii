using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programind.dal
{
   public  class TableDal
    {
        dbEntities db = new dbEntities();

        public IEnumerable<Table_1> GETalltable()
        {
            return db.Table_1;

        }
        public Table_1 gettablebyid(int id)
        {
            return db.Table_1.Find(id);

        }
        public Table_1 createtable (Table_1 table)
        {
            db.Table_1.Add(table);
            db.SaveChanges();

            return table;
        }
        public Table_1 updatetable(int id , Table_1 table)
        {
            db.Entry(table).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return table;

        }
        public void delete(int id)
        {
            db.Table_1.Remove(db.Table_1.Find(id));
            db.SaveChanges(); 
           

        }
        public bool kayitvarmi (int id)
        {

            return db.Table_1.Any(x => x.id == id);
        }
    }
}
