using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchMaker.Core.Interfaces.Repository;
using MatchMaker.Infrastructure.Repository;
using Ninject.Modules;

namespace MatchMaker.Infrastructure.DependencyInjection
{
    class ITouchMatchMakerModule : NinjectModule
    {
        public override void Load()
        {
            //TO DO BINDINGS..
            //Bind<ICasaDeLasBateriasRepository>().To<CasaDeLasBateriasRepository>();
            //Bind<IEmailService>().To<EmailService>();
            Bind<ITouchRepository>().To<TouchRepository>();
        }
    }
}
