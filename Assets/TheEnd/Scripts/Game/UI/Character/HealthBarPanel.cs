using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthBarPanel : MonoBehaviour {

    int health;
    int mana = 0;
    public Image healthBar;
    public Image[] manaSlots; 
    private IEnumerator recoverManaCoroutine;
	
    
    
    IEnumerator recoverManaAsync() {
        while(true) {
            //execute code here.
            if(mana<3)
            recoverMana();
            yield return new WaitForSeconds(1);
        }
    }
	void Awake()
    {
        healthBar.fillAmount = 1;
        mana = 3;
        manaValueChanged();
        
        //recoverManaCoroutine = recoverManaAsync();
		//StartCoroutine(recoverManaCoroutine);
    }
    
    void recoverMana()
    {
        mana ++;
        manaValueChanged();
    }
    void spendMana(int value)
    {
        mana -= value;
        manaValueChanged();
    }
    void manaValueChanged()
    {
        for(int i=0;i<3;i++)
        {
            manaSlots[i].enabled = false;
        }
        for(int i=0;i<mana;i++)
        {
            manaSlots[i].enabled = true;
        }
    }
    
}
