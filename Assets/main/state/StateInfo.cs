using UnityEngine;
using System.Collections;
using System;

public enum ROLESTATE
{
	RS_HEALTH,
	RS_SICK,
	RS_DEAD,
}

public class StateInfo : MonoBehaviour 
{
	public StateMoney stateMoney;
    public StateExp stateExp;
    public StateHealth stateHealth;
    public StateBase stateHunger;
    public StateBase stateThirst;
	public StateBase statePower;
    public StateWork stateWork;
	
	private StateBase[] mStateBases;
	
	public int mLevel;
	public DateTime mLastStateUpdateTime;
    public const int STATE_UPDATE_SECONDS_NORMAL = 300;
    public const int STATE_UPDATE_SECONDS_SLEEP = 600;
    public int stateUpdateSeconds = STATE_UPDATE_SECONDS_NORMAL;
	public bool needSaveState;
	public ROLESTATE mRoleState;

    private bool mbIgnoreFocus = true;
	
	private static StateInfo single;
	
	public static StateInfo getSingleton()
	{
		return single;
	}
	
	private void Awake()
	{
		single = this;
		mStateBases = GetComponents<StateBase>();
		//CSVReader.OnInitCSV();
	}

    private void Start()
    {
        LoadState();
        mbIgnoreFocus = false;
    }
	
	private void LoadState()
    {
		mLevel = PlayerPrefs.GetInt("level", 0);
        mLastStateUpdateTime = new DateTime(long.Parse(PlayerPrefs.GetString("lastStateUpdateTime", "0")));
		
		foreach(StateBase stateBase in mStateBases)
		{
			stateBase.loadState();
		}

        //Lajis.loadState();
        //mJayState = PlayerPrefs.GetInt("mJayState", 0);
        GetStartState();
        ThingWindow.getSingleton().loadThings();
        Weapon.getSingleton().loadState();
    }
	
	private void SaveState()
    {
        PlayerPrefs.SetInt("level", mLevel);
        PlayerPrefs.SetString("lastStateUpdateTime", mLastStateUpdateTime.Ticks.ToString());
		
		foreach(StateBase stateBase in mStateBases)
		{
			stateBase.saveState();
		}
		
        //PlayerPrefs.SetString("mLajis", Lajis.mLajis);
        //PlayerPrefs.SetInt("mJayState",mJayState);
        needSaveState = false;
    }
	
	public void ResetState()
	{
		PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
#if UNITY_IOS
		GameSocial.Instance.ResetAchievements();
#endif
        //needSaveState = true;
		LoadState();
	}
	
	private void OnApplicationFocus(bool focus)
    {
        if (focus && !mbIgnoreFocus)
        {
            GetStartState();
        }
    }

    private void OnApplicationQuit()
    {
        SaveState();
    }

    private void GetStartState()
    {
        if (mLastStateUpdateTime.Ticks != 0)
        {
            int cutTimes = Mathf.FloorToInt((float)(DateTime.Now - mLastStateUpdateTime).TotalSeconds / stateUpdateSeconds);
            mLastStateUpdateTime = mLastStateUpdateTime.AddSeconds(stateUpdateSeconds * cutTimes);
            while(cutTimes >0 && mRoleState != ROLESTATE.RS_DEAD)
            {
                UpdateState(false);
				cutTimes--;
            }
        }
        //Lajis.updateAll(this);
        //SayMap.checkSayMapState();
        SaveState();
    }

    private void UpdateState(bool genObj)
    {
        if (mRoleState != ROLESTATE.RS_DEAD)
        {
            foreach(StateBase stateBase in mStateBases)
			{
				stateBase.onCutPerTime();
			}
            //if (genObj && characterAnimator)
            //{
            //    if ((lastStateUpdateTime - hejiuTime).TotalSeconds < 30)
            //    {
            //        float color = (float)(lastStateUpdateTime - hejiuTime).TotalSeconds / 30;
            //        characterAnimator.renderer.materials[2].color = new Color(1, color, color);
            //    }
            //}
            //Lajis.addLajiChar(this, genObj);
            //if (genObj)
            //{
            //    SayMap.checkSayMapState();
            //}
            needSaveState = true;
        }
    }
	
	private void Update()
    {
        if (needSaveState)
        {
            SaveState();
        }
        if ((DateTime.Now - mLastStateUpdateTime).TotalSeconds > stateUpdateSeconds)
        {
            mLastStateUpdateTime = DateTime.Now;
            UpdateState(true);
        }
    }

    public void BeginSleep()
    {
        stateUpdateSeconds = STATE_UPDATE_SECONDS_SLEEP;
    }

    public void EndSleep()
    {
        stateUpdateSeconds = STATE_UPDATE_SECONDS_NORMAL;
    }
}