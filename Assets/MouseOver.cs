using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MouseOver : MonoBehaviour
{
    SpriteRenderer button;
    Sprite sprite;
    Sprite sprite2;
    public AudioSource soundsource;

    void Start(){
        button = gameObject.GetComponent<SpriteRenderer>();
        sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        sprite2 = Resources.Load<Sprite>("selectedoption");
    }

    void OnMouseEnter()
    {
        soundsource.Play();
    }

    void OnMouseOver(){
        button.sprite = sprite2;
    }
    public void StartGame()
    {
        //Debug.Log("no");
        SceneManager.LoadScene(1);
    }
    public void ExitGame()    
    {
        //Debug.Log("yes");
        Application.Quit();
    }
    void OnMouseExit() {
        button.sprite = sprite;
    }
}
