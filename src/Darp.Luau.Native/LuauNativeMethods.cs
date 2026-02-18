using System.Runtime.InteropServices;

namespace Darp.Luau.Native;

static unsafe partial class LuauNative
{
    /// <seealso href="https://learn.microsoft.com/en-us/dotnet/standard/native-interop/exceptions-interoperability"/>
    [Obsolete("Do not use lua_error from managed code. The dotnet clr does not support longjmp!")]
    [DllImport(__DllName, EntryPoint = "lua_error", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void lua_error(lua_State* L);
}
