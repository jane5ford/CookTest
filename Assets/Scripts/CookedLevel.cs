using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedLevel : MonoBehaviour
{
    private int level;
    private int size;
    private bool on = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setLevel(int level) { this.level = level; }
    public void setSize(int size) { this.size = size; }
    public int getLevel() { return this.level; }
    public int getSize() { return this.size; }
    public void turnOn(bool on) { this.on = on; }
    public bool isTurn() { return this.on; }
}
