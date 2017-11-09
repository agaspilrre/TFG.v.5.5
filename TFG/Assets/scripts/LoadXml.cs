using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//Si incluyes una variable public y la insertas no es necesario hacer getcomponent luego.
public class LoadXml : MonoBehaviour {

	public string path="items";

	public List<string> dialogo1= new List<string>();
	private List<string> dialogo2 = new List<string>();
	private List<string> names = new List<string>();
	private List<string> decisions= new List<string>();
	private int i=0;
	private int j=0;
	public Text nombre;
	public Text texto;
    public GameObject panel;
	private Item item;
	StoreItems store;
	private bool isPressed=true;
	public GameObject button;
	public GameObject button2;
	private Text buttonText1;
	private Text buttonText2;
	public float decision=0;
    private bool allowTalk = false;
    private bool Talk = false;

    public GameObject textoNombre;
    public GameObject textoDialogo;
	// Use this for initialization
	void Start () {

		OnStart ();
        textoNombre.SetActive(false);
        textoDialogo.SetActive(false);
        panel.SetActive(false);
	}

	void Update(){

		if (Input.GetButtonDown("PS4_O") && i < dialogo1.Count && isPressed == false && allowTalk) {

            panel.SetActive ( true);
            textoNombre.SetActive(true);
            textoDialogo.SetActive(true);
            Debug.Log(dialogo1.Count);
            Debug.Log("iteracciones:" + i);
            nombre.text = names [i];
            texto.text = dialogo1 [i];
            isPressed = true;
            ++i;
            Talk=true;
            if (i == 9)
            {
                ExitConversation();
            }

		} else {

			isPressed = false;
		}

		/*if(names[i]=="Elegir"  && j< decisions.Count){
			
			button.SetActive(true);
			button2.SetActive(true);
			nombre.gameObject.SetActive(false);
			texto.gameObject.SetActive(false);
			buttonText1.text = decisions[j];
			buttonText2.text = decisions[j+1];
		 }
		if(decision==1){
			path="Decision1";
			OnStart ();
			button.SetActive(false);
			button2.SetActive(false);
			nombre.gameObject.SetActive(true);
			texto.gameObject.SetActive(true);

		}*/

		}
		
	public void cambiarXml(string path){

		this.path = path;


	}
	public void takeDecision(){

		decision=1;
		//prueba = true;
	}

	public void takeSecondDecision(){

		decision=2;
	}

	public void OnStart(){

        dialogo1.Clear();
		print (path);
		store= StoreItems.Load(path);
		buttonText1 = button.GetComponentInChildren<Text>();
		buttonText2 = button2.GetComponentInChildren<Text>();
		button.SetActive(false);
		button2.SetActive(false);

		foreach(Item item in store.items){


			if (item.name == "Yo") {
				names.Add (item.getName ());
				dialogo1.Add(item.dialogue);
			}
			if (item.name == "Bufanda"||item.name== "NPC2") {
				names.Add (item.getName ());
				dialogo1.Add (item.dialogue);
			}
			if(item.name =="Elegir"){
				names.Add(item.getName());
				decisions.Add(item.decision);
			}


		}

	}

    public void ExitConversation()
    {
        //salimos de la conversacion
        OnStart();
        i = 0;
        Talk = false;
        isPressed = true;
        textoNombre.SetActive(false);
        textoDialogo.SetActive(false);
        panel.SetActive(false);
    }

    public void setAllowTalk(bool state)
    {
        allowTalk = state;
    }

    public bool getAllowTalk()
    {
        return allowTalk;
    }


    public void setTalk(bool state)
    {
        Talk = state;
    }

    public bool getTalk()
    {
        return Talk;
    }
}
	
	


