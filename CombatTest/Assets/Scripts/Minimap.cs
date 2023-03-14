using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform target;
    public float ZoomLevel = 10.0f;
    public bool LockRotation = false;
    public float Width;
    public bool isSegmented;
    public float numberofSegments;
    

    Vector2 xRot = Vector2.right;
    Vector2 yRot = Vector2.up;

    private void LateUpdate()
    {
        if(!LockRotation){
            xRot = new Vector2(target.right.x, -target.right.z);
            yRot = new Vector2(-target.forward.x, target.forward.z);
        }
    }

    public Vector2 TransformPosition(Vector3 position, Vector3 nudge){

        Vector3 offset;
        if(isSegmented){
            offset = RoundPosition(position) - RoundPosition(target.position);
        }
        else{
            offset = position - target.position; 
        }
        Vector2 newPosition = offset.x * xRot;
        newPosition += offset.z * yRot;

        newPosition *= ZoomLevel;

        return newPosition;
    }

    public Vector3 TransformRotation(Vector3 rotation){

        if(LockRotation)
            return new Vector3(0,0,-rotation.y);
        else
            return new Vector3(0,0,target.eulerAngles.y - rotation.y);
    }

    public Vector3 RoundPosition(Vector3 position){
        float segmentWidth = Width / numberofSegments;
        position.x = Mathf.Ceil(position.x / segmentWidth) * segmentWidth;
        position.z = Mathf.Floor(position.z / segmentWidth) * segmentWidth;
        return position;
    }

    public Vector2 MoveInside(Vector2 point){
        Rect mapRect = GetComponent<RectTransform>().rect ;
        point = Vector2.Max(point, mapRect.min);
        point = Vector2.Min(point, mapRect.max);
        return point;
    }

}
