using TMPro;
using UnityAttributes;
using UnityEngine;

namespace ZooWorld.Game.Gameplay
{
    public partial class GameUI : MonoBehaviour
    {
        [SerializeField, PublicAccessor] private TextMeshProUGUI _deadPreyCounterText;
        [SerializeField, PublicAccessor] private TextMeshProUGUI _deadPredatorsCounterText;
    }
}