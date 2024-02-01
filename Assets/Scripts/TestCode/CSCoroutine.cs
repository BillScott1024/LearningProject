using System.Collections;
using UnityEngine;
namespace TestCode
{
    /// <summary>
    /// 协程
    /// </summary>
    public class CSCoroutine: MonoBehaviour
    {
        
        public int count = 20;
        private int printCount;
        private int printLateCount;
        private Coroutine coroutineFlag;
        
        public void Init()
        {
            Debug.LogWarning("Init");
        }

        public void StartCorou()
        {
            coroutineFlag =  StartCoroutine(myCoroutine());
        }
        
        public void SopCorou(Coroutine coroutine)
        {
            if (coroutineFlag == null)
            {
                return;
            }
            StopCoroutine(coroutineFlag);
        }
        
        private IEnumerator myCoroutine()
        {
            for (int i = 0; i < 5; i++)
            {
                Debug.LogWarning("index: " + i);
                yield return new WaitForSeconds(.5f);
            }

            Debug.LogWarning("Wait for 2s");

            yield return new WaitForSeconds(2f);

            for (int i = 6; i < 10; i++)
            {
                Debug.LogWarning("index: " + i);
                yield return new WaitForSeconds(1f);
            }
            SopCorou(coroutineFlag);
        }
    }
    
}
