using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Level",menuName = "Scriptable Objects/Level",order =0)]



public class LevelSO : ScriptableObject //this is not an object, so the class is different
{
    public Chunk[] chunks;    
}
