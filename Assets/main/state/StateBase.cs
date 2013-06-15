using UnityEngine;
using System.Collections;

public abstract class StateBase : MonoBehaviour
{
    public string mTitle;
    public float mValue;
	public float mDefaultValue;
	public float mMaxValue;
	public float mWarningValue;
    public float mCutPerTime;
	
    public virtual void loadState()
    {
        mValue = PlayerPrefs.GetFloat(ToString(), mDefaultValue);
    }

    public virtual void saveState()
    {
        PlayerPrefs.SetFloat(ToString(), mValue);
    }

    public float getMaxValue()
	{
		return mMaxValue;
	}

    public bool bWarningState
    {
		get
		{
        	return mValue < mWarningValue;
		}
    }

    public virtual void onCutPerTime()
    {
		if (mCutPerTime != 0)
		{
        	onValueChange(mCutPerTime,false);
		}
    }

    public virtual bool onValueChange(float change, bool showPop)
    {
        //float mLastValue = mValue;
        mValue += change;
        if (mValue < 0)
        {
            mValue = 0;
        }
        else if (mValue >= getMaxValue())
        {
        	mValue = getMaxValue();
        }
        if (showPop && change != 0)
        {
            if (change > 0)
            {
                StatePop.getSingleton().AddPop("<color=#518497><size=20>" + mTitle + "+" + change.ToString() + "</size></color>");
            }
            else
            {
                StatePop.getSingleton().AddPop("<color=red><size=20>" + mTitle + change.ToString() + "</size></color>");
            }
        }
        StateInfo.getSingleton().needSaveState = true;
		return true;
    }
	
	public virtual void Progress()
	{
		GUILayout.BeginHorizontal();
		{
			GUILayout.Label(mTitle,"proglabel");
			GUILayout.Label("","progback",GUILayout.Height(14));
		}
		Rect rect = GUILayoutUtility.GetLastRect();
		float progress = mValue/mMaxValue;
		if (bWarningState)
		{
			GUI.Label(new Rect(rect.xMin,rect.yMin,rect.width*progress,rect.height),"","progred");
		}
		else
		{
			GUI.Label(new Rect(rect.xMin,rect.yMin,rect.width*progress,rect.height),"","progblue");
		}
		GUILayout.EndHorizontal();
	}
}
