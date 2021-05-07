using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScanObject : MonoBehaviour
{
    public GameObject scanObject;
    public bool isClickSpaceBar;
    private PlayerAction playerAction;

    private void Awake()
    {
        playerAction = GetComponent<PlayerAction>();
    }

    private void Update()
    {
        ScanObject();
    }

    void ScanObject()
    {
        Debug.DrawRay(transform.position, playerAction.dirVec * 0.7f, Color.red);
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, playerAction.dirVec, 0.7f, LayerMask.GetMask("Object"));
        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
            Debug.Log(scanObject.name);
        }
    }
}
