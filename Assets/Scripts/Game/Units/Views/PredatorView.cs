using TMPro;
using UnityAttributes;
using UnityEngine;

namespace ZooWorld.Game.Units.Views
{
    public partial class PredatorView : MonoBehaviour
    {
        [SerializeField, PublicAccessor] private TextMeshProUGUI _text;
    }
}