using UnityEngine;

public class TapStation : StationBase
{
    private void Update()
    {
        if (isVisited)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                baby.AddHp(this, HPPerHit);
            }

            shouldTap.onShouldTap(!Input.GetKeyDown(KeyCode.Space));
        }
    }
}