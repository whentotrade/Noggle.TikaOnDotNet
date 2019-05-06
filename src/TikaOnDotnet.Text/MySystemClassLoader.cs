using ikvm.runtime;
using java.lang;

namespace Noggle.TikaOnDotNet.Text
{
    public class MySystemClassLoader : ClassLoader
    {
        public MySystemClassLoader(ClassLoader parent)
            : base(new AppDomainAssemblyClassLoader(typeof(MySystemClassLoader).Assembly))
        {
        }
    }
}
