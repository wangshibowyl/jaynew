using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class IOSUtils {

	/* Interface to native implementation */
	[DllImport ("__Internal")]
	private static extern void _Feedback ();
	
	[DllImport ("__Internal")]
	private static extern void _ChongZhi ();
	
	
	/* Public interface for use inside C# / JS code */
	public static void Feedback()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
			_Feedback();
	}
	
	public static void ChongZhi()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
			_ChongZhi();
	}
}
