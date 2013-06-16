using UnityEngine;
using System.Collections;

public class OperateSimple : OperateBase 
{
    public override string GetTitle()
    {
        switch (mOperateID)
        {
            case OPERATE_ID.OI_SLEEP:
            {
                return StateInfo.getSingleton().stateWork.getWorkType() == StateWork.WORK_TYPE_SLEEP ? "起床" : "睡觉";
            }
        }
        return mTitle;
    }

	public override void OnOperate(bool bBuy = false)
	{
		switch(mOperateID)
		{
            case OPERATE_ID.OI_LEADERBOARD:
			{
#if UNITY_ANDROID
                GameUtils.Call("leaderboard");
#elif UNITY_IOS
				GameSocial.Instance.ShowLeaderboardUI("jaysayhungry_exp");
#endif
				break;
			}
            case OPERATE_ID.OI_ACHIEVEMENT:
            {
#if UNITY_ANDROID
                GameUtils.Call("achievement");
#elif UNITY_IOS
				GameSocial.Instance.ShowAchievementUI();
#endif
                break;
            }
            case OPERATE_ID.OI_RESET:
			{
				MDialog.getSingleton().ShowMessage("确定重置游戏？\n再给杰伦一次机会吧。","重置游戏",()=>
				{
					StateInfo.getSingleton().ResetState();
				});
				break;
			}
            case OPERATE_ID.OI_SHOP:
            {
                ThingWindow.getSingleton().ShowWindow("包装明星", "thing");
                break;
            }
            case OPERATE_ID.OI_CHANGE:
            {
                GameUtils.Call("change");
				//GameSocial.Instance.ShowLeaderboardUI("jaysayhungry_exp");
                break;
            }
            case OPERATE_ID.OI_FEEDBACK:
            {
                GameUtils.Call("feedback");
				//GameSocial.Instance.ShowLeaderboardUI("jaysayhungry_exp");
                break;
            }
            case OPERATE_ID.OI_BBS:
            {
                GameUtils.Call("appbbs");
                GameUtils.Call("incrementAchievement", "4");
                break;
            }
            case OPERATE_ID.OI_CHECKUPDATE:
            {
                GameUtils.Call("checkupdate");
				//GameSocial.Instance.ShowLeaderboardUI("jaysayhungry_exp");
                break;
            }
            case OPERATE_ID.OI_DUANXIN:
            {
                MDialog.getSingleton().ShowMessage("我喜欢杰伦喊饿3D并期待杰伦喊饿online,于是我决定短信骚扰作者王士博!", "发射短信!", () =>
                {
                    GameUtils.Call("duanxin","");
                    //GameSocial.Instance.ShowLeaderboardUI("jaysayhungry_exp");
                });
                break;
            }
            case OPERATE_ID.OI_SLEEP:
            {
                if (StateInfo.getSingleton().mRoleState == ROLESTATE.RS_DEAD)
                {
                    StateInfo.getSingleton().stateHealth.showReliveDialog();
                    break;
                }
                if (StateInfo.getSingleton().stateWork.getWorkType() == StateWork.WORK_TYPE_SLEEP)
                {
                    StateInfo.getSingleton().stateWork.BeginWork(-1);
                }
                else
                {
                    StateInfo.getSingleton().stateWork.BeginWork(StateWork.WORK_TYPE_SLEEP);
                }
                break;
            }
		}
	}
}
