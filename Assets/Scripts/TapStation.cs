using UnityEngine;

public class TapStation : StationBase
{
    public TapStationAnimationController anim;

    private void Update()
    {
        anim.visible = isVisited;
        if (isVisited)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.Step();
                baby.AddHp(this, HPPerHit);
            }

            shouldTap.onShouldTap(!Input.GetKeyDown(KeyCode.Space));
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        parent.ChangeColor(Color.clear);
    }
}