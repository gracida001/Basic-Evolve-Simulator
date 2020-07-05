using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class EatFood : MonoBehaviour
{
    private GameObject obj;
    int foodEated = 1;
    float i = 0;
    int timer = 1;
    public Text txt;
    public Text txt2;
    int temp = 0;
    // Start is called before the first frame update
    void Start()
    {
        txt.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        i += Time.deltaTime;
        if ((int)i == 5)
        {
            
            timer++;
            foodEated--;
            i = 0;
            txt.text = timer.ToString();
        }
        if (foodEated == 0)
        {
            Destroy(gameObject);
        }
        if (timer % 5 == 0 && temp == 0 && timer != 0 && timer != 1)
        {
            GameObject thePlayer = gameObject;
            AreaTrigger playerScript = thePlayer.GetComponent<AreaTrigger>();
            playerScript.GeneraCibo();
            temp = 1;
        }
        if (timer % 5 != 0)
        {
            temp = 0;
        }


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            var k = Random.Range(0, 20);
            if (k == 15)
            {
                GameObject thePlayer = gameObject;
                var playerScript = thePlayer.GetComponent<SearchAndMove>();
                playerScript.speed += 0.50f;
                playerScript.speedWalk += 0.50f;
                var cubeRenderer = GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color", Random.ColorHSV());
            }
            foodEated++;
        }
    }
    private Color startcolor;
    void OnMouseEnter()
    {
        GameObject thePlayer = gameObject;
        var playerScript = thePlayer.GetComponent<SearchAndMove>();
        txt2.text = playerScript.speed.ToString() + "----" + 
        playerScript.speedWalk.ToString();
        
    }


}
