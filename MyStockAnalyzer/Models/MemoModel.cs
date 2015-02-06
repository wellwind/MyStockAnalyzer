using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockAnalyzer.Models
{
    public class MemoModel
    {
        StockEntities _db;
        public MemoModel()
        {
            _db = new StockEntities();
        }

        public string GetMemo()
        {
            var qry = from m in _db.Memo select m.MemoText;
            if (qry.Count() > 0)
            {
                return qry.First();
            }
            else
            {
                return String.Empty;
            }
        }

        public void SaveMemo(string memoText)
        {
            var qry = from m in _db.Memo select m;
            if (qry.Count() > 0)
            {
                Memo m = qry.First();
                m.MemoText = memoText;
                _db.Entry(m).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                Memo m = new Memo();
                m.MemoText = memoText;
                _db.Memo.Add(m);
                _db.Entry(m).State = System.Data.Entity.EntityState.Added;
            }
            _db.SaveChanges();
        }
    }
}
