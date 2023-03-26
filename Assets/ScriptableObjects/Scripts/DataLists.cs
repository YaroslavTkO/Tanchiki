using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapList", menuName = "Data/MapList")]
public class DataLists : ScriptableObject
{
    [SerializeField]
    private List<Map> maps = new();
    [SerializeField]
    private List<string> gameModes = new();

    public List<Map> Maps { get { return maps; } }
    public List<string> GameModes { get { return gameModes; } }



}
