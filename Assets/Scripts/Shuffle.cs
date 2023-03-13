using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Shuffle : MonoBehaviour
{
    Level_Manager level_manager;

    private Vector3 emptyOriginalPosition;
    public List<GameObject> pieces;
    private List<Vector3> positions;
    private List<Vector3> originalPositions;
    private void Start()
    {
        emptyOriginalPosition = GameObject.Find("Empty_Space").transform.position;
        level_manager = GameObject.Find("GameManager").GetComponent<Level_Manager>();
        originalPositions = new List<Vector3>();
        positions = new List<Vector3>();

        //Taking positions of every puzzle piece in a list named positions.
        foreach (GameObject piece in pieces)
        {
            positions.Add(piece.transform.position);
        }

        //The originalPosition list keeps the original coordinated of every puzzle piece
        //so that we are able to check whether the puzzle is solved by comparing coordinates
        //with original ones.
        for (int i =0; i < positions.Count; i++)
        {
            originalPositions.Add(positions[i]);
            
        }

        //Calls function to shuffle positions of puzzle pieces.
        ShufflePieces();

        //Sending the gameobject list to another script.
        level_manager.getList(pieces);
    }
    
    //Re-orders the puzzle pieces
    public void ShufflePieces()
    {
        //Resets the swapping gameobject position everytime we hit shuffle
        GameObject.Find("Empty_Space").transform.position = emptyOriginalPosition;

        //Randomizing array
        int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7 };
        System.Random random = new System.Random();
        arr = arr.OrderBy(x => random.Next()).ToArray();

        //Randomizing positions
        for (int i = 0; i < pieces.Count; i++)
        {
            pieces[i].transform.position = positions[arr[i]];
        }
    }

    //This function checks whether the puzzle is solved
    public bool checkSolved()
    {
        int checker = 0;
        for(int i = 0; i<pieces.Count; i++)
        {
            //Checks if the current position of the puzzle pieces are back in their
            //original positions. If a single piece of puzzle is back in their
            //original position then the checker will add one.
            if (pieces[i].transform.position == originalPositions[i])
            {
                checker++;
            }
        }
        if (checker == 8)
        {
            //When checker is 8, it means that all pieces are back in their original positions
            //which means that the puzzle is solved.
            return true;
        }
        return false;
    }
    private void Update()
    {
        //We will check if the puzzle is solved in every frame.

        if (checkSolved() == true)
        {
            //If the puzzle is solved then we call nextLevel() which changes the 
            //level by changing texture.
            level_manager.nextLevel();
        }
    }

}

