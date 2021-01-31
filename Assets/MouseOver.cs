using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MouseOver : MonoBehaviour
{
    SpriteRenderer button;
    Sprite sprite;
    Sprite sprite2;

    void Start(){
        button = gameObject.GetComponent<SpriteRenderer>();
        sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        sprite2 = Resources.Load<Sprite>("selectedoption");
    }
    void OnMouseOver(){
        button.sprite = sprite2;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void OnMouseExit() {
        button.sprite = sprite;
    }
}
