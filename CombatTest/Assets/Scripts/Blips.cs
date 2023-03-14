using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blips : MonoBehaviour
{
    public Transform target;
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
        Vector2 newPosition = map.TransformPosition(target.position, new Vector3(-segme));

        myRect.localPosition = newPosition; 
    }
}
