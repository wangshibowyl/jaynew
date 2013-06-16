using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
    private static Weapon single;
    private GameObject mWeaponObj;

    public static Weapon getSingleton()
    {
        return single;
    }

    private void Awake()
    {
        single = this;
    }

    public void loadState()
    {
        onDestroyWeapon();
    }

    public void changeWeapon(string weaponStr,float deleteTime)
    {
		CancelInvoke();
        if (mWeaponObj)
        {
            Destroy(mWeaponObj);
        }
        mWeaponObj = Instantiate(Resources.Load("weapon/" + weaponStr + "/obj")) as GameObject;
        Vector3 orgPosition = mWeaponObj.transform.localPosition;
        Quaternion orgRotation = mWeaponObj.transform.localRotation;
        Vector3 orgScale = mWeaponObj.transform.localScale;
        mWeaponObj.transform.parent = BodyTouch.getSingleton().mWeaponPoint;
        mWeaponObj.transform.localPosition = orgPosition;
        mWeaponObj.transform.localRotation = orgRotation;
        mWeaponObj.transform.localScale = orgScale;
        if (deleteTime > 0)
        {
            Invoke("onDestroyWeapon", deleteTime);
        }
    }

    public void onDestroyWeapon()
    {
        if (mWeaponObj)
        {
            Destroy(mWeaponObj);
        }
        if (StateInfo.getSingleton().stateWork.getIsWorking())
        {
            int workType = StateInfo.getSingleton().stateWork.getWorkType();
            if (workType != -1)
            {
                string obj = CSVReader.getString("work", workType.ToString(), "weapon");
                if (obj != "0")
                {
                    changeWeapon(obj, 0);
                }
            }
        }
    }
}
