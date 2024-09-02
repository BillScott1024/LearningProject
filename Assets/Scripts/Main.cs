
using TestCode;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Main : MonoBehaviour
{

    private GameObject player = null;
    private GameObject xluaGO = null;

    [SerializeField] TMP_Text text = null;

    struct MyStruct
    {
        public int num;
    }
    // Start is called before the first frame update
    void Start()
    {
       Debug.LogWarning("Start");

       text.text = "hello!!!";
       Init();
    }

    private void Init()
    {

        // TestCoroutine();
        // TestXlua();
        
        LRUTest testCSharp = new LRUTest();
        testCSharp.Test();
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
