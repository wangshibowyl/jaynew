using UnityEngine;
using System.Collections;

public class StateWork : StateBase 
{
    public const int WORK_TYPE_SLEEP = 20;

    private int mWorkType = -1;
    private bool isWorking;

    public int getWorkType()
    {
        return mWorkType;
    }

    public bool getIsWorking()
    {
        return isWorking;
    }

    public override void loadState()
    {
        int workInt = PlayerPrefs.GetInt("mWorkType", -1);
        mWorkType = workInt % 1000;
        if (mWorkType > 100)
        {
            mWorkType = -1;
        }
        isWorking = workInt > 999;
        BeginWork(mWorkType);
        base.loadState();
    }

    public override void saveState()
    {
        PlayerPrefs.SetInt("mWorkType", mWorkType + (isWorking?1000:0));
        base.saveState();
    }

    public void BeginWork(int id)
    {
        if (StateInfo.getSingleton().mRoleState == ROLESTATE.RS_DEAD)
        {
            StateInfo.getSingleton().stateHealth.showReliveDialog();
            return;
        }
        mWorkType = id;
        if (id == StateWork.WORK_TYPE_SLEEP)
        {
            StateInfo.getSingleton().BeginSleep();
        }
        else
        {
            StateInfo.getSingleton().EndSleep();
        }
        isWorking = true;
        mValue = 0;
        mMaxValue = CSVReader.getInt("work", id.ToString(), "time");
        mTitle = CSVReader.getString("work", id.ToString(), "title");
        BodyTouch.getSingleton().GetAnimator().SetInteger("workstate", mWorkType);
        Weapon.getSingleton().onDestroyWeapon();
    }

    public override void Progress()
    {
        if (mWorkType >= 0)
        {
            if (mValue == mMaxValue)
            {
                if (isWorking)
                {
                    isWorking = false;
                    BodyTouch.getSingleton().GetAnimator().SetInteger("workstate", -1);
                    Weapon.getSingleton().onDestroyWeapon();
                }
                int money = CSVReader.getInt("work", mWorkType.ToString(), "money");
                if (money == 0 || GUILayout.Button("领工钱\n$" + money, "graybutton"))
                {
                    if (mWorkType == 2)
                    {
                        GameUtils.Call("incrementAchievement", "6");
                    }
                    else if (mWorkType == WORK_TYPE_SLEEP)
                    {
                        GameUtils.Call("incrementAchievement", "10");
                    }
                    StateInfo.getSingleton().EndSleep();
                    StateInfo.getSingleton().stateMoney.onValueChange(money, true);
                    int exp = CSVReader.getInt("work", mWorkType.ToString(), "exp");
                    StateInfo.getSingleton().stateExp.onValueChange(exp, true);
                    mWorkType = -1;
                }
            }
            else
            {
                GUILayout.BeginVertical();
                {
                    GUILayout.Label("<size=14>" + mTitle + "("+mValue+"/"+mMaxValue+")"+"</size>", "proglabel");
                    GUILayout.Label("", "progback", GUILayout.Height(14));
                }
                Rect rect = GUILayoutUtility.GetLastRect();
                float progress = mValue / mMaxValue;
                GUI.Label(new Rect(rect.xMin, rect.yMin, rect.width * progress, rect.height), "", "progred");
                GUILayout.EndVertical();
            }
        }
    }
}
