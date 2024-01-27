using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Baby : MonoBehaviour
{
    public SpriteRenderer mySprite;
    public Sprite[] stateSprites;
    public Color happyColor;
    public Color sadColor;

    public float HP = 100;
    public Transform planeTarget;
    public SpriteRenderer wantBubble;

    private StationBase currentWant;
    private int currentWantIndex;

    private Difficulty GameDifficulty;
    private GameLifecycle GameLifecycle;

    private float MaxHp;
    private List<StationBase> possibleWants = new List<StationBase>();
    private float wantsTimer;

    private void Awake()
    {
        IOC.Register(this);
    }

    void Start()
    {
        GameDifficulty = IOC.Get<Difficulty>();
        GameLifecycle = IOC.Get<GameLifecycle>();

        HP = GameDifficulty.startingHP;
        MaxHp = GameDifficulty.maxHp;

        initWant();
    }

    void Update()
    {
        HP -= GameDifficulty.hpDecay * Time.deltaTime;
        // mySprite.color = Color.Lerp(sadColor, happyColor, (HP / MaxHp));
        ManageWants();

        var statestimate = Math.Max(0, Mathf.FloorToInt(((HP / MaxHp) * stateSprites.Length)));
        mySprite.sprite = stateSprites[statestimate];

        GameDifficulty.updateGameTime();
        if (HP < 0)
        {
            GameDifficulty.resetGameTime();
            GameLifecycle.LoseGame();
        }
    }

    private void initWant()
    {
        currentWantIndex = Random.Range(0, possibleWants.Count);
        currentWant = possibleWants[currentWantIndex];
        ChangeThoughtBubble();
        possibleWants.RemoveAt(currentWantIndex);

        wantsTimer = GameDifficulty.WantsChangeFrequency;
        GameDifficulty.resetGameTime();
        Debug.Log("Baby wants " + ((null == currentWant) ? "null" : currentWant.gameObject.name));
    }

    private void ManageWants()
    {
        if (wantsTimer < 0)
        {
            PickNewWant();
            Debug.Log("Baby wants " + ((null == currentWant) ? "null" : currentWant.gameObject.name));
            wantsTimer = GameDifficulty.WantsChangeFrequency;
        }
        else
        {
            wantsTimer -= Time.deltaTime;
        }
    }

    private void PickNewWant()
    {
        var oldWant = currentWant;
        currentWantIndex = Random.Range(0, possibleWants.Count);
        currentWant = possibleWants[currentWantIndex];
        ChangeThoughtBubble();
        if (currentWant == null)
        {
            Debug.Break();
        }

        possibleWants.RemoveAt(currentWantIndex);
        possibleWants.Add(oldWant);
    }

    public void AddWant(StationBase s)
    {
        Debug.Log("possible want: " + s.gameObject.name);
        possibleWants.Add(s);
    }

    public void AddHp(StationBase s, float toAdd)
    {
        // Debug.Log(String.Format("{0} adding {1} hp, wanting {2}", s.gameObject.name, toAdd, currentWant.gameObject.name));
        if (currentWant != s)
        {
            toAdd = -GameDifficulty.wrongWantFactor * toAdd;
        }

        if (HP < MaxHp)
        {
            HP += toAdd;
        }
        // Debug.Log("Current HP "+ HP);
    }

    public void PlaneHit()
    {
        if (HP < GameDifficulty.happyHpMin)
        {
            Debug.Log("plane made ouch");
            HP -= GameDifficulty.planeDamage;
        }
    }

    private void ChangeThoughtBubble()
    {
        wantBubble.sprite = currentWant.stationIcon;


        var growSize = 1.3f;
        var growDuration = 0.15f;
        Tween growTween = wantBubble.transform.DOScale(Vector3.one * growSize, growDuration);
        growTween.SetEase(Ease.OutSine);

        Sequence sequence = DOTween.Sequence()
            .Append(growTween).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutQuad);

        // Start the animation
        sequence.Play();
    }
}