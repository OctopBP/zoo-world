using System.Collections.Generic;
using UnityAttributes;
using UnityEngine;

namespace ZooWorld.Game.Gameplay
{
    public partial class FieldStorage
    {
        [PublicAccessor] private readonly List<GameObject> _units = new List<GameObject>();
    }
}