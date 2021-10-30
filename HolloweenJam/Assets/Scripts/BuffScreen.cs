using UnityEngine;

public class BuffScreen : MonoBehaviour
{
    [SerializeField] Vector3[] positions;

    UIPositionLerp positionLerp;

    void Awake () {
        MakeReferences();
    }

    void MakeReferences () {
        positionLerp = GetComponent<UIPositionLerp>();
    }

    public void Activate () {
        positionLerp.SetTargetPosition(positions[1]);
    }

    public void Deactive () {
        InputManager.actions.Default.Enable();
        UIManager.instance.EnableHUDPanel();
        positionLerp.SetTargetPosition(positions[0]);
    }
}
