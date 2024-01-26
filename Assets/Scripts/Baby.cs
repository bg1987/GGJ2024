using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public SpriteRenderer mySprite;
    public Color happyColor;
    public Color sadColor;

    public float HP = 100;

    public Difficulty GameDifficulty;

    private StationBase currentWant;
    private int currentWantIndex;


    private float MaxHp;
    private List<StationBase> possibleWants = new List<StationBase>();
    private float wantsTimer;

    private void Awake()
    {
        IOC.Register(this);
    }

    void Start()
    {
        HP = GameDifficulty.startingHP;
        MaxHp = GameDifficulty.maxHp;

        initWant();
    }

    void Update()
    {
        HP -= GameDifficulty.hpDecay * Time.deltaTime;
        mySprite.color = Color.Lerp(sadColor, happyColor, HP / MaxHp);
        ManageWants();
        if (HP < 0)
        {
            QuitGame();
        }
    }

    private void initWant()
    {
        currentWantIndex = Random.Range(0, possibleWants.Count);
        currentWant = possibleWants[currentWantIndex];
        possibleWants.RemoveAt(currentWantIndex);

        wantsTimer = GameDifficulty.WantsChangeFrequency;
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
        if (currentWant != s)
        {
            toAdd = -GameDifficulty.wrongWantFactor * toAdd;
        }

        if (HP < MaxHp)
        {
            HP += toAdd;
        }
    }

    public void PlaneHit()
    {
        if (HP < GameDifficulty.happyHpMin)
        {
            HP -= GameDifficulty.planeDamage;
        }
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}