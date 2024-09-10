using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas winScreen;
    public Canvas loseScreen;

    // Start is called before the first frame update
    void Awake()
    {
        if (gameObject == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinScreen()
    {
        Debug.Log("WINSCREEEEEN");
        //winScreen;
    }


}
