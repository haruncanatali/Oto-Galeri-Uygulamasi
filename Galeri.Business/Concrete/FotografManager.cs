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
    public class FotografManager:ManagerCollection<Fotograf,IFotografDal,FotografValidator>,IFotografService
    {
        public FotografManager(IFotografDal x,FotografValidator y):base(x,y)
        {

        }
    }
}
