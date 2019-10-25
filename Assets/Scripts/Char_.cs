using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_ : MonoBehaviour
{
    public float raylenght;
    public float tilelenght;
    public Transform thistransform;

    public void Awake() 
    {
        thistransform = transform;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            thistransform.position = new Vector3(thistransform.position.x + tilelenght, thistransform.position.y, thistransform.position.z);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            thistransform.position = new Vector3(thistransform.position.x + tilelenght, thistransform.position.y, thistransform.position.z);
        } else if (Input.GetKeyDown(KeyCode.A)) {
            thistransform.position = new Vector3(thistransform.position.x + tilelenght, thistransform.position.y, thistransform.position.z);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            thistransform.position = new Vector3(thistransform.position.x + tilelenght, thistransform.position.y, thistransform.position.z);
        }

    }

    private void Move() 
        {

    }
}
