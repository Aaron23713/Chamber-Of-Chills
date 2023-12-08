using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRoom : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject[] empty;
    // Start is called before the first frame update
    void Start()
    {
         int n = rooms.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = rooms[i];
            rooms[i] = rooms[j];
            rooms[j] = temp;
        }
        int roomIndex = 0;

        // Iterate through each empty space and assign a room
        foreach (GameObject emptySpace in empty)
        {
            if (roomIndex < rooms.Length)
            {
                // Instantiate the room at the position of the empty space
                rooms[roomIndex].transform.position = emptySpace.transform.position;
                // rooms[roomIndex].transform.rotation = emptySpace.transform.rotation;
                // Increment the room index
                roomIndex++;
            }
            else
            {
                Debug.LogWarning("Not enough rooms to assign to all empty spaces.");
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
