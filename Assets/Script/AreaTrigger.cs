using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AreaTrigger : MonoBehaviour
{
    public Text txt;
    public float lookRadius = 10f;
    GameObject[] Tags;
    private GameObject object1;
    public GameObject ParameterPass { get; set; }
    public GameObject myPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GeneraCibo();
    }

    public void GeneraCibo()
    {
        for (int i = 0; i < 7; i++)
        {
            Vector3 up = new Vector3(0, 2, 0);
            Vector3 position = new Vector3(Random.Range(-24.0f, 24.0f), 5, Random.Range(-24.0f, 24.0f));
            if (Physics.Raycast(position + new Vector3(0, 100.0f, 0), Vector3.down, out RaycastHit hit, 200.0f))
            {
                GameObject b = Instantiate(myPrefab, hit.point + up, Quaternion.identity);
                b.name = "cibo" + i;
            }
            else
            {
                Debug.Log("there seems to be no ground at this position");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        Tags = GameObject.FindGameObjectsWithTag("Food");
        txt.text = (Tags.Length).ToString();

        foreach (var item in Tags)
        {
            
            if (Vector3.Distance(transform.position, item.transform.position) < lookRadius)
            {
                float lowestDist = Mathf.Infinity;


                for (int i = 0; i < Tags.Length; i++)
                {

                    float dist = Vector3.Distance(Tags[i].transform.position, transform.position);

                    if (dist < lowestDist)
                    {
                        lowestDist = dist;
                        object1 = Tags[i];
                        ParameterPass = object1;
                    }
                }
            }


        }

    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
