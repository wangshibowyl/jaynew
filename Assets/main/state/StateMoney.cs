using UnityEngine;
using System.Collections;
using System;

public class StateMoney : StateBase 
{
	public Texture2D mMoneyIcon;
    //public Texture2D mJayBiIcon;
    public GUIStyle mButtonStyle;
    public float mJayBi;
    private int mLiveDate;

    public override void loadState()
    {
        base.loadState();
        string date = PlayerPrefs.GetString("mLiveDate","0");
        if (date == "0")
        {
            PlayerPrefs.SetString("mLiveDate", DateTime.Now.Ticks.ToString());
        }
        mLiveDate = (DateTime.Now - new DateTime(long.Parse(PlayerPrefs.GetString("lastStateUpdateTime", DateTime.Now.Ticks.ToString())))).Days + 1;
        if (mLiveDate >= 20)
        {
            GameUtils.Call("updateAchievement", "7");
        }
    }

	public override void Progress()
    {
        GUILayout.BeginVertical();
        {
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
            {
                GUILayout.BeginVertical();
                {
                    if (StateInfo.getSingleton().mRoleState == ROLESTATE.RS_DEAD)
                    {
                        GUILayout.Label("<color=red>第" + mLiveDate + "天</color>", "moneylabel");
                    }
                    else
                    {
                        GUILayout.Label("<color=#518497>第" + mLiveDate + "天</color>", "moneylabel");
                    }
                    GUILayout.Label(new GUIContent("<color=#518497>" + mValue.ToString() + "杰币</color>", mMoneyIcon), "moneylabel");
                }
                GUILayout.EndVertical();
                GUILayout.Space(5);
                if (GUILayout.Button("领杰币", mButtonStyle))
                {
                    GameUtils.Call("chongzhi");
                }
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
    }
	
	public override bool onValueChange(float change, bool showPop = false)
    {
        if (mValue + change < 0)
		{
			MDialog.getSingleton().ShowMessage("杰伦币不足，请打工赚钱或领杰币","领杰币",()=>
			{
                GameUtils.Call("chongzhi");
			});
			return false;
		}
		else
		{
            if (mValue + change >= 3000)
            {
                GameUtils.Call("updateAchievement", "1");
            }
			base.onValueChange(change,showPop);
			return true;
		}
    }
}
