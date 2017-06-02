using UnityEngine;
using UnityEngine.UI;

public class RotateWithinLimit : MonoBehaviour
{
    public float maxX;
    public float maxY;
    public float maxZ;
    public float minX;
    public float minY;
    public float minZ;

    public Text text;

    private float diffX;
    private float diffY;
    private float diffZ;

    private float xOnAwake;
    private float yOnAwake;
    private float zOnAwake;

    private void Awake()
    {
        var rotatedUp = transform.rotation * Vector3.up;
        xOnAwake = Mathf.Atan2(rotatedUp.z, rotatedUp.y) * Mathf.Rad2Deg;


        var rotatedForward = transform.rotation * Vector3.forward;
        yOnAwake = Mathf.Atan2(rotatedForward.x, rotatedForward.z) * Mathf.Rad2Deg;


        var rotatedRight = transform.rotation * Vector3.right;
        zOnAwake = Mathf.Atan2(rotatedRight.y, rotatedRight.x) * Mathf.Rad2Deg;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X)) RotateXWithInLimit();
        if (Input.GetKey(KeyCode.Y)) RotateYWithInLimit();
        if (Input.GetKey(KeyCode.Z)) RotateZWithInLimit();

        text.text = string.Format(@"
            X diff is : {0}
            Y diff is : {1}
            Z diff is : {2}
            ", diffX, diffY, diffZ);
    }

    private void RotateXWithInLimit()
    {
        var rotate = transform.localRotation * Quaternion.AngleAxis(1, Vector3.right);
        var rotatedUp = rotate * Vector3.up;
        var x = Mathf.Atan2(rotatedUp.z, rotatedUp.y) * Mathf.Rad2Deg;

        diffX = Mathf.DeltaAngle(x, xOnAwake);
        if (minX <= diffX && diffX <= maxX)
        {
            transform.rotation = rotate;
        }
    }

    private void RotateYWithInLimit()
    {
        var rotate = transform.localRotation * Quaternion.AngleAxis(1, Vector3.up);
        var rotatedForward = rotate * Vector3.forward;
        var y = Mathf.Atan2(rotatedForward.x, rotatedForward.z) * Mathf.Rad2Deg;

        diffY = Mathf.DeltaAngle(y, yOnAwake);
        if (minY <= diffY && diffY <= maxY)
        {
            transform.rotation = rotate;
        }
    }

    private void RotateZWithInLimit()
    {
        var rotate = transform.localRotation * Quaternion.AngleAxis(1, Vector3.forward);
        var rotatedRight = rotate * Vector3.right;
        var z = Mathf.Atan2(rotatedRight.y, rotatedRight.x) * Mathf.Rad2Deg;

        diffZ = Mathf.DeltaAngle(z, zOnAwake);
        if (minZ <= diffZ && diffZ <= maxZ)
        {
            transform.rotation = rotate;
        }
    }
}