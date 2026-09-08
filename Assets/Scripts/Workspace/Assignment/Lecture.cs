using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Assignment
{
    public class Lecture : MonoBehaviour
    {
        public void Start()
        {
            // LCT01_SyntaxList();
            // LCT02_SyntaxLinkedList();
            // LCT03_SyntaxHashTable();
            LCT04_SyntaxDictionary();
        }

        #region Lecture

        public void LCT01_SyntaxList()
        {
            //string[] playerName = new string[20];
        }

        public void LCT02_SyntaxLinkedList()
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            // [Node 1]
            linkedList.AddLast("Node 1");
            // [Node 1]<-[Node 2]
            linkedList.AddLast("Node 2");

            // [Node 0]<-[Node 1]<-[Node 2]
            linkedList.AddFirst("Node 0");

            LinkedListNode<string> firstNode = linkedList.First;
            Debug.Log($"First: " + firstNode.Value);

            LinkedListNode<string> lastNode = linkedList.Last;
            Debug.Log($"Last: " + lastNode.Value);

            Debug.Log("FirstNode.Next: " + firstNode.Next.Value);

            Debug.Log("LastNode.Previous: " + lastNode.Previous.Value);
            Debug.Log("LastNode.Previous.Previous: " + lastNode.Previous.Previous.Value);
            Debug.Log("LastNode.Previous.Previous.Previous: " + lastNode.Previous.Previous.Value);
            //FirstNode Previous Error, LastNode Next Error

            // [Node 0]<-<previous>-[Node 1]-<next>->[Node 2]
            // null<-<previous>-[Node 0]<-<next>->[Node 1]
            if (firstNode.Previous == null) Debug.Log("FirstNode.Previous == null");
            if (lastNode.Next == null) Debug.Log("LastNode.Next == null");

            // [Node 0]<-[Node 0.5]<-[Node 1]<-[Node 2]
            linkedList.AddAfter(firstNode, "Node 0.5");

            // [Node 0]<-[Node 0.5]<-[Node 1]<-[Node 1.5]<-[Node 2]
            linkedList.AddBefore(lastNode, "Node 1.5");

            LinkedListNode<string> node1 = linkedList.Find("Node 1");

            linkedList.Remove("Node 1");
            linkedList.Remove(node1);
            linkedList.RemoveLast();
            linkedList.RemoveFirst();

            linkedList.Clear();
        }

        public void LCT03_SyntaxHashTable()
        {
            Hashtable table = new Hashtable();
            table.Add("Potion", 1);
            table.Add(true, "");
            table.Add(0, 0);
            table[true] = 1;
        }

        public void LCT04_SyntaxDictionary()
        {
            Dictionary<string, int> inv = new Dictionary<string, int>();
            var inv2 = new Dictionary<string, int>();

            // "Potion": 1
            inv.Add("Postion", 1);

            // "Potion": 1
            // "Apple": 10
            inv.Add("Apple", 10);

            // "Potion": 1
            // "Apple": 10
            // "Banana": 5
            inv["Banana"] = 5;

            // "Potion": 10
            // "Apple": 10
            // "Banana": 5
            inv["Potion"] = 10;

            var pickupItem = "Sword";
            inv[pickupItem] = 1;

            foreach(KeyValuePair<string, int> pair in inv)
            {
                string key = pair.Key;
                int value = pair.Value;
                Debug.Log($"Key: {key} value: {value}");
            }

            var appleExist = inv.ContainsKey("Apple");
            Debug.Log(appleExist);

            var keyExists = inv.ContainsKey("Key");
            Debug.Log(keyExists);

            inv.Remove("Apple");

            foreach (var pair in inv)
            {
                string key = pair.Key;
                int value = pair.Value;
                Debug.Log($"Key: {key} value: {value}");
            }
        }

        #endregion
    }
}
