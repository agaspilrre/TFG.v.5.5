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
    public float timeRateLosingStamina = 12;

    float Stamina;
	
	// Update is called once per frame
	void Update () {       

        StaminaController();
        LoseStaminaWallJump();

        Stamina = slider.value;
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
            timerController = 0;
            if (timerWallJump > timeRateLosingStamina) 
                slider.value -= 5 * Time.deltaTime;
        }
        else
        {
            if(timerWallJump > 16)
                slider.value -= 10 * Time.deltaTime;

            timerWallJump = 0;
            losedStamina = true;            
        }      
    }

    public float GetStamina()
    {
        return Stamina;
    }
}
