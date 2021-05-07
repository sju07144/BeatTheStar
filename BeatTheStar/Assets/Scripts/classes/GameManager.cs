using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject scanObject;
    public GameObject talkPanel;
    public Text talkText;
    public TalkManager talkManager;
    public int talkIndex = 0;

    private bool isAction;
    private void Awake()
    {
        isAction = false;
    }

    private void Update()
    {
        player.GetComponent<PlayerAction>().UpdateValue(isAction);
        Action();
    }

    void Action()
    {
        scanObject = player.GetComponent<PlayerScanObject>().scanObject;
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            isAction = true;
            Debug.Log(isAction);
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNPC);
        }
        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNPC)
    {
        string currenttalkText = talkManager.GetTalk(id, talkIndex);
        if (currenttalkText == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        if (isNPC)
        {
            talkText.text = currenttalkText;
        }
        else
        {
            talkText.text = currenttalkText;
        }
        talkIndex++;
    }
}
