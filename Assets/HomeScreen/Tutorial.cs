using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
    int scene = 0;
    static bool done = false;

    void Start() {
        if (done) {
            GameObject.Find("0").SetActive(false);
        }
    }

    void Update() {
        if (!done) {
            if (Input.GetKeyDown(KeyCode.N)) {
                GameObject.Find(scene.ToString()).SetActive(false);
                scene += 1;
                if (scene <= 7) {
                    GetChildWithName(gameObject.transform.parent.gameObject, scene.ToString()).SetActive(true);
                } else {
                    done = true;
                }
            } else if (Input.GetKeyDown(KeyCode.Q)) {
                done = true;
                GameObject.Find(scene.ToString()).SetActive(false);
            }
        }
    }

     GameObject GetChildWithName(GameObject obj, string name) {
            Transform trans = obj.transform;
            Transform childTrans = trans. Find(name);
            if (childTrans != null) {
                return childTrans.gameObject;
            } else {
                return null;
            }
    }

}

