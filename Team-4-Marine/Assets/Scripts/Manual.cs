using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Manual : MonoBehaviour
{
    [SerializeField]
    Image m_PageImage;
    [SerializeField]
    List<Sprite> m_Pages;

    Pilot.ManualActions m_ManualControls;
    InputAction m_Bookmark;
    int m_PageIndex;

    enum BookmarkButton { Triangle, Circle, Cross, Square };

    BookmarkButton m_BookmarkButton;

    private void Start()
    {
        m_ManualControls = GameManager.GM.m_PilotControls.Manual;
        m_Bookmark = m_ManualControls.Bookmark;
        m_PageIndex = 0;
    }

    private void Update()
    {
        if (m_ManualControls.PageLeft.WasPressedThisFrame())
        {
           m_PageIndex--;
        }
        if (m_ManualControls.PageRight.WasPressedThisFrame())
        {
           m_PageIndex++;
        }
        m_PageIndex = Mathf.Clamp(m_PageIndex, 0, m_Pages.Count - 1);
        SetPage();

        if (m_Bookmark.WasPressedThisFrame())
        {
            CheckBookmarkInput();
            Bookmark();
        }
    }

    private void SetPage()
    {
        m_PageImage.sprite = m_Pages[m_PageIndex];
    }

    private void CheckBookmarkInput()
    {
        switch (m_Bookmark.ReadValue<Vector2>().x)
        {
            case 1:
                m_BookmarkButton = BookmarkButton.Circle;
                break;
            case -1:
                m_BookmarkButton = BookmarkButton.Square;
                break;
        }

        switch (m_Bookmark.ReadValue<Vector2>().y)
        {
            case 1:
                m_BookmarkButton = BookmarkButton.Triangle;
                break;
            case -1:
                m_BookmarkButton = BookmarkButton.Cross;
                break;
        }
    }

    private void Bookmark()
    {
        switch (m_BookmarkButton)
        {
            case BookmarkButton.Triangle:
                Debug.Log("Triangle pressed");
                break;
            case BookmarkButton.Circle:
                Debug.Log("Circle pressed");
                break;
            case BookmarkButton.Cross:
                Debug.Log("Cross pressed");
                break;
            case BookmarkButton.Square:
                Debug.Log("Square pressed");
                break;
        }
    }
}
