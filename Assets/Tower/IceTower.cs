using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : MonoBehaviour
{
    [SerializeField] int costOfTower = 75;
    [SerializeField] float buildDelay = 1f;
    [SerializeField] bool deneme = false;



    void Start()
    {
        StartCoroutine(Build());
    }

    public bool CreateTower(IceTower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null)
        {
            return false;
        }
        if (bank.CurrentBalance >= costOfTower && deneme)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.WithDrawMoney(costOfTower);
            return true;
        }

        return false;

    }
    IEnumerator Build()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }

    }
}
