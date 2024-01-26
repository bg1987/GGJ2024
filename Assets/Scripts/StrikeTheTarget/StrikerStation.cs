using UnityEngine;

namespace StrikeTheTarget
{
    public class StrikerStation : StationBase
    {
        [SerializeField] private Transform plane;

        protected override void Start()
        {
            base.Start();
            this.HPPerHit = gameDifficulty.strikerHpPerHit;
        }

        void Update()
        {
            if (isVisited != plane.gameObject.activeSelf)
            {
                plane.gameObject.SetActive(isVisited);
            }
        }

        public void OnStrike(bool success)
        {
            if (isVisited && success)
            {
                baby.AddHp(this, HPPerHit);
            }
        }
    }
}