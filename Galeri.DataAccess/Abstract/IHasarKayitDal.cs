﻿using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.DataAccess.Abstract
{
    public interface IHasarKayitDal:IEntityRepository<HasarKayit>,IFilterMethods<HasarKayit>
    {
    }
}
