using Autofac;
using AzureFunctions.Autofac.Configuration;
using CheckDigitAlg;
using CheckDigitAlg.Impl;

namespace CheckDigitFunction
{
    public class DIConfig
    {
        public DIConfig()
        {
            DependencyInjection.Initialize(cfg => { cfg.RegisterType<Mod97>().As<ICheckDigitAlgorithm>(); });
        }
    }
}