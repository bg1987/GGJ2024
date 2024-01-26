using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public SpriteRenderer mySprite;
    public Color happyColor;
    public Color sadColor;

    public float hpDecay = 6.6f; //about 15 seconds of idling
    public float HP = 100;
    
    //every X seconds the wants will change.
    public float wantChangeFrequency = 5;
    
    public AnimationCurve changeFrequency;
    
    public float wrongWantFactor = 2;
    
    
    private float MaxHp;
    private List<Station> possibleWants = new List<Station>();
    private int currentWantIndex;
    private float wantsTimer;
    private Station currentWant;
    
    private void Awake()
    {
        IOC.Register(this);
    }

    void Start()
    {
        MaxHp = HP;
    }

    void Update()
    {
        HP -= hpDecay * Time.deltaTime;
        mySprite.color = Color.Lerp(sadColor, happyColor, HP / MaxHp);
        ManageWants();
        if (HP < 0)
        {
            QuitGame();
        }
    }

    private void ManageWants()
    {
        if (wantsTimer < 0)
        {
            PickNewWant();
            Debug.Log("Baby wants "+ currentWant.gameObject.name);
            wantsTimer = changeFrequency.Evaluate(Time.time);
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
        possibleWants.RemoveAt(currentWantIndex);
        possibleWants.Add(oldWant);
    }

    public void AddWant(Station s)
    {
        possibleWants.Add(s);
    }

    public void AddHp(Station s, float toAdd)
    {
        if (currentWant != s)
        {
            toAdd = -wrongWantFactor * toAdd;
        }
        
        if (HP < MaxHp)
        {
            HP += toAdd;
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