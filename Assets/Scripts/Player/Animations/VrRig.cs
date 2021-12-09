using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VrRigggingParameters
{
    public Transform VrTarget;
    public Transform RigTarget;

    public Vector3 targetPositionOffset;
    public Vector3 targetRotationOffset;

    public void UpdateRigging()
    {
        RigTarget.position = VrTarget.TransformPoint(targetPositionOffset);
        RigTarget.rotation = VrTarget.rotation * Quaternion.Euler(targetRotationOffset);
    }
}
public class VrRig : MonoBehaviour
{
    public VrRigggingParameters head;
    public VrRigggingParameters leftHand;
    public VrRigggingParameters rightHand;

    [Header("Body")]
    public Transform body;
    public Vector3 headBodyOffset;
    public float bodyMovingLerpMultiplier = 3f;

    private void Update()
    {
        UpdateAllRigging();

    }
    private void UpdateAllRigging()
    {
        head.UpdateRigging();
        leftHand.UpdateRigging();
        rightHand.UpdateRigging();
        UpdateBodyRigging();
    }

    private void UpdateBodyRigging()
    {
        body.position = head.RigTarget.position + headBodyOffset;
        body.forward = Vector3.Lerp(body.forward, Vector3.ProjectOnPlane(head.RigTarget.forward, Vector3.up), Time.deltaTime * bodyMovingLerpMultiplier);
    }
}
