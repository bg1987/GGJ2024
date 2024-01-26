using UnityEngine;

namespace StrikeTheTarget
{
    public class Station : StationBase
    {
        [SerializeField] private Transform plane;

        // Update is called once per frame
        void Update()
        {
            if (isVisited != plane.gameObject.activeSelf)
            {
                plane.gameObject.SetActive(isVisited);
            }
        }

        public void OnStrike (bool success)
        {
            if (isVisited)
            {
                baby.AddHp(this, HPPerHit);
            }
        }
    }
}