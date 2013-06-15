using UnityEngine;
using System.Collections;

public class ThingWindow : MonoBehaviour 
{
    public GUISkin mSkin;
    public GUIStyle mWindowStyle;
    public GUIStyle mListStyle;
    public GUIStyle mImageStyle;

    public GameObject[] mThings;

    private string mTitle;
    private float mProgress;
    private int mCount;
    private string mCSV;
    private int mBuyThingFlag;
    private int mUseThingFlag;

    private static ThingWindow single;

    public static ThingWindow getSingleton()
    {
        return single;
    }

    void Awake()
    {
        single = this;
    }

    public void loadThings()
    {
        mBuyThingFlag = PlayerPrefs.GetInt("mBuyThingFlag", 0);
        mUseThingFlag = PlayerPrefs.GetInt("mUseThingFlag", 0);
        for (int i=0;i != mThings.Length;++i)
        {
            if (mThings[i])
            {
                mThings[i].renderer.enabled = (mUseThingFlag & (1 << i)) != 0;
            }
        }
    }

    public void ShowWindow(string title,string file)
    {
        mTitle = title;
        mListStyle.fixedHeight = (int)(Screen.height / 8.0f);
        mCSV = file;
        mCount = CSVReader.getRowCount(mCSV);
        enabled = true;
    }

    public void HideWindow()
    {
        enabled = false;
    }

    void OnGUI()
    {
        GUI.skin = mSkin;

        GUI.ModalWindow(0, new Rect(0, 0, Screen.width, Screen.height), DoWindow, "", mWindowStyle);
    }

    private float mousePos = -1;
    void DoWindow(int id)
    {
        if (GUIUtility.hotControl == 0)
        {
            Event current = Event.current;

            if (Event.current.type == EventType.MouseDown)
            {
                mousePos = current.mousePosition.y;
            }
            if (Event.current.type == EventType.MouseDrag && mousePos > 0)
            {
                mProgress -= (current.mousePosition.y - mousePos);
                mousePos = current.mousePosition.y;
            }
            if (Event.current.type == EventType.MouseUp)
            {
                mousePos = -1;
            }
        }
        else
        {
            mousePos = -1;
        }

        GUILayout.BeginVertical("", "topbar", GUILayout.Height(MainUI.statusBarHeight));
        {
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
            {
                GUILayout.Label("<color=#498496><size=25>" + mTitle + "</size></color>", "titlelabel");
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("确定", "graybutton"))
                {
                    HideWindow();
                }
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();

        GUILayout.BeginHorizontal();
        {
            GUILayout.Space(20);
            mProgress = GUILayout.BeginScrollView(new Vector2(0, mProgress)).y;//, mProgressStyle
            {
                for (int i = 0; i != mCount; ++i)
                {
                    GUILayout.BeginVertical("", mListStyle);
                    {
                        GUILayout.FlexibleSpace();
                        GUILayout.BeginHorizontal();
                        {
                            //GUILayout.Toggle(true, "");
                            Texture2D tex = Resources.Load("objimg/" + CSVReader.getString(mCSV, i.ToString(), "name")) as Texture2D;
                            if (!tex)
                            {
                                tex = Resources.Load("objimg/ic_photo_default") as Texture2D;
                            }
                            GUILayout.Label(tex, mImageStyle);
                            GUILayout.BeginVertical();
                            {
                                GUILayout.Label("<color=black><size=28>" + CSVReader.getString(mCSV, i.ToString(), "title") + "</size></color>");
                                GUILayout.Label("<color=#989898><size=20>" + CSVReader.getString(mCSV, i.ToString(), "cost") + "杰币" + "</size></color>");
                            }
                            GUILayout.EndVertical();

                            GUILayout.FlexibleSpace();

                            GUILayout.BeginVertical();
                            {
                                GUILayout.FlexibleSpace();
                                if ((mBuyThingFlag & (1 << i)) == 0)
                                {
                                    GUILayout.Label("<color=#989898><size=16>尚未购买" + "</size></color>");
                                    if (GUILayout.Button("购买", "graybutton"))
                                    {
                                        if (StateInfo.getSingleton().stateMoney.onValueChange(-CSVReader.getInt(mCSV, i.ToString(), "cost"), true))
                                        {
                                            mBuyThingFlag |= (1 << i);
                                            onThingChange(i,true);
                                            PlayerPrefs.SetInt("mBuyThingFlag", mBuyThingFlag);
                                            PlayerPrefs.Save();
                                        }
                                    }
                                }
                                else
                                {
                                    bool bLastClick = (mUseThingFlag & (1 << i)) != 0;
                                    bool bClick = GUILayout.Toggle(bLastClick, "",GUILayout.Width(70));
                                    if (bClick != bLastClick)
                                    {
                                        onThingChange(i, bClick);
                                        PlayerPrefs.Save();
                                    }
                                }
                                GUILayout.FlexibleSpace();
                            }
                            GUILayout.EndVertical();
                            GUILayout.Space(10);
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.FlexibleSpace();
                    }
                    GUILayout.EndVertical();
                }
            }
            GUILayout.EndScrollView();
        }
        GUILayout.EndHorizontal();
    }

    void onThingChange(int id,bool bUse)
    {
        if (bUse)
        {
            mUseThingFlag |= (1 << id);
            if (id == 0)
            {
                GameUtils.Call("updateAchievement","3");
            }
        }
        else
        {
            mUseThingFlag &= ~(1 << id);
        }
        PlayerPrefs.SetInt("mUseThingFlag", mUseThingFlag);
        if (mThings[id])
        {
            mThings[id].renderer.enabled = bUse;
        }
    }
}
