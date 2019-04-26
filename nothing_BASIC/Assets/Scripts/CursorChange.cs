using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursor;
    public Transform player;
    public float maxInteractDistance = 5.0f;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }


    private void OnMouseEnter()
    {
        if (gameObject.activeSelf)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < maxInteractDistance)
            {
                Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
            }
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void disable()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        player.SendMessage("disableCursor");
    }
}
