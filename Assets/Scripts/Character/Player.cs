using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Player : MonoBehaviour
{
    // Z座標が変わったことを通知するイベント
    public static event Action<float> OnPlayerZChanged;

    [SerializeField] private float layerDistance = 1.0f; // 層と層の間の距離
    public float playerbrightness = 1.0f;
    private InputAction frontlayer;
    private InputAction backlayer;

    private void Start()
    {
        // ゲーム開始時に初期位置の判定を通知して色を反映させる
        OnPlayerZChanged?.Invoke(transform.position.z);
        frontlayer = InputSystem.actions.FindAction("FrontLayer");
        backlayer = InputSystem.actions.FindAction("BackLayer");
        frontlayer.started += context => MoveLayer(layerDistance);
        backlayer.started += context => MoveLayer(-layerDistance);
    }

    private void Update()
    {
        // // Wキーで奥（または手前）の層へ移動
        // if (frontlayer.IsPressed())
        // {
            
        // }
        // // Sキーで手前（または奥）の層へ移動
        // else if (backlayer.IsPressed())
        // {
        //     MoveLayer(-layerDistance);
        // }
    }


    private void MoveLayer(float zOffset)
    {
        Vector3 newPos = this.gameObject.transform.position;
        newPos.z += zOffset;
        this.gameObject.transform.position = newPos;

        // Z座標が変わったとき、登録されているすべての層に新しいZ座標を通知
        OnPlayerZChanged?.Invoke(transform.position.z);
    }
}
