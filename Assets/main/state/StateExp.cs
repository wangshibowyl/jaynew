using UnityEngine;
using System.Collections;

public class StateExp : StateBase 
{
	public Rect mLevelsCoordRect;
	public Texture2D mLevelsTex;
    public Texture2D mLevelIconColor;
    private Color mLevelColor;
    public Texture2D[] mStarTexs;
    private int mStarCount;
    public Texture2D[] mLevelIconBack;
    private int mBackType;
	
	private void Awake()
	{
		Invoke("UpdateLevelUI",1.0f);
	}
	
	private void UpdateLevelUI()
	{
		mLevelsCoordRect.x += 0.25f;
		if (mLevelsCoordRect.x > 0.8f)
		{
			mLevelsCoordRect.x = 0;
			mLevelsCoordRect.y -= 0.25f;
			if (mLevelsCoordRect.y < 0.2f)
			{
				mLevelsCoordRect.y = 0.75f;
				Invoke("UpdateLevelUI",2.0f);
				return;
			}
		}
		Invoke("UpdateLevelUI",0.1f);
	}
	
	public override void loadState()
    {
        base.loadState();
        onLevelChange();
    }

    private void onLevelChange()
    {
        if (StateInfo.getSingleton().mLevel >= 10)
        {
            GameUtils.Call("updateAchievement", "0");
        }
        int level = StateInfo.getSingleton().mLevel;
        mMaxValue = CSVReader.getInt("level", level.ToString(), "exp");
        if (level > 119)
        {
            level = 119;
        }
        mStarCount = level % 4;
        mBackType = level / 24;
        switch ((level / 4) % 6)
        {
            case 0:
                mLevelColor = Color.white;
                break;
            case 1:
                mLevelColor = new Color(1, 1, 96 / 256.0f);
                break;
            case 2:
                mLevelColor = new Color(156 / 256.0f, 1, 96 / 256.0f);
                break;
            case 3:
                mLevelColor = new Color(0.421875f, 0.72265625f, 0.90234375f);
                break;
            case 4:
                mLevelColor = Color.red;
                break;
            case 5:
                mLevelColor = Color.black;
                break;
        }
    }
	
	public override bool onValueChange(float change, bool showPop)
    {
		//float mLastValue = mValue;
        mValue += change;
        if (mValue < 0)
        {
            mValue = 0;
        }
        else if (mValue >= getMaxValue())
        {
            //    showPop = false;
            mValue = mValue - getMaxValue();
			StateInfo.getSingleton().mLevel++;
            onLevelChange();
            if (mValue >= mMaxValue)
            {
                mValue = mMaxValue - 1;
            }
        }
        GameUtils.Call("updateLeaderboard", "0",(StateInfo.getSingleton().mLevel * 100000 + mValue).ToString());
        if (showPop)
        {
            //StatePop.addStatePop(mContent, (int)(value - lastJiedu), Yang.getSingle().transform);
        }
        StateInfo.getSingleton().needSaveState = true;
		return true;
	}
	
	public override void Progress()
	{
		float progress = mValue/mMaxValue;
		
		GUILayout.Label(mValue+"/"+mMaxValue,"progback",GUILayout.Height(5));
		Rect rect = GUILayoutUtility.GetLastRect();
        //GUILayout.Space(1);
		GUI.Label(new Rect(rect.xMin,rect.yMin,rect.width*progress,rect.height),"","progblue");
		
		GUI.DrawTextureWithTexCoords(new Rect(rect.xMax-61,rect.yMax-46,64,32), mLevelsTex, mLevelsCoordRect);
		GUI.Label(new Rect(rect.xMax-45, rect.yMax-49, 64, 32), StateInfo.getSingleton().mLevel.ToString(), "levellabel");
	}

    public void levelIcon(Rect rect)
    {
        if (GUIUtility.hotControl == 0 && (Input.GetMouseButton(0) || Input.touchCount == 1) && rect.Contains(Event.current.mousePosition))
        {
            enabled = true;
        }
        else
        {
            enabled = false;
        }
        GUI.DrawTexture(rect, mLevelIconBack[mBackType], ScaleMode.StretchToFill);
        GUI.color = mLevelColor;
        GUI.DrawTexture(rect, mLevelIconColor, ScaleMode.StretchToFill);
        GUI.color = Color.white;
        GUI.DrawTexture(rect, mStarTexs[mStarCount], ScaleMode.StretchToFill);
    }

    private void OnGUI()
    {
        Rect bigRect = new Rect(Screen.width * 0.25f, Screen.height * 0.5f - Screen.width * 0.25f, Screen.width * 0.5f, Screen.width * 0.5f);
        GUI.DrawTexture(bigRect, mLevelIconBack[mBackType], ScaleMode.StretchToFill);
        GUI.color = mLevelColor;
        GUI.DrawTexture(bigRect, mLevelIconColor, ScaleMode.StretchToFill);
        GUI.color = Color.white;
        if (mStarTexs[mStarCount] != null)
        {
            GUI.DrawTexture(bigRect, mStarTexs[mStarCount], ScaleMode.StretchToFill);
        }
    }
}
