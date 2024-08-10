using UnityEngine;

public class RotateTrigger : MonoBehaviour
{
    [SerializeField] private bool _isRightRotate;

    private float _speedTurn = 4f;
    private Quaternion _lookRotation;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 dir = _isRightRotate ? other.transform.right : -other.transform.right;
        _lookRotation = Quaternion.LookRotation(dir);
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 rotation = Quaternion.Lerp(other.gameObject.transform.rotation, _lookRotation, _speedTurn * Time.deltaTime).eulerAngles;
        other.gameObject.transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }
}
