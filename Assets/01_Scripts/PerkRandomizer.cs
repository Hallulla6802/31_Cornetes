using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkRandomizer : MonoBehaviour
{
    public List<Button> perkButtons;
    private List<Vector3> ogPositions = new List<Vector3>();

    private void Start()
    {
        //Save buttons og position
        foreach (Button button in perkButtons)
        {
            ogPositions.Add(button.transform.position);
        }

        RandomizePositions();
    }

    public void RandomizePositions()
    {
        List<Vector3> positions = new List<Vector3>(ogPositions);

        for (int i = 0; i < positions.Count; i++) //Shuffle posible positions
        {
            Vector3 temp = positions[i];
            int randomIndex = Random.Range(i, positions.Count);
            positions[i] = positions[randomIndex];
            positions[randomIndex] = temp;
        }

        for (int i = 0; i < perkButtons.Count; i++) //Get buttons back to their porsitions
        {
            perkButtons[i].transform.position = positions[i];
        }
    }
}
