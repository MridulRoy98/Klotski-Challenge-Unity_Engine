using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    Shuffle shufflePieces;

    //Array that contains all the textures;
    public Texture[] textures;

    //Index for serial of texture;
    private int textureNumber = 0;

    //List for copying the pieces list from another class
    private List<GameObject> puzzle_pieces;

    //Renderer type variable to be able to access the materials of the gameobjects;
    Renderer pieceRender;
    public Text title;
    
    void Start()
    {
        //This is for the UI text that shows the level number;
        title = GameObject.Find("level").GetComponent<Text>();

        //Getting a reference of the shuffling function to trigger it when
        //the shuffle UI button is pressed;
        shufflePieces = GameObject.Find("GameManager").GetComponent<Shuffle>();  
    }
    public void getList(List<GameObject> pieces)
    {
        //Copying the gameobject list from another class;
        puzzle_pieces = pieces;
    }


    public void Reshuffle()
    {
        //This function is triggered when the shuffle button is pressed.
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
        shufflePieces.ShufflePieces();
    }
    public void nextLevel()
    {
        //incrementing the index of texture to move to next one when triggered
        textureNumber++;

        //Increamenting the level number in UI
        title.text = "Level" + textureNumber;

        //If player reaches the last level of the game, the game will reset to the first level
        if (textureNumber == textures.Length)
        {
            textureNumber = 0;
        }
        else
        {     
            //This part grabs every puzzle piece, accesses their material and
            //changes the main texture (Albedo) with the next one in textures array
            for(int i =0; i<puzzle_pieces.Count;i++)
            {
                pieceRender = puzzle_pieces[i].GetComponent<Renderer>();
                pieceRender.material.mainTexture = textures[textureNumber];
            }
        }
    }
}
