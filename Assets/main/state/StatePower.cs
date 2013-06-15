using UnityEngine;
using System.Collections;

public class StatePower : StateBase 
{
	public override void onCutPerTime()
	{
		if (StateInfo.getSingleton().mRoleState == ROLESTATE.RS_HEALTH)
		{
			mCutPerTime = 0.5f;
		}
		else if(StateInfo.getSingleton().mRoleState == ROLESTATE.RS_SICK)
		{
			mCutPerTime = -2f;
		}
		base.onCutPerTime();
	}
}
