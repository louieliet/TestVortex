using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blips : MonoBehaviour
{
    public Transform target;
    public bool keepInBounds = true;
    public bool LockScale = false;
    public bool LockRotation = true;
    public float MinScale = 1f;
    public float segmentOffset; 

    Minimap map;
    RectTransform myRect;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        map = GetComponentInParent<Minimap>();
        myRect = GetComponent<RectTransform>();

        
    }

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    
    private void LateUpdate()
    {
        Vector2 newPosition = map.TransformPosition(target.position, new Vector3(-segmentOffset, 0, segmentOffset));
        
        if(keepInBounds){
            newPosition = map.MoveInside(newPosition);
        }
        if(!LockScale){

            float scale = Mathf.Max(MinScale, map.ZoomLevel);
            myRect.localScale = new Vector3(scale, scale, 1);

        }
        if(!LockRotation){
            myRect.localEulerAngles = map.TransformRotation(target.eulerAngles);
        }

        //myRect.localPosition = newPosition; 
    }
}
