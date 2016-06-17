using UnityEngine;
using System.Collections;

public class LiteColliderCluster : MonoBehaviour {
  [SerializeField]
  private Transform      trans;
  [SerializeField]
  private int            layer;
  [SerializeField]
  private LiteCollider[] colliders;

  public int Layer {
    get {
      return layer;
    }
  }

  public void Initialize() {

    colliders = GetComponentsInChildren<LiteCollider>();
    for (int i = 0; i < colliders.Length; i++) {
      LiteCollider col = colliders[i];
      col.Initialize();
    }

    trans = GetComponent<Transform>();
    layer = colliders[0].Layer;
  }


  public bool RoughLineCast(Vector3 start, Vector3 end) {
    // todo: implement
    return true;
  }

  public LiteCastHit LineCast(Vector3 start, Vector3 end) {

    for (int i = 0; i < colliders.Length; i++) {
      LiteCastHit hit = colliders[i].LineCast(start, end);
      if (hit.isHit) {
        return hit;
      }
    }

    return new LiteCastHit() {
      isHit = false, go = null, normal = Vector3.right, point = Vector3.one
    };
  }


}
