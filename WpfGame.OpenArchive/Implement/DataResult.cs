using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WpfGame.OpenArchive.Implement
{
  public  class DataResult<TEntity> : IDataResult<TEntity>
    {
        public TEntity Data
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public bool Success
        {
            get;
            set;
        }
    }
}
