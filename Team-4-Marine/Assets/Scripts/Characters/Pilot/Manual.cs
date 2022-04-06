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
    [SerializeField]
    CanvasGroup m_BookmarkTriangle, m_BookmarkCircle, m_BookmarkCross, m_BookmarkSquare;

    Pilot.ManualActions m_ManualControls;
    InputAction m_Bookmark;
    InputAction m_SwapPage;
    int m_PageIndex;
    int[] m_PageBookmarks = {-1, -1, -1, -1 }; //index 0 = Triangle, 1 = Circle, 2 = Cross, 3 = Square

    enum BookmarkButton { Triangle, Circle, Cross, Square };

    BookmarkButton m_BookmarkButton;

    private void Start()
    {
        m_ManualControls = GameManager.GM.m_PilotControls.Manual;
        m_Bookmark = m_ManualControls.Bookmark;
        m_SwapPage = m_ManualControls.SwapPage;
        m_PageIndex = 0;
    }

    private void Update()
    {
        if (m_SwapPage.WasPressedThisFrame())
        {
            var value = CheckSwapPageInput(m_SwapPage.ReadValue<float>());
            SetPage(value);
        }        

        if (m_Bookmark.WasPressedThisFrame())
        {
            CheckBookmarkInput();
            Bookmark(m_PageIndex);
        }
    }

    private int CheckSwapPageInput(float _value)
    {
        return _value == 0 ? 0 : (int)Mathf.Sign(_value);
    }

    private void SetPage(int _value)
    {
        switch (_value)
        {
            case -1:
                m_PageIndex--;
                break;
            case 1:
                m_PageIndex++;
                break;
        }
        m_PageIndex = Mathf.Clamp(m_PageIndex, 0, m_Pages.Count - 1);
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

    private void Bookmark(int _currentPage)
    {
        switch (m_BookmarkButton)
        {
            case BookmarkButton.Triangle:
                CheckBookmark(0, m_BookmarkTriangle, _currentPage);
                break;
            case BookmarkButton.Circle:
                CheckBookmark(1, m_BookmarkCircle, _currentPage);
                break;
            case BookmarkButton.Cross:
                CheckBookmark(2, m_BookmarkCross, _currentPage);
                break;
            case BookmarkButton.Square:
                CheckBookmark(3, m_BookmarkSquare, _currentPage);
                break;
        }
    }

    private void CheckBookmark(int _bookmark, CanvasGroup _bookmarkCanvasGroup, int _currentPage)
    {
        if (m_PageBookmarks[_bookmark] == -1)
        {
            Debug.Log("bookmark placed");
            _bookmarkCanvasGroup.alpha = 1;
            m_PageBookmarks[_bookmark] = _currentPage;
        }
        else if (m_PageBookmarks[_bookmark] == _currentPage)
        {
            Debug.Log("bookmark removed");
            _bookmarkCanvasGroup.alpha = 0;
            m_PageBookmarks[_bookmark] = -1;
        }
        else
        {
            Debug.Log("move to bookmark");
            m_PageIndex = m_PageBookmarks[_bookmark];
            m_PageIndex = Mathf.Clamp(m_PageIndex, 0, m_Pages.Count - 1);
            m_PageImage.sprite = m_Pages[m_PageIndex];
        }
    }
}
