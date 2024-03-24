using UniRx;
using UnityEngine;

namespace ZooWorld.Game.Units.Views
{
    public class UnitView : MonoBehaviour
    {
        public readonly Subject<Collision> OnCollisionEnterSubj = new Subject<Collision>();

        private void OnCollisionEnter(Collision other)
        {
            OnCollisionEnterSubj.OnNext(other);
        }
    }
}