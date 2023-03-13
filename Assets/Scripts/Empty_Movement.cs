using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Empty_Movement : MonoBehaviour
{
    Shuffle shuffle;
    public GameObject[] puzzlePieces;
    private GameObject tempPiece;

    private Vector3 emptyFormerPosition;
    private Vector3 emptyNewPosition;
    private Vector3 targetPos;

    private void Start()
    {
        shuffle = GameObject.Find("GameManager").GetComponent<Shuffle>();
        targetPos = transform.position;
    }
    
    //The movement function moves the swapping object with mesh renderer off
    //in the opposite direction of swipe
    public void Movement(int direction)
    {
        if(direction == 0)
        {   emptyFormerPosition = transform.position;
            if(transform.position.z+1 <=2 )
            {
                SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
                transform.position += new Vector3(0, 0, 1.65f);
                targetPos = emptyFormerPosition;
            }
            
        }
        else if (direction == 1)
        {
            emptyFormerPosition = transform.position;
            if(transform.position.x+1 <= 1.65)
            {
                SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
                transform.position += new Vector3(1.65f, 0, 0);
                targetPos = emptyFormerPosition;
            }
            
        }
        else if (direction == 2)
        {
            emptyFormerPosition = transform.position;
            if (transform.position.z+1 >= 1)
            {
                SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
                transform.position += new Vector3(0, 0, -1.65f);
                targetPos = emptyFormerPosition;
            }
            

        }
        else if (direction == 3)
        {
            emptyFormerPosition = transform.position;
            if(transform.position.x-1! > -1.65f)
            {
                SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
                transform.position += new Vector3(-1.65f, 0, 0);
                targetPos = emptyFormerPosition;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject piece in puzzlePieces)
        {
            if (other.gameObject.name == piece.name)
            {
                movePiece(piece.name.ToString());
            }
        }
        
        
    }

    //This function moves the triggered puzzle piece to the empty objects position
    //using the DOtween package's DoMove function to move slowly
    void movePiece(string piece)
    {
        tempPiece = GameObject.Find(piece);
        transform.position = tempPiece.transform.position;
        tempPiece.transform.DOMove(targetPos, 0.25f);
    }
}
