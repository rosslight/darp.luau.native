using Darp.Luau.Native;
using static Darp.Luau.Native.LuauNative;

unsafe
{
    var state = luaL_newstate();
    try
    {
        lua_pushinteger(state, 123);
        fixed(byte* pName = "name"u8)
            lua_setfield(state, LUA_GLOBALSINDEX, pName);

        fixed (byte* pName = "name"u8)
            _ = lua_getfield(state, LUA_GLOBALSINDEX, pName);
        var type = (lua_Type)lua_type(state, -1);
        ArgumentOutOfRangeException.ThrowIfNotEqual(type, lua_Type.LUA_TNUMBER);
    }
    finally
    {
        lua_close(state);
    }
    Console.WriteLine("Darp.Luau.Native integration sequence passed.");

    // Verify compile + free round-trip
    var source = "return 1"u8;
    fixed (byte* pSource = source)
    {
        nuint bytecodeSize;
        var bytecode = luau_compile(pSource, (nuint)source.Length, null, &bytecodeSize);
        try
        {
            ArgumentOutOfRangeException.ThrowIfEqual(bytecodeSize, (nuint)0);
            ArgumentNullException.ThrowIfNull(bytecode);
        }
        finally
        {
            luau_free(bytecode);
        }
    }
    Console.WriteLine("Darp.Luau.Native compile/free sequence passed.");
}
