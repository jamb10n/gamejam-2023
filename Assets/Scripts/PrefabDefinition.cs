using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public struct PrefabDefinition
{
    /// <summary>
    /// Name of the prefab. 
    /// </summary>
    public string Name;

    /// <summary>
    /// Type of this entity. 
    /// </summary>
    public string Type; 

    /// <summary>
    /// The prefab. 
    /// </summary>
    public GameObject Prefab;

}

