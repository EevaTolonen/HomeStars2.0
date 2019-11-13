using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagingScenes : MonoBehaviour
{
    private float levelN = 1;
    private string levelName = "HomeStar";
    private string levelName2 = "WormHoleCaverns";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

   public void SetupScene()
    {
        SceneManager.LoadScene(levelName2);
    }

    public void ChangeScene()
    {
    }
}
