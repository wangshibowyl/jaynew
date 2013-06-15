using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.SocialPlatforms;

public class SubMenu : MonoBehaviour 
{
	private Rect mRect;
	public static float mRectTop;
	
    private int mMenuId;
	public GameObject[] operateObj;
	private OperateBase[] operateScr;
	
	public GUISkin mSkin;
	public GUIStyle menuBackStyle;
	public GUIStyle menuButtonStyle;

    private int xCount;
    private int yCount;
    private float buttonWidth;
    private float buttonHeight;
	
	private Vector2 scrollViewPos;
	
	public void showMenu(int id)
	{
        mMenuId = id;
		if (id == 0)
		{
            OperateObject[] operateObjs = operateObj[id].GetComponents<OperateObject>();
            int count = CSVReader.getRowCount("object");
            for (int i = 0; i != count; ++i)
            {
                if (operateObjs.Length == 0)
                {
                    operateObj[id].AddComponent<OperateObject>().init(i);
                }
                else
                {
                    operateObjs[i].init(i);
                }
            }
            xCount = 3;
            yCount = 2;
		}
        else if (id == 1)
        {
            OperateWork[] operateObjs = operateObj[id].GetComponents<OperateWork>();
            int count = CSVReader.getRowCount("work");
            for (int i = 0; i != count; ++i)
            {
                if (i < 10)
                {
                    if (operateObjs.Length == 0)
                    {
                        operateObj[id].AddComponent<OperateWork>().init(i);
                    }
                    else
                    {
                        operateObjs[i].init(i);
                    }
                }
            }
            xCount = 3;
            yCount = 2;
        }
        else
        {
            xCount = 3;
            yCount = 2;
        }

        mRectTop = Screen.height * 0.6f;
        mRect = new Rect(2, mRectTop, Screen.width - 4, Screen.height * 0.91f - mRectTop - 2);
        buttonWidth = mRect.width * (1.0f / xCount);
        buttonHeight = mRect.height * (1.0f / yCount);
		operateScr = operateObj[id].GetComponents<OperateBase>();
		enabled = true;
	}
	
	public void hideMenu()
	{
		enabled = false;
		MainUI.buttomBarLastSelect = -1;
	}
	
	private float mouseDowntime;
	private bool longPressEvent;
	private const  float LONG_PRESS_TIME = 0.5f;
	private void OnGUI()
	{
		GUI.skin = mSkin;
		
		if (GUIUtility.hasModalWindow)
		{
			GUI.enabled = false;
		}
		
		if (Input.GetMouseButtonDown(0) && Input.mousePosition.y > Screen.height-SubMenu.mRectTop)
		{
			hideMenu();
		}
		
		//Event eventCurrent = Event.current;
		//if (mRect.Contains(eventCurrent.mousePosition))
		//{
		//	if (eventCurrent.delta != Vector2.zero)
		//	{
		//		scrollViewPos.x -= eventCurrent.delta.x / mRect.width;
		//	}
		//}
		
		longPressEvent = false;
		Event eventCurrent = Event.current;
		if (eventCurrent .type == EventType.MouseDown)
		{
			mouseDowntime = Time.time;
		}
		
		if (Input.GetMouseButton(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Stationary))
		{
			if (mouseDowntime != 0 && Time.time - mouseDowntime > LONG_PRESS_TIME)
			{
				longPressEvent = true;
			}
		}
		else
		{
			mouseDowntime = 0;
		}
		
		//scrollViewPos = mRect,scrollViewPos,
        GUI.BeginGroup(mRect,"","box");
		int m = 0;
		for (int i=0;i<xCount;++i)
		{
			for (int j=0;j<yCount;++j)
			{
                m = i * yCount + j;
				if (m >= operateScr.Length)
				{
                    break;
                }
                Rect rect = new Rect(i * (buttonWidth + 1), j * (buttonHeight + 1), buttonWidth, buttonHeight);

                if (m == yCount * xCount - 1 && mMenuId == 0)
                {
                    if (GUI.Button(rect, "更多", menuButtonStyle))
                    {
                        ListWindow.getSingleton().ShowWindow("食物","object");
                        hideMenu();
                    }
                }
                else
                {
                    if (GUI.Button(rect, operateScr[m].GetTitle(), menuButtonStyle))
                    {
                        operateScr[m].OnOperate();
                        hideMenu();
                    }

                    if (longPressEvent && rect.Contains(Event.current.mousePosition))
                    {
                        operateScr[m].OnOperate(true);
                        hideMenu();
                    }
                }
			}
		}
		GUI.EndGroup();
			
		//GUILayout.BeginArea(mRect,"",menuBackStyle);
		//{
		//	scrollViewPos = GUILayout.BeginScrollView(scrollViewPos);
		//	scrollViewPos . y = 0;
		//	currentSelect = GUILayout.SelectionGrid(lastSelect,mButtonStrs,Mathf.CeilToInt(mButtonStrs.Length * 0.5f),menuButtonStyle);
			//if (eventCurrent.delta != Vector2.zero)
			//{
			//	currentSelect = lastSelect;
			//}
		//	if (currentSelect != lastSelect)
		//	{
		//		lastSelect = currentSelect;
		//		operateScr[currentSelect].OnOperate();
		//		hideMenu();
		//	}
		//	GUILayout.EndScrollView();
		//}
		//GUILayout.EndArea();
	}
}
