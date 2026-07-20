using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MapScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float fadeFactor = 0.2f; // 離れるごとにどれくらい暗くするか (0〜1)
    [SerializeField] private float minBrightness = 0.2f; // 最低限の明るさ（真っ黒防止）

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        // プレイヤーのZ移動イベントに登録
        Player.OnPlayerZChanged += UpdateColor;
    }

    private void OnDisable()
    {
        // オブジェクト破棄時・非アクティブ時に解除（メモリリーク防止）
        Player.OnPlayerZChanged -= UpdateColor;
    }

    // プレイヤーの新しいZ座標を受け取って色を計算
    private void UpdateColor(float playerZ)
    {
        // プレイヤーとのZ軸の距離を計算
        float distance = Mathf.Abs(transform.position.z - playerZ);

        // 距離に応じて明るさを計算（1 = 通常、距離が離れるほど暗く）
        float brightness = Mathf.Max(1.0f - (distance * fadeFactor), minBrightness);

        // スプライトの色（RGB）を変更
        spriteRenderer.color = new Color(brightness, brightness, brightness, 1.0f);
    }
}
