using System.Collections.Generic;

namespace Rumo.Resharper.QuickActions
{
    static class Constants
    {
        public string Foo { get; set; }

        public class Languages
        {
            public const string CSharp = "C#";
        }
    }
}


namespace Test
{
    public static class Foo
    {
        static Dictionary<string, object> Locks { get; } = new Dictionary<string, object>();
        static Dictionary<string, object> Locks2 { get; } = new Dictionary<string, object>();

        public static object GetLock(string name)
        {
            return Locks[name];
        }

        public static object GetLock2(string name)
        {
            return Locks2[name];
        }
    }

    public static class Foo2
    {
        static Dictionary<string, object> Locks { get; } = new Dictionary<string, object>();
        static Dictionary<string, object> Locks2 { get; } = new Dictionary<string, object>();

        public static object GetLock(string name)
        {
            return Locks[name];
        }

        public static object GetLock2(string name)
        {
            return Locks2[name];
        }
    }


























}






















}