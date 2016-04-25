using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthBarPanel : Singleton<HealthBarPanel> {
    
    float maxhealth = 100;
    float health;
    public int mana = 0;
    public int manaMax = 3;
    public int manaUsing = 0;
    float manaRecoverTime = 2;
    public Image healthBar;
    public Image[] manaSlots; 
    private IEnumerator recoverManaCoroutine;
	
    void Awake()
    {
        healthBar.fillAmount = 1;
        mana =  manaMax;
        manaValueChanged();
        
        health = maxhealth;
    }
    
    IEnumerator recoverManaAsync() {
        while(true) {
            //execute code here.
            
            
            yield return new WaitForSeconds(manaRecoverTime);
            if(mana+manaUsing<manaMax){
                recoverMana();    
            }
            else
            {
                StopCoroutine(recoverManaCoroutine);
            }
        }
    }
    
    float tempHealth;
    
    IEnumerator recoverHealthAsync() {
        while(true) {
            //execute code here.
            if(tempHealth<health)
            Mathf.LerpAngle(tempHealth,health,Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    
    IEnumerator loseHealthAsync() {
        while(true) {
            //execute code here.
            if(tempHealth>health)
            Mathf.LerpAngle(tempHealth,health,Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    
	
    public bool modifyHealthIsAlive(float amount)
    {
        health+=amount;
        print(health);
        if(health <= 0)
        {
            health = 0;
            healthBar.fillAmount = health/maxhealth;
            return false;
        }
        else if(health >= maxhealth)
        health = maxhealth;
        healthBar.fillAmount = health/maxhealth;
        
        return true;
        
    }
    void recoverMana()
    {
        mana ++;
        manaValueChanged();
    }
    public void releaseUsingMana()
    {
        manaUsing = 0;
        recoverManaCoroutine = recoverManaAsync();
		StartCoroutine(recoverManaCoroutine);
    }
    public bool spendMana(int value)
    {
        if(mana-value>=0)
        {
            mana -= value;

            manaUsing += value;
            manaValueChanged();
            return true;
        }
        return false;
    }
    void manaValueChanged()
    {
        for(int i=0;i<3;i++)
        {
            if(i<mana)
            manaSlots[i].enabled = true;
            else
            manaSlots[i].enabled = false;
        }
    }
    
}
