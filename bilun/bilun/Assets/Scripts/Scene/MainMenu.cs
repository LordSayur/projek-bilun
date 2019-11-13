using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    
    private Animator anim;
    private SceneLoader scene;

    private void Start() {
        anim = GetComponent<Animator>();
        scene = GetComponent<SceneLoader>();

    }

    public void StartGame() {
        anim.SetBool("StartGame", true);
        scene.LoadScene(1);

    }

    public void ExitGame() {
        Application.Quit();
    }

}
