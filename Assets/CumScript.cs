using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CumScript : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[5];
    public Image bankaebat;
    public GameObject filled;
    public Animator animator;
    public GameObject bottle;
    public GameObject cameraObj;
    public GameObject backButton;
    public Material material;

    
    public void ChangeBanka(float sliderVal)
    {
        backButton.SetActive(true);
        cameraObj.transform.position = new Vector3(bottle.transform.position.x, bottle.transform.position.y, -2);
        Camera.main.orthographicSize = 2;

        animator.enabled = true;
        animator.Play("BankaShuffle");

        filled.SetActive(false);
        float value = Mathf.Lerp(0, 100, sliderVal);
        if (value <= 0)
        {
            
            bankaebat.sprite = sprites[0];
        }
        else if (value > 0 && value < 15)
        {
            
            bankaebat.sprite = sprites[1];
        }
        else if (value > 15 && value < 30)
        {
            
            bankaebat.sprite = sprites[2];
        }
        else if (value > 30 && value < 100)
        {
            
            bankaebat.sprite = sprites[3];
        }
        else if (value >= 100)
        {
            
            bankaebat.sprite = sprites[4];
            filled.SetActive(true);

        }
                StartCoroutine(Timer(1, () => { animator.enabled = false; this.transform.localScale = new Vector3(1, 1, 1); }));
        
    }

    public void getSmaller()
    {
        
        cameraObj.transform.position = new Vector3(0, 0, -10);
        Camera.main.orthographicSize = 5;
    }

    IEnumerator Timer(float time, System.Action action)
    {
        while(time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        
            action();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
