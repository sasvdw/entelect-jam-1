using UnityEngine;

public class InitialOrientation : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        var rotation = Random.rotation;
        rotation.x = 0;
        rotation.y = 0;
        this.transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }
}