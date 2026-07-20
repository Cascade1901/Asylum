using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Player : MonoBehaviour
{
    // Z座標が変わったことを通知するイベント
    public static event Action<float> OnPlayerZChanged;

    [SerializeField] private float layerDistance = 2.0f; // 層と層の間の距離
    private InputAction frontlayer;
    private InputAction backlayer;

    private void Start()
    {
        // ゲーム開始時に初期位置の判定を通知して色を反映させる
        OnPlayerZChanged?.Invoke(transform.position.z);
        frontlayer = InputSystem.actions.FindAction("FrontLayer");
        backlayer = InputSystem.actions.FindAction("BackLayer");
    }

    private void Update()
    {
        // Wキーで奥（または手前）の層へ移動
        if (frontlayer.IsPressed())
        {
            MoveLayer(layerDistance);
        }
        // Sキーで手前（または奥）の層へ移動
        else if (backlayer.IsPressed())
        {
            MoveLayer(-layerDistance);
        }
    }

    private void MoveLayer(float zOffset)
    {
        Vector3 newPos = transform.position;
        newPos.z += zOffset;
        transform.position = newPos;

        // ★Z座標が変わったときだけ、登録されているすべての層に新しいZ座標を通知！
        OnPlayerZChanged?.Invoke(transform.position.z);
    }
}
