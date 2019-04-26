using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickeringLights : MonoBehaviour
{
    // Start is called before the first frame update
    private Light light;

    public float minWaitTime;
    public float maxWaitTime;

    public float minIntensity;
    public float maxIntensity;

    private float randomInstensity;
    void Start()
    {
        light = this.GetComponent<Light>();

        StartCoroutine(Flickering());
    }

    // Update is called once per frame
    IEnumerator Flickering ()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            randomInstensity = Random.Range(minIntensity, 1);
            randomInstensity *= maxIntensity;
            light.intensity = randomInstensity;
        }
    }
}
