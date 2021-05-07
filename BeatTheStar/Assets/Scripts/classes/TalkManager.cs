using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    private Dictionary<int, string[]> talkData;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "안녕?", "이곳에 처음 왔구나?" });
    }

    public string GetTalk(int id, int talkOrderIndex)
    {
        if (talkOrderIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkOrderIndex];
        }
    }
}
