using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Shotter : MonoBehaviour {

	public static void Take_Screen_Shot(string _name)
    {
        ScreenCapture.CaptureScreenshot(_name);
    }
}
