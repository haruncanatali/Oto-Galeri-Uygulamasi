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
    public class YorumManager:ManagerCollection<Yorum,IYorumDal,YorumValidator>,IYorumService
    {
        public YorumManager(IYorumDal x,YorumValidator y):base(x,y)
        {

        }
    }
}
