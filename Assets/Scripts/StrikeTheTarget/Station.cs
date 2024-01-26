using UnityEngine;

namespace StrikeTheTarget
{
    public class Station : StationBase
    {
        [SerializeField] private Transform plane;

        void Start()
        {
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
            if (isVisited)
            {
                baby.AddHp(this, HPPerHit);
            }
        }
    }
}