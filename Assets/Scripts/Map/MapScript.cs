using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(SpriteRenderer))]
public class MapScript : MonoBehaviour
{
    private Tilemap tilemap;
    private TilemapCollider2D tilemapCollider;
    [SerializeField] private float fadeFactor = 0.2f; // 離れるごとにどれくらい暗くするか (0〜1)
    [SerializeField] private float minBrightness = 0.2f; // 最低限の明るさ（真っ黒防止）

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapCollider = GetComponent<TilemapCollider2D>();
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
        // プレイヤーとZ軸が一致しているタイルマップのコライダーだけ作動させる
        if (tilemapCollider != null)
        {
            tilemapCollider.enabled = Mathf.Approximately(transform.position.z, playerZ);
        }

        // プレイヤーとのZ軸の距離を計算
        float distance = transform.position.z - playerZ;


        // 距離に応じて明るさを計算（1 = 通常、距離が離れるほど暗く）
        float brightness = Mathf.Max(1.0f - (distance* 0.5f * fadeFactor), minBrightness);
        if(brightness > 1.0f)
        {
            this.gameObject.GetComponent<TilemapRenderer>().enabled = false;
        }
        else
        {
            // スプライトの色（RGB）を変更
            this.gameObject.GetComponent<TilemapRenderer>().enabled = true;
            tilemap.color = new Color(brightness, brightness, brightness, 1.0f);
        }

        
        
    }
}
