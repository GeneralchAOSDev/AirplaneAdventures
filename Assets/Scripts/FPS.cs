using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FPS : MonoBehaviour

{

    public int FPStarget = 60;

    void Start()

    {

        QualitySettings.vSyncCount = 1;

        Application.targetFrameRate = FPStarget;

    }

}
