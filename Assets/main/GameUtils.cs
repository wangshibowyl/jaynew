using UnityEngine;
using System.Collections;

public class GameUtils 
{
#if UNITY_EDITOR1
    static public void Call(string methodName, params string[] args)
    {
        string param = "";
        foreach (object obj in args)
        {
            param += obj + ";";
        }
        Debug.Log(methodName + " " + param);
    }
#elif UNITY_IOS
	static public void Call(string methodName, params string[] args)
    {
        if (methodName == "updateLeaderboard")
		{
			if (args[0] == "0")
			{
				GameSocial.Instance.ReportScore("jaysayhungry_exp",long.Parse(args[1]));
			}
			else if (args[1] == "1")
			{
				GameSocial.Instance.ReportScore("jaysayhungry_money",long.Parse(args[1]));
			}
		}
		else if (methodName == "incrementAchievement")
		{
			switch(int.Parse(args[0]))
			{
			case 2:
				GameSocial.Instance.AddAchievementProgress("jaysayhungry_badukongjian",33.34f);
				break;
			case 4:
				GameSocial.Instance.AddAchievementProgress("jaysayhungry_qilixiang",16.67f);
				break;
			case 5:
				GameSocial.Instance.AddAchievementProgress("jaysayhungry_shiyiyuedexiaobang",2.0f);
				break;
			case 6:
				GameSocial.Instance.AddAchievementProgress("jaysayhungry_yiranfantexi",20.0f);
				break;
			case 9:
				GameSocial.Instance.AddAchievementProgress("jaysayhungry_kuashidai",2.0f);
				break;
			case 10:
				GameSocial.Instance.AddAchievementProgress("jaysayhungry_jingtanhao",2.0f);
				break;
			}
		}
		else if (methodName == "updateAchievement")
		{
			switch (int.Parse(args[0]))
			{
			case 0:
				GameSocial.Instance.AddAchievementProgress("jaysayhungry_jay",100.0f);
				break;
			case 1:
				GameSocial.Instance.AddAchievementProgress("jaysayhungry_fantexi",100.0f);
				break;
			case 3:
				GameSocial.Instance.AddAchievementProgress("jaysayhungry_yehuimei",100.0f);
				break;
			case 7:
				GameSocial.Instance.AddAchievementProgress("jaysayhungry_wohenmang",100.0f);
				break;
			}
		}
		else if (methodName == "feedback")
		{
			IOSUtils.Feedback();
		}
		else if (methodName == "chongzhi")
		{
			IOSUtils.ChongZhi();
		}
    }
#elif UNITY_ANDROID
    static private AndroidJavaObject mJavaObject;
    static public AndroidJavaObject getExtendObj()
    {
        if (mJavaObject == null)
        {
            AndroidJavaClass mJavaClass = new AndroidJavaClass("com.wangshibo.jaynew.jaynewNativeActivity");
            mJavaObject = mJavaClass.GetStatic<AndroidJavaObject>("single");
        }
        return mJavaObject;
    }
    static public void Call(string methodName,params string[] args)
    {
        if (mJavaObject == null)
        {
            mJavaObject = getExtendObj();
        }
        if (mJavaObject != null)
        {
            mJavaObject.Call(methodName, args);
        }
    }
#endif
}
