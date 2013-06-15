using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour
{
	public static float statusBarHeight;
	private string mTitle = "";
	public GUISkin mSkin;
    public GUIStyle mGPlusButtonStyle;
	
	public Texture2D[] buttomBarNormalTexs;
	public Texture2D[] buttomBarSelectTexs;
	public Texture2D[] buttomBarTexs;
	public static int buttomBarLastSelect = -1;
	private int buttomBarSelect = -1;

    private bool mIsLogining;
	
	private static MainUI single;
	
	public static MainUI getSingleton()
	{
		return single;
	}
	
	private void Awake()
	{
		single = this;
	}
	
	private void Start()
	{
#if	 UNITY_IOS
        statusBarHeight = Screen.height*0.09f+20;
		GameSocial.Instance.Initialize();
#else
        statusBarHeight = Screen.height * 0.09f;
#endif
        mTitle = PlayerPrefs.GetString("mTitle", "");
    }
	
	public void SetTitle(string title)
	{
        if (title.Length > 10)
        {
            mTitle = title.Substring(0, 10) + "...";
        }
        else
        {
            mTitle = title;
        }
	}
	
	private void OnGUI()
	{
		GUI.skin = mSkin;
		
        GUI.enabled = !GUIUtility.hasModalWindow;

        GUI.Label(new Rect(0, 0, Screen.width, statusBarHeight+4),"","topbar");
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, statusBarHeight));
		{
            GUILayout.BeginHorizontal();
			{
                GUILayout.Space(10);
				GUILayout.BeginVertical(GUILayout.Height(statusBarHeight),GUILayout.Width(Screen.width*0.5f));
				{
                    GUILayout.FlexibleSpace();
					//GUILayout.BeginHorizontal();
					//{
                        if (mTitle == "")
                        {
                            GUI.enabled = !mIsLogining;
                            if (GUILayout.Button("", mGPlusButtonStyle, GUILayout.Height(statusBarHeight * 0.7f), GUILayout.Width(statusBarHeight * 1.6f)))
                            {
                                mIsLogining = true;
                                GameUtils.Call("onSignInButtonClicked");
                            }
                            GUI.enabled = !GUIUtility.hasModalWindow;
                        }
                        else
                        {
                            if (GUILayout.Button("<color=#498496><size=30>" + mTitle + "</size><size=16>的杰伦</size></color>", "titlelabel"))
                            {
                                mTitle = "";
                                mIsLogining = false;
                                GameUtils.Call("onSignOutButtonClicked");
                            }
                        }
						//GUILayout.FlexibleSpace();
					//}
					//GUILayout.EndHorizontal();
					StateInfo.getSingleton().stateExp.Progress();
				}
				GUILayout.EndVertical();
				GUILayout.FlexibleSpace();
				StateInfo.getSingleton().stateMoney.Progress();
                GUILayout.Space(10);
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.EndArea();
		
		GUILayout.BeginArea(new Rect(10,statusBarHeight + 5,Screen.width*0.3f,350));
		{
			StateInfo.getSingleton().stateHealth.Progress();
			StateInfo.getSingleton().stateHunger.Progress();
			StateInfo.getSingleton().stateThirst.Progress();
			StateInfo.getSingleton().statePower.Progress();
            StateInfo.getSingleton().stateExp.levelIcon(new Rect(0,GUILayoutUtility.GetLastRect().yMax + 10,Screen.width*0.15f,Screen.width*0.15f));
		}
		GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(Screen.width * 0.75f, statusBarHeight + 5, Screen.width * 0.25f-10, 100));
        {
            StateInfo.getSingleton().stateWork.Progress();
        }
        GUILayout.EndArea();
		
		GUILayout.BeginArea(new Rect(0,Screen.height*0.91f,Screen.width,Screen.height*0.09f));
		{
			GUILayout.BeginVertical("buttombar");
			{
				GUILayout.FlexibleSpace();
				buttomBarSelect = GUILayout.Toolbar(buttomBarLastSelect,buttomBarLastSelect == -1 ?buttomBarNormalTexs : buttomBarTexs,"buttombarbtn");
				if (buttomBarLastSelect != buttomBarSelect)
				{
					buttomBarLastSelect = buttomBarSelect;
					for (int i=0;i!=buttomBarTexs.Length;++i)
					{
						buttomBarTexs[i] = buttomBarNormalTexs[i];
					}
					if (buttomBarSelect != -1)
					{
						buttomBarTexs[buttomBarSelect] = buttomBarSelectTexs[buttomBarSelect];
                        GetComponent<SubMenu>().showMenu(buttomBarSelect);
					}
				}
				GUILayout.FlexibleSpace();
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndArea();
	}

    void SetJieBi(string money)
    {
        StateInfo.getSingleton().stateMoney.mJayBi = float.Parse(money);
    }

    void AddMoney(string money)
    {
        GameUtils.Call("incrementAchievement", "2");
        StateInfo.getSingleton().stateMoney.onValueChange(int.Parse(money), true);
    }

    void onSignInFailed(string str)
    {
        mIsLogining = false;
    }

    void onSignInSucceeded(string name)
    {
        mIsLogining = false;
        mTitle = name;
    }
}
