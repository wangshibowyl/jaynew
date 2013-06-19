using UnityEngine;
using System.Collections;

public class ChangeBody : MonoBehaviour 
{
    public GameObject mCurrentBody;
    public GameObject xiuxianPrefab;
    public GameObject longzhanPrefab;
    public GUISkin mSkin;
    public bool mIsLongZhanState;

    private static ChangeBody single;

    public static ChangeBody getSingleton()
    {
        return single;
    }

    private void Awake()
    {
        single = this;
    }

    public void LoadState()
    {
        mIsLongZhanState = PlayerPrefs.GetInt("mIsLongZhanState", 0) == 0 ? false : true;
        Change();
    }

    private void OnGUI()
    {
        GUI.skin = mSkin;
        GUI.depth = 6;

        GUILayout.BeginArea(new Rect(10, Screen.height * 0.9f - 100, 118, 61));
        {
            bool longzhanstate = GUILayout.Toggle(mIsLongZhanState, "", "switchbutton");
            if (longzhanstate != mIsLongZhanState)
            {
                mIsLongZhanState = longzhanstate;
                PlayerPrefs.SetInt("mIsLongZhanState", mIsLongZhanState ? 1 : 0);
                Change();
            }
            //GUILayout.Label("<color=#518497>" + (longzhanstate ? "ÁúÕ½" : "ÐÝÏÐ") + "</color>", "moneylabel");
        }
        GUILayout.EndArea();
    }

    public void Change()
    {
        int id = 0;
        if (mIsLongZhanState)
        {
            id = 1;
        }
        else
        {
            id = 0;
        }

        if (mCurrentBody)
        {
            Destroy(mCurrentBody);
        }
        if (id == 0)
        {
            mCurrentBody = Instantiate(xiuxianPrefab) as GameObject;
        }
        else if (id == 1)
        {
            mCurrentBody = Instantiate(longzhanPrefab) as GameObject;
        }
        StateInfo.getSingleton().stateWork.loadState();
        ThingWindow.getSingleton().loadThings();
        //Weapon.getSingleton().loadState();
    }
}
