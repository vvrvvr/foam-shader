using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public Texture2D cursorTexture;


    public void StartGame()
    {
        Debug.Log("Starting the game...");
    }


    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        Debug.Log("enter");
    }


    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }


    void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            StartGame();
        }
    }
}