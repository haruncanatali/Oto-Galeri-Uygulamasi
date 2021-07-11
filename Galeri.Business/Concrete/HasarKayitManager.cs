using Galeri.Business.Abstract;
using Galeri.Business.ValidationTool;
using Galeri.DataAccess.Abstract;
using Galeri.DataAccess.Concrete;
using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Business.Concrete
{
    public class HasarKayitManager:ManagerCollection<HasarKayit,IHasarKayitDal,HasarKayitValidator>,IHasarKayitService
    {
        public HasarKayitManager(IHasarKayitDal x,HasarKayitValidator y):base(x,y)
        {

        }
    }
}
