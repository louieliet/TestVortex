using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //hola
    //te amo guapa
    //Yo tambien te quiero emi
    //aaaaah
    // Start is called before the first frame update
    private float horizontalInput;
    private float verticalInput;
    public float speedInput;
    // Update is called once per frame
    //olapancito
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * speedInput);
        

        
    }
}
