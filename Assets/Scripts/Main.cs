
using TestCode;
using Unity.VisualScripting;
using UnityEngine;

public class Main : MonoBehaviour
{

    private GameObject player = null;
    private GameObject xluaGO = null;

    // Start is called before the first frame update
    void Start()
    {
       Debug.LogWarning("Start");
       Init();
    }

    private void Init()
    {

        // TestCoroutine();
        TestXlua();
    }

    private void TestXlua()
    {
        xluaGO = GameObject.Find("DontDestroyRoot/XLua");
        var component = xluaGO.GetOrAddComponent<XluaCode>();
        component.Init();
        
        var luaComp = xluaGO.GetOrAddComponent<HotFixCode>();
        luaComp.RunCSharpCode();
        luaComp.RunLuaCode();
        
    }

    private void TestCoroutine()
    {
        player = GameObject.Find("DontDestroyRoot/Player");
        var component = player.GetOrAddComponent<CSCoroutine>();
        component.Init();
        component.StartCorou();
    }
    // Update is called once per frame
    void Update()
    {
        
            // Debug.LogWarning("Update "+printCount);
        
    }

    private void LateUpdate()
    {
            // Debug.LogWarning("LateUpdate "+printLateCount);
    }
}
