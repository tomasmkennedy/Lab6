using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    private int[,] tokenGraph;

    void Start() {
        tokenGraph = new int[7,6];
    }
    public bool WinCheck(int x, int y, bool player, int winLen) {
        int color = player ? 1 : 2;
        int max, maxT, count;
        tokenGraph[x,y] = color;
        count = 0;
        // Check horizontal-right
        max = (x+winLen) > 7 ? 7 : x+winLen;
        for (int i = x+1; i < max; i++) {
            if (tokenGraph[i,y] == color) {
                count++;
            }
            else {
                break;
            }
        }
        // Check horizontal-left
        max = (x-winLen) < 7 ? 0 : x-winLen;
        for (int i = x-1; i >= max; i--) {
            if (tokenGraph[i,y] == color) {
                count++;
            }
            else {
                break;
            }
        }
        if (count >= winLen-1) {
            Debug.Log("win");
            return true;
        }
        count = 0;
        // Check vertical, you only need to check down for this
        max = (y-winLen) < 6 ? 0 : y-winLen;
        for (int i = y-1; i >= 0; i--) {
            if (tokenGraph[x,i] == color) {
                count++;
            }
            else {
                break;
            }
        }
        if (count >= winLen-1) {
            Debug.Log("win");
            return true;
        }
        count = 0;
        // Check up-right
        max = (x+winLen) > 7 ? 7 : x+winLen;
        maxT = (y+winLen) > 6 ? 6 : y+winLen;
        max = max < maxT ? max : maxT;
        for (int i = x+1, j = y+1; i < max && j < max; i++) {
            if (tokenGraph[i, j] == color) {
                count++;
            }
            else {
                break;
            }
            j++;
        }
        // Check down-left
        max = (x-winLen) < 7 ? 0 : x-winLen;
        maxT = (y-winLen) < 6 ? 0 : y-winLen;
        for (int i = x-1, j = y-1; i >= max && j >= maxT; i--) {
            Debug.Log("max: " + max + " maxT: " + maxT);
            if (tokenGraph[i, j] == color) {
                count++;
            }
            else {
                break;
            }
            j--;
        }
        if (count >= winLen-1) {
            Debug.Log("win");
            return true;
        }
        count = 0;
        // Check up-left
        max = (x-winLen) < 7 ? 0 : x-winLen;
        maxT = (y+winLen) > 6 ? 6 : y+winLen;
        for (int i = x-1, j = y+1; i >= max && j < maxT; i--) {
            if (tokenGraph[i, j] == color) {
                count++;
            }
            else {
                break;
            }
            j++;
        }
        // Check down-right
        max = (x+winLen) > 7 ? 7 : x+winLen;
        maxT = (y-winLen) < 6 ? 0 : y-winLen;
        for (int i = x+1, j = y-1; i < max && j >= maxT; i++) {
            if (tokenGraph[i, j] == color) {
                count++;
            }
            else {
                break;
            }
            j--;
        }
        if (count >= winLen-1) {
            Debug.Log("win");
            return true;
        }
        return false;
    }
}
