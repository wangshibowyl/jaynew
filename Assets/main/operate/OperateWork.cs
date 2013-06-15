using UnityEngine;
using System.Collections;

public class OperateWork : OperateBase 
{
    private int mId;
    //private string mAnim;
    private int mPower;
    //private int mTime;
    //private int mMoney;
    //private int mExp;

    public void init(int id)
    {
        mId = id;
        mTitle = CSVReader.getString("work", id.ToString(), "title");
        mPower = CSVReader.getInt("work", id.ToString(), "power");
    }

	public override string GetTitle()
	{
        if (mPower > StateInfo.getSingleton().statePower.mValue)
		{
            return mTitle + "\n<size=16><color=red>需" + mPower + "点体力</color></size>";
		}
		else
		{
            return mTitle + "\n<size=16>需" + mPower + "点体力</size>";
		}
	}
	
	public override void OnOperate (bool bBuy = false)
	{
        if (StateInfo.getSingleton().statePower.mValue >= mPower && !bBuy)
        {
            StateInfo.getSingleton().statePower.onValueChange(-mPower, true);
            StateInfo.getSingleton().stateWork.BeginWork(mId);
        }
        else
        {
            MDialog.getSingleton().ShowSliderMessage((bBuy ? "" : ("体力不足,")) + "购买体力", "购买", () =>
            {
                if (StateInfo.getSingleton().stateMoney.onValueChange(-10, true))
                {
                    StateInfo.getSingleton().statePower.onValueChange(10, true);
                }
            }, (count) =>
            {
            });
        }
	}
}
