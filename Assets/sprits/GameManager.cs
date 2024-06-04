using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Renderer background;
    public Player player;

    void Start()
    {
        
    }

    void Update()
    {
        if (player.IsRunning())
        {
            background.material.mainTextureOffset += new Vector2(0.07f, 0) * Time.deltaTime;
        }
    }
}
