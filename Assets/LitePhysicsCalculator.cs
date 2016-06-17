using UnityEngine;
using System.Collections;

public static class LitePhysicsCalculator {

  public static LiteCastHit LineCast(LiteCollider col, Vector3 start, Vector3 end) {

    // todo: implement

    return new LiteCastHit() {
      isHit = false, go = null, normal = Vector3.right, point = Vector3.one
    };

  }

}
