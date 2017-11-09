using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabilityBar : MonoBehaviour {

    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;
    public Slider slider;
    private bool losedStamina;
    private float timerController;
    public float timerWaitCharge = 200f;
    public float timerWallJump = 0;
    public bool isWallJumping = false;   

    // Use this for initialization
    void Start () {    
		
	}
	
	// Update is called once per frame
	void Update () {       

        StaminaController();
        LoseStaminaWallJump();

    }

    public void LoseStamina()
    {
        slider.value -= 25;
        losedStamina = true;
        timerController = 0;
    }

    public void StaminaController()
    {
        if (losedStamina)
            timerController++;

        if (timerController >= timerWaitCharge && slider.value < 100)
        {
            slider.value += speed * Time.deltaTime;           
        }

        if (slider.value == 100)
        {
            losedStamina = false;
            timerController = 0;
        }        
    }

    public void LoseStaminaWallJump()
    {
        if (isWallJumping)
        {
            timerWallJump++;

            if (timerWallJump > 100) 
                slider.value -= 5 * Time.deltaTime;
        }
        else
        {
            timerWallJump = 0;
            losedStamina = true;
        }
            
    }
}
