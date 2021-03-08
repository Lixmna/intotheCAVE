using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Mainmenu : MonoBehaviour
{
    Vector3 scale = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("03 지도");
    }

    public void QuitGame()
    {

        Application.Quit();
    }
}

