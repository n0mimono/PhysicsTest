using UnityEngine;
using System.Collections;

public class TestCaster : MonoBehaviour {
  public float distance;

  void Start() {
    LitePhysics.Initialize();
  }

  [ContextMenu("Cast")]
  public void Cast() {
    Vector3 start = transform.position;
    Vector3 end   = transform.position + transform.forward * distance;

    LiteCastHit hit = LitePhysics.LineCast(start, end);
    Debug.Log(hit.isHit);

  }

}
