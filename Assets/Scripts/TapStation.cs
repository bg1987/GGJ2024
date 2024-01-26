using UnityEngine;

public class TapStation : StationBase
{
    private void Update()
    {
        if (isVisited && Input.GetKeyDown(KeyCode.Space))
        {
            baby.AddHp(this, HPPerHit);
        }
    }
}