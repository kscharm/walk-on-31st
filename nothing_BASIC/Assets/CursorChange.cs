using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursor;

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void disable()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        GetComponent<CursorChange>().enabled = false;
    }
}
