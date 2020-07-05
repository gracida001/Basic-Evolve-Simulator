using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchAndMove : MonoBehaviour
{
    private GameObject obj;
    private Transform target;
    public float speedWalk;
    public float speed;

    Vector3 posizione;
    void Start()
    {
        posizione = new Vector3(Random.Range(-24.0f, 24.0f), 0, Random.Range(-24.0f, 24.0f));
    }
    // Update is called once per frame
    void Update()
    {
        GameObject thePlayer = gameObject;
        AreaTrigger playerScript = thePlayer.GetComponent<AreaTrigger>();
        obj = playerScript.ParameterPass;

        try
        {
            if (Vector3.Distance(transform.position, obj.transform.position) < 5f)
            {
                target = obj.transform;
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
            else
            {
                float step = speedWalk * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, posizione, step);
                if ((int)transform.position.x == (int)posizione.x && (int)transform.position.z == (int)posizione.z)
                {
                    posizione = new Vector3(Random.Range(-24.0f, 24.0f), 0.5f, Random.Range(-24.0f, 24.0f));
                }
            }
        }
        catch (System.Exception)
        {
            float step = speedWalk * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, posizione, step);
            if ((int)transform.position.x == (int)posizione.x && (int)transform.position.z == (int)posizione.z )
            {
                posizione = new Vector3(Random.Range(-24.0f, 24.0f), 0.5f, Random.Range(-24.0f, 24.0f));
            }
            return;
        }

    }
}
