using UnityEngine;

namespace StrikeTheTarget
{
    public class StrikerStation : StationBase
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
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            parent.ChangeColor(Color.clear);
        }

        public void OnStrike(bool success)
        {
            if (isVisited && success)
            {
                baby.AddHp(this, HPPerHit);
            }

            if (isVisited)
            {
                anim.SetTrigger("Action");
            }
        }
    }
}