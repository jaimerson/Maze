using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject lightObject;
    private Light light;
    public GameManager game;

    // Start is called before the first frame update
    void Start()
    {
        this.light = lightObject.GetComponent<Light>();
        this.light.intensity = game.currentLevel;
        this.light.range += game.currentLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if(game.secondsLeft < 10){
            this.light.color = Color.red;
        }
    }
}
