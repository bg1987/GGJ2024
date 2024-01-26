using UnityEngine;

namespace HomeRun
{
    public class HomerStation : StationBase
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

            if (isVisited)
            {
                shouldTap.onShouldTap(true);
            }
        }

        public void OnRelease(bool legal)
        {
            if (isVisited)
            {
                baby.AddHp(this, HPPerHit);
            }
        }
    }
}