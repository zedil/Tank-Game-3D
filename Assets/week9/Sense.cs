using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sense : MonoBehaviour, ISense
{
    
    //playerın transform bileşeni lazım.
    protected Transform player { get {return FindObjectOfType<playerTank>().transform;}}
    protected Animator fsm {get {return GetComponent<Animator>();}}
    public abstract void InitializeSense();
    public abstract void UpdateSense();
    // Start is called before the first frame update
    void Start()
    {
        InitializeSense();
    }


    float delay;
    float freq = 20f;
    // Update is called once per frame
    void Update()
    {
        if ((delay += Time.deltaTime) > 1f/freq)
        {
            UpdateSense();
            delay = 0;
        }
        
    }
}
