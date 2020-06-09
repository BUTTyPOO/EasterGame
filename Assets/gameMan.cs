using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameMan : MonoBehaviour
{
    public int currentLvl = 0; //what level is player on
    public static gameMan instance = null;
    public bool inHeaven = false;
    public bool pauseToggle;
    GameObject menu;
    public GameObject egg;
    public control ctrlScr;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        menu = gameObject.transform.GetChild(0).gameObject;
    }
    void Update() 
    {
        pauseMenu();
        if(Input.GetKeyDown(KeyCode.R))
        {
            restartLvl();
        }
    }
    public void startGame()
    {

        currentLvl = 0;
        SceneManager.LoadScene("lvl" + currentLvl);
        easterSoundMan.instance.playMainLoop();
        StartCoroutine("getEggs");
        //egg = GameObject.Find("player");
        //ctrlScr = egg.GetComponent<control>();
    }
    public void death()
    {
        ctrlScr.canInput = false;
        ctrlScr.shatter();
        easterSoundMan.instance.playEggDeathNoise();
        StartCoroutine("deathTimer");
    }
    void pauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseToggle = !pauseToggle;
            menu.SetActive(pauseToggle);
            Cursor.visible = pauseToggle;
        }
    }
    public void restartLvl()
    {
        //cancel coroutines
        StopCoroutine("deathTimer");
        SceneManager.LoadScene("lvl"+ currentLvl);
        easterSoundMan.instance.playMainLoop();
        StartCoroutine("getEggs");
    }
    public void quitGame()
    {
        Debug.Log("quiting");
        Application.Quit();
    }
    public IEnumerator deathTimer()
    {
        easterSoundMan.instance.playEggDeathNoise();
        //egg shatter
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("heaven");
        easterSoundMan.instance.playHeavenMusic();
    }
    public void youWon()
    {
        easterSoundMan.instance.playWinMusic();
        SceneManager.LoadScene("YouWon");
    }
    IEnumerator getEggs()
    {
        yield return new WaitForSeconds(0.5f);
        egg = GameObject.Find("player");
        ctrlScr = egg.GetComponent<control>();
    }
}
