using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatePop : MonoBehaviour 
{
    private float mMin;
    private float mWidth;
    private List<string> mPopStrings = new List<string>();
    private string[] mUseStrings = new string[]{"","","","",""};
    private float[] mYPos = new float[5];

    private static StatePop single;

    public static StatePop getSingleton()
    {
        return single;
    }

    private void Awake()
    {
        single = this;
    }

    void Start()
    {
        mWidth = Screen.width * 0.2f;
        mMin = Screen.width - mWidth;
    }

	void OnGUI () 
    {
        for (int i = 0; i != mUseStrings.Length; ++i)
        {
            if (mUseStrings[i] != "")
            {
                GUI.Label(new Rect(mMin, mYPos[i], mWidth, 30), mUseStrings[i]);
            }
        }
	}

    public void AddPop(string str)
    {
        mPopStrings.Add(str);
        enabled = true;
    }

    private float mLastPopTime;
    private void Update()
    {
        if (Time.time - mLastPopTime > 0.5f && mPopStrings.Count != 0)
        {
            mLastPopTime = Time.time;
            for (int i = 0; i != mUseStrings.Length; ++i)
            {
                if (mUseStrings[i] == "")
                {
                    mUseStrings[i] = mPopStrings[0];
                    iTween.ValueTo(gameObject, iTween.Hash("from", Screen.height * 0.5f, "to", Screen.height * 0.5f - 200, "easetype", "easeOutCubic",
                        "time", 1.5f, "onupdate", "onShowPop" + i, "oncomplete", "onClosePop" + i));
                    mPopStrings.RemoveAt(0);
                    break;
                }
            }
        }
    }

    private void onShowPop0(float y)
    {
        mYPos[0] = y;
    }

    private void onShowPop1(float y)
    {
        mYPos[1] = y;
    }

    private void onShowPop2(float y)
    {
        mYPos[2] = y;
    }

    private void onShowPop3(float y)
    {
        mYPos[3] = y;
    }

    private void onShowPop4(float y)
    {
        mYPos[4] = y;
    }

    private void checkEnable()
    {
        enabled = false;
        for (int i = 0; i != mUseStrings.Length; ++i)
        {
            if (mUseStrings[i] != "")
            {
                enabled = true;
            }
        }
    }

    private void onClosePop0()
    {
        mUseStrings[0] = "";
        checkEnable();
    }

    private void onClosePop1()
    {
        mUseStrings[1] = "";
        checkEnable();
    }

    private void onClosePop2()
    {
        mUseStrings[2] = "";
        checkEnable();
    }

    private void onClosePop3()
    {
        mUseStrings[3] = "";
        checkEnable();
    }

    private void onClosePop4()
    {
        mUseStrings[4] = "";
        checkEnable();
    }
}
