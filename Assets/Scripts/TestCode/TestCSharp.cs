using System.Collections.Generic;
using UnityEngine;
namespace TestCode
{
    /**
     * 请你设计并实现一个满足 LRU (最近最少使用) 缓存 约束的数据结构。
        实现 LRUCache 类：
        LRUCache(int capacity) 以 正整数 作为容量 capacity 初始化 LRU 缓存
        int get(int key) 如果关键字 key 存在于缓存中，则返回关键字的值，否则返回 -1 。
        void put(int key, int value) 如果关键字 key 已经存在，则变更其数据值 value ；
        如果不存在，则向缓存中插入该组 key-value 。如果插入操作导致关键字数量超过 capacity ，则应该 逐出 最久未使用的关键字。
        函数 get 和 put 必须以 O(1) 的平均时间复杂度运行。
        二、示例
        2.1> 示例：
        【输入】
        ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
        [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
        【输出】
        [null, null, null, 1, null, -1, null, -1, 3, 4]
        【解释】
        LRUCache lRUCache = new LRUCache(2);
        lRUCache.put(1, 1); // 缓存是 {1=1}
        lRUCache.put(2, 2); // 缓存是 {1=1, 2=2}
        lRUCache.get(1); // 返回 1
        lRUCache.put(3, 3); // 该操作会使得关键字 2 作废，缓存是 {1=1, 3=3}
        lRUCache.get(2); // 返回 -1 (未找到)
        lRUCache.put(4, 4); // 该操作会使得关键字 1 作废，缓存是 {4=4, 3=3}
        lRUCache.get(1); // 返回 -1 (未找到)
        lRUCache.get(3); // 返回 3
        lRUCache.get(4); // 返回 4
     */
    public class LRUTest
    {
        LRUCache lRUCache = new LRUCache(2);
        public void Test()
        {
            lRUCache.put(1, 1); // 缓存是 {1=1}
            lRUCache.put(2, 2); // 缓存是 {1=1, 2=2}
            lRUCache.get(1); // 返回 1
            lRUCache.put(3, 3); // 该操作会使得关键字 2 作废，缓存是 {1=1, 3=3}
            lRUCache.get(2); // 返回 -1 (未找到)
            lRUCache.put(4, 4); // 该操作会使得关键字 1 作废，缓存是 {4=4, 3=3}
            lRUCache.get(1); // 返回 -1 (未找到)
            lRUCache.get(3); // 返回 3
            lRUCache.get(4); // 返回 4
        }
    }

    public class LRUCache
    {
        private int capacity = 0;
        private Dictionary<int, LinkedListNode<(int key, int value)>> dic = new Dictionary<int, LinkedListNode<(int key, int value)>>();
        

        private LinkedList<(int key, int value)> list = new LinkedList<(int key, int value)>();
        
        
        public LRUCache(int _capacity)
        {
            capacity = _capacity;
            Debug.Log("null");
        }
        public int get(int key)
        {
            if (dic.ContainsKey(key))
            {
                LinkedListNode<(int key, int value)> node = dic[key];
                Debug.Log("" + node.Value.value);
                
                list.Remove(node);
                list.AddFirst(node);
                return node.Value.value;
            }
            else
            {
                Debug.Log("-1");
                return -1;
            }
        }

        public void put(int key, int value)
        {
            
            if (dic.ContainsKey(key))
            {
                // 更新值
                LinkedListNode<(int key, int value)> node = dic[key];
                list.Remove(node);
                list.AddFirst(node);
                node.Value = (key, value);
            }
            else
            {
                if (dic.Count >= capacity)
                {
                    
                    LinkedListNode<(int key, int value)> last = list.Last;
                    dic.Remove(last.Value.key);
                    list.RemoveLast();
                    
                }
                dic.Add(key, list.AddFirst((key, value)));
            }
            Debug.Log("null");
        }
    }
}
