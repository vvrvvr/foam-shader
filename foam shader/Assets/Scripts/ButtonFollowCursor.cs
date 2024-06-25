using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonFollowCursor : MonoBehaviour
{
    public GameObject button;
    public RectTransform buttonRectTransform;
    public Texture2D cursorTexture;

    private Vector3 cursorPosition;
    private bool isHovering = false;

    private void Start()
    {
        button.SetActive(false);
    }

    void Update()
    {
        if (isHovering)
        {
            cursorPosition = Input.mousePosition;
            buttonRectTransform.position = cursorPosition;
        }
    }

    private void OnMouseEnter()
    {
        button.SetActive(true);
        isHovering = true;
        if(cursorTexture !=null)
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        button.SetActive(false);
        isHovering = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}