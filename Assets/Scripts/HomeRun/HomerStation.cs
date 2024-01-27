using UnityEngine;

namespace HomeRun
{
    public class HomerStation : StationBase
    {
        [SerializeField] private Transform plane;
        [SerializeField] private Animator anim;

        protected override void Start()
        {
            base.Start();
            this.HPPerHit = gameDifficulty.strikerHpPerHit;
        }

        void Update()
        {
            anim.SetBool("Visited", isVisited);
            if (isVisited != plane.gameObject.activeSelf)
            {
                plane.gameObject.SetActive(isVisited);
            }

            if (isVisited)
            {
                shouldTap.onShouldTap(true);
                anim.SetBool("Held", Input.GetKey(KeyCode.Space));
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