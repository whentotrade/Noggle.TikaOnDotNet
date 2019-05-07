using ikvm.runtime;
using java.lang;

namespace Noggle.TikaOnDotNet.Parser
{
    public class MySystemClassLoader : ClassLoader
    {
        public MySystemClassLoader(ClassLoader parent)
            : base(new AppDomainAssemblyClassLoader(typeof(MySystemClassLoader).Assembly))
        {
        }
    }
}
