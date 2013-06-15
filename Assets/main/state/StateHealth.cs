using UnityEngine;
using System.Collections;

public class StateHealth : StateBase 
{
    public GameObject mDeadObjPrefab;
    private GameObject mDeadObj;
    public GameObject mPlayerObj;

	public override void loadState()
    {
		base.loadState();
        onValueChange(0,false);
    }
	
	public override void onCutPerTime()
	{
		mCutPerTime = 0.5f;
		if (StateInfo.getSingleton().stateHunger.bWarningState)
		{
			mCutPerTime -= 1;
		}
		if (StateInfo.getSingleton().stateThirst.bWarningState)
		{
			mCutPerTime -= 1;
		}
		base.onCutPerTime();
	}
	
	public override bool onValueChange(float change, bool showPop)
	{
		base.onValueChange(change,showPop);
		if (mValue <= 0)
		{
            StateInfo.getSingleton().stateWork.BeginWork(-1);
            StateInfo.getSingleton().mRoleState = ROLESTATE.RS_DEAD;
            if (!mDeadObj)
            {
                mDeadObj = Instantiate(mDeadObjPrefab) as GameObject;
            }
            mPlayerObj.transform.position = new Vector3(0, 10000, 0);
			showReliveDialog();
		}
		else if (mValue < mWarningValue)
		{
			StateInfo.getSingleton().mRoleState = ROLESTATE.RS_SICK;
		}
		else
		{
			StateInfo.getSingleton().mRoleState = ROLESTATE.RS_HEALTH;
		}
		return true;
	}

    private void Relive()
    {
        if (mDeadObj)
        {
            Destroy(mDeadObj);
        }
        mPlayerObj.transform.position = new Vector3(0, 0, 0);
    }

	public void showReliveDialog()
	{
			MDialog.getSingleton().ShowMessage("您的杰伦不小心走了，\n您是否愿意花费500杰币请春哥为他复活？","信春哥，原地复活!",()=>
			{
                if (StateInfo.getSingleton().stateMoney.onValueChange(-500, true))
                {
                    Relive();
                    StateInfo.getSingleton().stateHealth.onValueChange(100, true);
                }
			}
			,"杰伦走好，重新开始",()=>
			{
				showResetDialog();
			});
	}
	
	private void showResetDialog()
	{
		MDialog.getSingleton().ShowMessage("确定重置游戏？\n再给杰伦一次机会吧。","重置游戏",()=>
			{
                Relive();
				StateInfo.getSingleton().ResetState();
			});
	}
}
