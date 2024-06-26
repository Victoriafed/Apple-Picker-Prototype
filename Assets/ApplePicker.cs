using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject       baskedPrefab;
    public int              numBasket = 3;
    public float            basketBottomY = -14f;
    public float            basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start() {
        basketList = new List<GameObject>();
        for (int i=0; i<numBasket; i++) {
            GameObject tBasketGo = Instantiate<GameObject>(baskedPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
    }

    public void AppleDestroyed() {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray) {
            Destroy(tGO);
        }

        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if (basketList.Count == 0) {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
