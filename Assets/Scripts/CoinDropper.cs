using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDropper : MonoBehaviour
{
    [SerializeField] GameObject redCoin;
    [SerializeField] GameObject yellowCoin;
    [SerializeField] GameObject parent;
    
    public void DropCoin(bool player, int column) {
        Vector3 pos = parent.transform.position + new Vector3((float)(1.077-column*.359), 6f, 0.125f);
        if (player) {
            Instantiate(redCoin, pos, Quaternion.identity);
        }
        else {
            Instantiate(yellowCoin, pos, Quaternion.identity);
        }
    }
}
