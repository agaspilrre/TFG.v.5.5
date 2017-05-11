using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCameraBlock : MonoBehaviour {

    public bool blockMov;

    public Camera cam;
    camaraMOV camMov;

    Player jugador;

    public enum BlockPosition { Right, Left };

    public BlockPosition BP;

    // Use this for initialization
    void Start ()
    {
        camMov = cam.GetComponent<camaraMOV>();
        jugador = GameObject.Find("Personaje").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(blockMov)
        {
            if(jugador.transform.position.x < this.transform.position.x && BP == BlockPosition.Left && jugador.getDireccion() == 0)
            {
                camMov.SetBlock(true);
            }
            else if(jugador.transform.position.x > this.transform.position.x && BP == BlockPosition.Right && jugador.getDireccion() == 1)
            {
                camMov.SetBlock(true);
            }
            else
            {
                camMov.SetBlock(false);
            }
        }		
	}

    public void SetBlockMov(bool move)
    {
        blockMov = move;
    }
}
