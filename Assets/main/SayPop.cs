using UnityEngine;
using System.Collections;

public class SayPop : MonoBehaviour 
{
    public string[] mAdStr;
    public GUIStyle mPopStyle;
    private float mCurrentSize;
    public GUISkin mSkin;

    private static SayPop single;

    public static SayPop getSingleton()
    {
        return single;
    }

    private void Awake()
    {
        single = this;
    }

    private void OnApplicationFocus(bool focus)
    {
        enabled = false;
        CancelInvoke();
        Invoke("getCustomAd", 5.0f);
    }

    void getCustomAd()
    {
#if UNITY_EDITOR
        retGetCustomAd("dafkjlaskdfjlkv|百度浏览器|很好用的浏览器呵呵呵|50");
#elif UNITY_ANDROID
        GameUtils.Call("getCustomAd");
#endif
    }

    void retGetCustomAd(string str)
    {
        if (str != "")
        {
            mAdStr = str.Split(new char[]{'|'});
            enabled = true;
            mCurrentSize = 0;
            iTween.ValueTo(gameObject, iTween.Hash("from", 0.2f, "to", 1.0f, "easetype", "easeOutElastic",
                "time", 1.0f, "onupdate", "onShowPop"));
            Invoke("closeAni", 15.0f);
        }
    }

    private void OnGUI()
    {
        GUI.skin = mSkin;
        GUI.depth = 10;
        GUILayout.BeginArea(new Rect(Screen.width * 0.35f, Screen.height * 0.9f - 100, Screen.width * 0.65f * mCurrentSize - 10, 100 * mCurrentSize),mPopStyle);
        {
            GUILayout.BeginHorizontal();
            {
                GUILayout.BeginVertical();
                {
                    GUILayout.Label("<color=black><size=20>" + mAdStr[1] + "</size></color>");
                    GUILayout.Label("<color=black>" + mAdStr[2] + "</color>");
                }
                GUILayout.EndVertical();
                if (GUILayout.Button("详情", "graybutton"))
                {
                    GameUtils.Call("getCustomAdDesc", mAdStr[0]);
                    closePop();
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.Label("<color=black>主人,安装" + mAdStr[1] + "就能获得" + mAdStr[3] + "杰币!</color>");
        }
        GUILayout.EndArea();
    }

    public void closePop()
    {
        CancelInvoke();
        closeAni();
    }

    private void onShowPop(float value)
    {
        mCurrentSize = value;
    }

    private void closeAni()
    {
        iTween.ValueTo(gameObject, iTween.Hash("from", 1.0f, "to", 0.3f, "easetype", "easeInOutBack",
                "time", 1.0f, "onupdate", "onShowPop", "oncomplete", "onClosePop"));
    }

    private void onClosePop()
    {
        enabled = false;
    }
}
