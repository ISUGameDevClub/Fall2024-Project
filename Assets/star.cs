using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class star : MonoBehaviour
{
    public int fame;
    float scaleVal;
    [SerializeField] int starNum;
    public GameObject thisStar;
    float scale_increment = .25f / 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fame = YIP.instance.GetFame();
        if ((fame > (starNum * 100 - 100)) && (fame < (starNum * 100))){
            scaleVal = (scale_increment * (fame % 100));
            thisStar.transform.localScale = new Vector3(scaleVal, scaleVal, 1.0f);
        }
        else if (fame >= (starNum * 100))
        {
            thisStar.transform.localScale = new Vector3(.25f, .25f, 1.0f);
        }
        else
        {
            thisStar.transform.localScale = new Vector3(0f, 0f, 1.0f);
        }
    }
}
