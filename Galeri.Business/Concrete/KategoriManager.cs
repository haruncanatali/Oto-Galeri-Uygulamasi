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
    public class KategoriManager:ManagerCollection<Kategori,IKategoriDal,KategoriValidator>,IKategoriService
    {
        public KategoriManager(IKategoriDal x,KategoriValidator y):base(x,y)
        {

        }
    }
}
