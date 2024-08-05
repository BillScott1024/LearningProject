using UnityEngine;
using XLua;
namespace TestCode
{
    public class XluaCode: MonoBehaviour
    {
        public void Init()
        {
            XLua.LuaEnv luaenv = new XLua.LuaEnv();
            luaenv.DoString("CS.UnityEngine.Debug.LogWarning('hello world')");
            // luaenv.Dispose();
            
            TextAsset lua = Resources.Load<TextAsset>("Lua/HotFix/HotFix.lua");
            luaenv.DoString(lua.ToString());
        }
        
    }

    [Hotfix]
    public class HotFixCode : MonoBehaviour
    {
        public void RunCSharpCode()
        {
            Debug.LogWarning("执行CS方法 RunCSharpCode");
        }

        public void RunLuaCode()
        {
            Debug.LogWarning("执行Lua方法 RunLuaCode");
        }
        
        /// <summary>
        /// Lua调用C#
        /// </summary>
        public void LuaCallCSharp()
        {
            Debug.LogWarning("我是被Lua调用的C#的方法");
        }

        
    }
    
    
    
}
