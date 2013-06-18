using UnityEngine;
using System.Collections;

public class OperateObject : OperateBase 
{
	private string mName;
	public int mCount;
    private int mType;  //0-杰伦豆,1-杰伦币
	private int mCost;
	private int mExp;
	private int mMoney;
	private int mHealth;
	private int mPrower;
	private int mHunger;
	private int mThirst;
	private string mAnim;
    private string mWeapon;
    private GameObject mWeaponObj;
	
	public void init(int id)
	{
		mName = CSVReader.getString("object",id.ToString(),"name");
		mTitle = CSVReader.getString("object",id.ToString(),"title");
		mCount = PlayerPrefs.GetInt("object"+mName,0);
        mType = CSVReader.getInt("object", id.ToString(), "type");
		mCost = CSVReader.getInt("object",id.ToString(),"cost");
		mExp = CSVReader.getInt("object",id.ToString(),"exp");
		mMoney = CSVReader.getInt("object",id.ToString(),"money");
		mHealth = CSVReader.getInt("object",id.ToString(),"health");
		mPrower = CSVReader.getInt("object",id.ToString(),"power");
		mHunger = CSVReader.getInt("object",id.ToString(),"hunger");
		mThirst = CSVReader.getInt("object",id.ToString(),"thirst");
		mAnim = CSVReader.getString("object",id.ToString(),"anim");
        mWeapon = CSVReader.getString("object", id.ToString(), "weapon");
	}
	
	public override string GetTitle()
	{
		if (mCount == 0)
		{
			return mTitle+"\n<size=16><color=red>点击购买</color></size>";
		}
		else
		{
			return mTitle+"\n<size=16>剩余"+mCount+"个</size>";
		}
	}
	
	public override void OnOperate (bool bBuy = false)
	{
        if (StateInfo.getSingleton().mRoleState == ROLESTATE.RS_DEAD)
        {
            StateInfo.getSingleton().stateHealth.showReliveDialog();
            return;
        }

		if (mCount > 0 && !bBuy)
		{
			mCount--;
			PlayerPrefs.SetInt("object"+mName,mCount);
            if (mExp == -1)
            {
                mExp = Random.Range(-20, 100);
                if (mExp <= 0)
                {
                    mExp = 0;
                }
                else
                {
                    MDialog.getSingleton().ShowOneButtonMessage("吃香蕉悟出人生,获得创作灵感!\n获得" + mExp + "经验!", "知道了", () =>
                        {
                        });
                }
            }
            StateInfo.getSingleton().stateExp.onValueChange(mExp, true);
			StateInfo.getSingleton().stateHealth.onValueChange(mHealth,true);
            if (mMoney == -1)
            {
                mMoney = Random.Range(-20, 30);
                if (mMoney <= 0)
                {
                    mMoney = 0;
                }
                else
                {
                    MDialog.getSingleton().ShowOneButtonMessage("酸奶里居然吃到了杰币!\n获得" + mMoney + "个杰币!", "知道了", () =>
                    {
                    });
                }
            }
			StateInfo.getSingleton().stateMoney.onValueChange(mMoney,true);
			StateInfo.getSingleton().stateHunger.onValueChange(mHunger,true);
			StateInfo.getSingleton().statePower.onValueChange(mPrower,true);
			StateInfo.getSingleton().stateThirst.onValueChange(mThirst,true);
            BodyTouch.getSingleton().GetAnimator().SetBool(mAnim, true);
            Weapon.getSingleton().changeWeapon(mWeapon,4.5f);
            Debug.Log("play anmi: "+mAnim);
            if (mName == "suannai")
            {
                GameUtils.Call("incrementAchievement", "5");
            }
		}
		else
		{
            if (mType == 0)
            {
                MDialog.getSingleton().ShowSliderMessage("", "购买", () =>
                {
                    if (StateInfo.getSingleton().stateMoney.onValueChange(-mCost * MDialog.getSingleton().GetSliderCount(), true))
                    {
                        mCount += MDialog.getSingleton().GetSliderCount();
                        PlayerPrefs.SetInt("object" + mName, mCount);
                    }
                },
                (count) =>
                {
                    int money = mCost * count;
                    MDialog.getSingleton().SetMTitle("购买" + count + "个" + mTitle + ",花费"
                    + (money > StateInfo.getSingleton().stateMoney.mValue ? "<color=red>"
                    + money.ToString() + "</color>" : money.ToString()) + "杰币");
                });
            }
            else if (mType == 1)
            {
                GameUtils.Call("showShop");
            }
		}
	}
}
