using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Map
{
    [SerializeField]
    private string name = "";
    [SerializeField]
    private Sprite spriteForMenu;

    public string Name { get { return name; } }
    public Sprite SpriteForMenu { get { return spriteForMenu; } }

}
