using UnityEngine;
using System.Collections;

public class MDialog : MonoBehaviour 
{
	public GUISkin mSkin;
	public delegate void MButtonEvent();
    public delegate void MSliderChange(int value);
	private string mTitle;
    private int mType;
	private string mButton1Str;
	private MButtonEvent mButton1Event;
	private string mButton2Str;
	private MButtonEvent mButton2Event;

    private int mSliderCount;
    private MSliderChange mSliderChangeEvent;

    public Texture2D mBack;
    public GUIStyle mWBackStyle;
    public GUIStyle mWBarStyle;
    public GUIStyle mWButtonStyle;
	
	private static MDialog single;
	
	public static MDialog getSingleton()
	{
		return single;
	}
	
	private void Awake()
	{
		single = this;
	}
	
	public void ShowMessage(string title,string button1str,MButtonEvent button1event,string button2str = "取消",MButtonEvent button2event = null)
	{
        ThingWindow.getSingleton().HideWindow();
        ListWindow.getSingleton().HideWindow();
		enabled = true;
        mType = 0;
        SetMTitle(title);
		mButton1Str = button1str;
		mButton1Event = button1event;
		mButton2Str = button2str;
		mButton2Event = button2event;
	}

    public void ShowSliderMessage(string title,string button1str,MButtonEvent button1event,MSliderChange sliderevent)
    {
        mSliderCount = 10;
        ListWindow.getSingleton().HideWindow();
		enabled = true;
        mType = 1;
        SetMTitle(title);
		mButton1Str = button1str;
		mButton1Event = button1event;
		mButton2Str = "取消";
        mButton2Event = null;
        mSliderChangeEvent = sliderevent;
        mSliderChangeEvent(10);
    }

    public void ShowOneButtonMessage(string title, string button1str, MButtonEvent button1event)
    {
        ThingWindow.getSingleton().HideWindow();
        ListWindow.getSingleton().HideWindow();
        enabled = true;
        mType = 3;
        SetMTitle(title);
        mButton1Str = button1str;
        mButton1Event = button1event;
    }

    public void SetMTitle(string title)
    {
        mTitle = "<color=black>"+title+"</color>";
    }

    public int GetSliderCount()
    {
        return mSliderCount;
    }
	
	public void CloseMessage()
	{
		enabled = false;
	}
	
	private void OnGUI()
	{
		GUI.skin = mSkin;
		
		//"杰伦币不足，\n您可以打工赚钱，或免费领取杰伦币。"
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), mBack, ScaleMode.StretchToFill);
        GUI.ModalWindow(0, new Rect(Screen.width*0.1f, Screen.height * 0.35f, Screen.width * 0.8f, Screen.height * 0.3f), DoWindow, mTitle, mWBackStyle);
	}

    private void DoWindow(int id)
    {
        if (mType == 0)
        {
            GUILayout.BeginVertical();
            {
                GUILayout.FlexibleSpace();
                GUILayout.BeginHorizontal("", mWBarStyle);
                {
                    if (GUILayout.Button(mButton1Str, mWButtonStyle, GUILayout.Height(Screen.height * 0.1f)))
                    {
                        CloseMessage();
                        mButton1Event();
                    }
                    if (GUILayout.Button(mButton2Str, mWButtonStyle, GUILayout.Height(Screen.height * 0.1f)))
                    {
                        CloseMessage();
                        if (mButton2Event != null)
                        {
                            mButton2Event();
                        }
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
        else if (mType == 1)
        {
            GUILayout.BeginVertical();
            {
                GUILayout.FlexibleSpace();
                GUILayout.BeginHorizontal();
                {
                    GUILayout.FlexibleSpace();
                    int mNewSliderCount = (int)GUILayout.HorizontalSlider(mSliderCount, 1, 99,GUILayout.Width(Screen.width*0.4f));
                    if (mNewSliderCount != mSliderCount)
                    {
                        mSliderCount = mNewSliderCount;
                        mSliderChangeEvent(mSliderCount);
                    }
                    GUILayout.Label("<color=black><size=20>" + (mSliderCount<10?"  ":"") + mSliderCount + "</size></color>");
                    GUILayout.FlexibleSpace();
                }
                GUILayout.EndHorizontal();
                GUILayout.Space(Screen.height * 0.05f);
                GUILayout.BeginHorizontal("", mWBarStyle);
                {
                    if (GUILayout.Button(mButton1Str, mWButtonStyle, GUILayout.Height(Screen.height * 0.1f)))
                    {
                        CloseMessage();
                        mButton1Event();
                    }
                    if (GUILayout.Button(mButton2Str, mWButtonStyle, GUILayout.Height(Screen.height * 0.1f)))
                    {
                        CloseMessage();
                        if (mButton2Event != null)
                        {
                            mButton2Event();
                        }
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
        else if (mType == 3)
        {
            GUILayout.BeginVertical();
            {
                GUILayout.FlexibleSpace();
                GUILayout.BeginHorizontal("", mWBarStyle);
                {
                    if (GUILayout.Button(mButton1Str, mWButtonStyle, GUILayout.Height(Screen.height * 0.1f)))
                    {
                        CloseMessage();
                        mButton1Event();
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
    }
}
