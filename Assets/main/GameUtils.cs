using UnityEngine;
using System.Collections;

public class GameUtils 
{
#if UNITY_EDITOR
    static public void Call(string methodName, params object[] args)
    {
        string param = "";
        foreach (object obj in args)
        {
            param += obj;
        }
        Debug.Log(methodName + " " + param);
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
    static public void Call(string methodName,params object[] args)
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
