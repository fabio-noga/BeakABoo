using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI text;
    public TextMeshProUGUI texttimer;
    [SerializeField]
    private TextMeshProUGUI yourscore;
    public float timer;
    private GameObject popup;
    private GameObject popupend;
    private int currentSceneIndex;

    void Awake()
    {
        popupend = GameObject.Find("popupend");
        popup = GameObject.Find("popup");
        popupend.SetActive(false);
        popup.SetActive(true);
        StartCoroutine(Popup());
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        text.text = (score.ToString());
        texttimer.text = ((int) timer).ToString();

        if (timer <= 0)
        {
            Time.timeScale = 0;
            popupend.SetActive(true);
            yourscore.text = "Your Score was: " + score;
            StartCoroutine(Reload());
        }
    }

    IEnumerator Popup()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1;
        popup.SetActive(false);
        yield break;
    }
    IEnumerator Reload()
    {
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene(currentSceneIndex);
        yield break;
    }
}
