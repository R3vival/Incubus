using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeController : MonoBehaviour
{
    public int[] TrueCodes;
    public int[] codes;
    public TextMeshPro[] Codes= new TextMeshPro[3];
    
    public void SetCodeUnlocked(int index,int code)
    {
        codes[index] = code;
        Codes[index].text=code.ToString();
    }
    public void CodeChecker()
    {
        if(codes[0]==TrueCodes[0] 
            &&(codes[1] == TrueCodes[1]) 
            && (codes[2] == TrueCodes[2]) 
            && (codes[3] == TrueCodes[3]) 
            )
        {
            Debug.Log("Ganaste tu libertad");
        }
        else
        {
            Debug.Log("Aun no tienes todos los codigos");
        }

    }
    
}
