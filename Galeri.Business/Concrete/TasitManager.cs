using Galeri.Business.Abstract;
using Galeri.Business.ValidationTool;
using Galeri.DataAccess.Abstract;
using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Business.Concrete
{
    public class TasitManager:ManagerCollection<Tasit,ITasitDal,TasitValidator>,ITasitService
    {
        public TasitManager(ITasitDal x,TasitValidator y):base(x,y)
        {

        }
    }
}
