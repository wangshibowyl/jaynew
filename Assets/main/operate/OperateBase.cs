using UnityEngine;
using System.Collections;

public abstract class OperateBase : MonoBehaviour 
{
	protected enum OPERATE_ID
	{
		OI_00=0,	 
		OI_01,	
		OI_02,
		OI_03,
		OI_04,
		OI_05,
		OI_10=10,
		OI_11,
		OI_12,
		OI_13,
		OI_14,
		OI_15,
		OI_20=20,
		OI_21,
		OI_SLEEP,
		OI_DUANXIN,
		OI_SHOP,
		OI_CHECKUPDATE,
		OI_LEADERBOARD,
		OI_RESET,
        OI_ACHIEVEMENT,
		OI_CHANGE,
		OI_FEEDBACK,
        OI_BBS,
	}
	
	[SerializeField]
	protected string mTitle;
	[SerializeField]
	protected OPERATE_ID mOperateID;
	
	public virtual string GetTitle()
	{
		return mTitle;
	}
	
	public abstract void OnOperate(bool bBuy = false);
	
	public bool Draw(Rect position,GUIStyle style)
	{	
		return GUI.Button( position, GetTitle() ,style);
	}
}
