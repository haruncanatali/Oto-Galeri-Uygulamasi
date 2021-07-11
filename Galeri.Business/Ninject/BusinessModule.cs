using Galeri.Business.Abstract;
using Galeri.Business.Concrete;
using Galeri.DataAccess.Abstract;
using Galeri.DataAccess.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Business.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHasarKayitService>().To<HasarKayitManager>().InSingletonScope();
            Bind<IHasarKayitDal>().To<HasarKayitDal>().InSingletonScope();

            Bind<IKategoriService>().To<KategoriManager>().InTransientScope();
            Bind<IKategoriDal>().To<KategoriDal>().InTransientScope();

            Bind<IMarkaService>().To<MarkaManager>().InTransientScope();
            Bind<IMarkaDal>().To<MarkaDal>().InTransientScope();

            Bind<IModelService>().To<ModelManager>().InTransientScope();
            Bind<IModelDal>().To<ModelDal>().InTransientScope();

            Bind<ITasitService>().To<TasitManager>().InTransientScope();
            Bind<ITasitDal>().To<TasitDal>().InTransientScope();

            Bind<IFotografService>().To<FotografManager>().InTransientScope();
            Bind<IFotografDal>().To<FotografDal>().InTransientScope();

            Bind<IYorumService>().To<YorumManager>().InTransientScope();
            Bind<IYorumDal>().To<YorumDal>().InTransientScope();
        }
    }
}
