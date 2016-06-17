using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(BoxCollider))]
public class LiteCollider : MonoBehaviour {
  [SerializeField]
  private Transform trans;
  [SerializeField]
  private int layer;

  [Serializable]
  public struct OriginBox {
    public Vector3 center;
    public Vector3 size;
  }
  private OriginBox originBox;

  public Vector3 Position {
    get {
      return trans.position + Vector3.Scale(originBox.center, trans.localScale);
    }
  }
  public Vector3 Size {
    get {
      return Vector3.Scale(originBox.size, trans.localScale);
    }
  }
  public Vector3 Angles {
    get {
      return trans.eulerAngles;
    }
  }
  public int Layer {
    get {
      return layer;
    }
  }

  public void Initialize() {
    trans = GetComponent<Transform>();
    layer = gameObject.layer;

    BoxCollider box = GetComponent<BoxCollider>();
    originBox = new OriginBox() { center = box.center, size = box.size };
    box.enabled = false;
  }

  public LiteCastHit LineCast(Vector3 start, Vector3 end) {
    return LitePhysicsCalculator.LineCast(this, start, end);
  }

}
