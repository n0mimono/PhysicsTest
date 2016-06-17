using UnityEngine;
using System.Collections;

public static class LitePhysics {

  public static LiteCastHit LineCast(Vector3 start, Vector3 end, int layerMask) {
    return LitePhysicsManager.Instance.LineCast(start, end, layerMask);
  }

  public static LiteCastHit LineCast(Vector3 start, Vector3 end) {
    return LitePhysicsManager.Instance.LineCast(start, end, -1);
  }

  public static void Initialize() {
    LitePhysicsManager.Instance.Initialize();
  }

}

public class LitePhysicsManager : MonoBehaviour {
  
  private static LitePhysicsManager instance;
  public static LitePhysicsManager Instance {
    get {
      if (instance == null) {
        instance = GameObject.FindObjectOfType<LitePhysicsManager>();
      }
      if (instance == null) {
        GameObject go = new GameObject(typeof(LitePhysicsManager).Name);
        instance = go.AddComponent<LitePhysicsManager>();
      }
      return instance;
    }
  }

  [SerializeField] private LiteColliderCluster[] clusters;

  public void Initialize() {
    clusters = GameObject.FindObjectsOfType<LiteColliderCluster>();
    for (int i = 0; i < clusters.Length; i++) {
      clusters[i].Initialize();
    }
  }

  public LiteCastHit LineCast(Vector3 start, Vector3 end, int layerMask) {

    for (int i = 0; i < clusters.Length; i++) {
      LiteColliderCluster cluster = clusters[i];

      if (layerMask > -1 && ((1 << cluster.Layer & layerMask) == 0)) {
        continue;
      }

      if (cluster.RoughLineCast(start, end)) {
        LiteCastHit hit = cluster.LineCast(start, end);
        if (hit.isHit) {
          return hit;
        }
      }
    }

    return new LiteCastHit() {
      isHit = false, go = null, normal = Vector3.right, point = Vector3.one
    };
  }

}

public struct LiteCastHit {
  public bool       isHit;
  public GameObject go;
  public Vector3    normal;
  public Vector3    point;
}
