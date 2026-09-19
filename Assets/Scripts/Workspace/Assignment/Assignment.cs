using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            //AS01_CountWords();
            //AS02_CountNumber();
            //AS03_CheckValidBrackets();
            //AS04_PrintReverseLinkedList();
            //AS05_FindMiddleElement();
            //AS06_MergeDictionaries();
            //AS07_RemoveDuplicatesFromLinkedList();
            //AS08_TopFrequentNumber();
            //AS09_PlayerInventory();
            //AS10_GameEventQueue();
            //AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            Dictionary<string,int> wordCountDic = new Dictionary<string,int>();
            foreach (string key in words)
            {
                if (wordCountDic.ContainsKey(key))
                {
                    wordCountDic[key] += 1;
                }
                else
                {
                    wordCountDic.Add(key, 1);
                }
            }

            foreach (KeyValuePair<string, int> kvp in wordCountDic)
            {
                Debug.Log($"Word: '{kvp.Key}' count: {kvp.Value}");
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            Dictionary<int, int> numCountDic = new Dictionary<int, int>();
            foreach (int _key in numbers)
            {
                if (numCountDic.ContainsKey(_key))
                {
                    numCountDic[_key] += 1;
                }
                else
                {
                    numCountDic.Add(_key, 1);
                }
            }

            foreach (KeyValuePair<int, int> kvp in numCountDic)
            {
                Debug.Log($"Number: '{kvp.Key}' count: {kvp.Value}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            Dictionary<char, char> bracketPair = new Dictionary<char, char>();
            bracketPair.Add( '(', ')' );
            bracketPair.Add( '[', ']' );
            bracketPair.Add( '{', '}' );

            LinkedList<char> remainingBracketPair = new LinkedList<char>();
            foreach (char _char in input)
            {
                if (bracketPair.ContainsKey(_char)) // if _char == openBracket
                {
                    remainingBracketPair.AddLast(_char);
                }
                else if (bracketPair.ContainsValue(_char)) // if _char == closeBracket
                {
                    if (remainingBracketPair.Count == 0) // if now we have close bracket but not have openbracket
                    {
                        Debug.Log("Invalid");
                        return;
                    }

                    char lastOpenBracket = remainingBracketPair.Last.Value;
                    char pairBracket = bracketPair[lastOpenBracket]; // Find Pair bracket Ex. last = ( ; return )
                    if (pairBracket == _char)//Check if correct bracket pair
                    {
                        remainingBracketPair.RemoveLast();
                    }
                }
            }

            if (remainingBracketPair.Count == 0)
            {
                Debug.Log("Valid");
            }
            else
            {
                Debug.Log("Invalid");
            }
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<int> current = list.Last;
            while (current != null)
            {
                Debug.Log(current.Value);
                current = current.Previous;
            }
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            while (fast.Next != null)
            {
                slow = slow.Next; 
                fast = fast.Next;
                if (fast.Next != null)
                {
                    fast = fast.Next;
                }
            }

            Debug.Log(slow.Value);
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();
            var mergedDictionary = new Dictionary<string, int>(dict1);
            foreach ( var kvp in dict2)
            {
                if (mergedDictionary.ContainsKey(kvp.Key))
                {
                    mergedDictionary[kvp.Key] += kvp.Value;
                }
                else
                {
                    mergedDictionary.Add(kvp.Key, kvp.Value);
                }
            }

            foreach ( var kvp in mergedDictionary)
            {
                Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
            Dictionary<int, bool> isNumberAvalible = new Dictionary<int, bool>();
            
            LinkedListNode<int> current = list.First;
            while (current != null)
            {
                if (isNumberAvalible.ContainsKey(current.Value))
                {
                    if (isNumberAvalible[current.Value] == false)
                    {
                        Debug.Log(current.Value);
                        isNumberAvalible[current.Value] = true;
                    }
                }
                else
                {
                    Debug.Log(current.Value);
                    isNumberAvalible[current.Value] = true;
                }
                current = current.Next;
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }
            Dictionary<int, int> numberDic = new Dictionary<int, int>();
            int maxFreKey = numbers[0];

            foreach (int i in numbers)
            {
                if (numberDic.ContainsKey(i))
                {
                    numberDic[i]++;
                }
                else
                {
                    numberDic.Add(i, 1);
                }

                // Check Max Frequency
                if (numberDic[i] > numberDic[maxFreKey])
                {
                    maxFreKey = i;
                }
            }
            Debug.Log($"Key: {maxFreKey}, Count {numberDic[maxFreKey]}");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory[itemName] = quantity;
            }

            foreach (var kvp in inventory)
            {
                Debug.Log($"Item {kvp.Key}: {inventory[kvp.Key]}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            if (eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }

            while (eventQueue.Count > 0)
            {
                GameEvent currentEvent = eventQueue.First.Value;
                eventQueue.RemoveFirst();

                Debug.Log($"Processing event: {currentEvent.Name}");
                Debug.Log($"Remaining events in queue: {eventQueue.Count}");
                Debug.Log($"{currentEvent.EventType} event processed - {currentEvent.Name}");
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;
            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
            }
            else
            {
                playerStats.Add(statName, value);
            }


            Debug.Log($"Updated {statName}: {playerStats[statName]}");
            Debug.Log("Current player statistics:");
            foreach (var kvp in playerStats)
            {
                Debug.Log($"{kvp.Key}: {kvp.Value}");
            }
        }

        #endregion
    }
}