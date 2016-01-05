using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    Transform skillBtn;
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        skillBtn = transform.Find("skillbtn");
    }

    public void hideAllUI()
    {
        skillBtn.gameObject.SetActive(false);
    }

    public  void showAllUI()
    {
        skillBtn.gameObject.SetActive(true);
    }
}
