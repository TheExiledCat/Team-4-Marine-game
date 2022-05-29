using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Manual : MonoBehaviour
{
    [SerializeField]
    Animator m_HandAnimator;
    [SerializeField]
    Image m_PageImage;
    [SerializeField]
    TMP_Text m_TextFieldImage, m_BigTextField;
    [SerializeField]
    CanvasGroup m_ImageGroup, m_TextGroup;
    [SerializeField]
    List<Page> m_Pages;
    [SerializeField]
    List<Sprite> m_Chapters;
    [SerializeField]
    List<Image> m_Images;
    [SerializeField]
    CanvasGroup m_BookmarkTriangle, m_BookmarkCircle, m_BookmarkCross, m_BookmarkSquare;

    Pilot.ManualActions m_ManualControls;
    InputAction m_Bookmark;
    InputAction m_SwapPage;
    int m_PageIndex, m_CurrentChapter;
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
        m_HandAnimator.SetBool("InteractingManual", false);
        if (m_SwapPage.WasPressedThisFrame())
        {
            m_HandAnimator.SetBool("InteractingManual", true);
            var value = CheckSwapPageInput(m_SwapPage.ReadValue<float>());
            SetPage(value);
        }        

        if (m_Bookmark.WasPressedThisFrame())
        {
            m_HandAnimator.SetBool("InteractingManual", true);
            CheckBookmarkInput();
            Bookmark(m_PageIndex);
        }

        SwapChapter(m_PageIndex);
    }

    private void SwapChapter(int _pageIndex)
    {
        switch (_pageIndex)
        {
            case int i when (i <= 3):
                m_CurrentChapter = 0;
                break;
            case int i when (i > 3 && i <= 6):
                m_CurrentChapter = 1;
                break;
            case int i when (i > 6 && i <= 9):
                m_CurrentChapter = 2;
                break;
            case int i when (i > 9):
                m_CurrentChapter = 3;
                break;
        }

        for (int i = 0; i < m_Images.Count; i++)
        {
            int targetIndex = i % 4 + m_CurrentChapter;
            m_Images[i].sprite = m_Chapters[targetIndex % 4];
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
        m_PageIndex = Mathf.Clamp(m_PageIndex, 0, m_Pages.Count);
        if(m_PageIndex > m_Pages.Count -1)
        {
            m_PageIndex = 0;
        }
        FormatPage(m_PageIndex);
    }

    private void FormatPage(int _pageIndex)
    {
        if(m_Pages[_pageIndex].m_Sprite == null)
        {
            m_TextGroup.alpha = 1;
            m_ImageGroup.alpha = 0;
            m_BigTextField.text = m_Pages[_pageIndex].m_Text;
        }
        else
        {
            m_TextGroup.alpha = 0;
            m_ImageGroup.alpha = 1;
            m_PageImage.sprite = m_Pages[_pageIndex].m_Sprite;
            m_TextFieldImage.text = m_Pages[_pageIndex].m_Text;
        }
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
            _bookmarkCanvasGroup.alpha = 1;
            m_PageBookmarks[_bookmark] = _currentPage;
        }
        else if (m_PageBookmarks[_bookmark] == _currentPage)
        {
            _bookmarkCanvasGroup.alpha = 0;
            m_PageBookmarks[_bookmark] = -1;
        }
        else
        {
            m_PageIndex = m_PageBookmarks[_bookmark];
            m_PageIndex = Mathf.Clamp(m_PageIndex, 0, m_Pages.Count - 1);
            FormatPage(m_PageIndex);
        }
    }
}
