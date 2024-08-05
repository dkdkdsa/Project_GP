using UnityEngine;

public class PlayerHandController : ExpansionMonoBehaviour, IHandController
{
    [field: SerializeField] public Transform[] Hands { get; set; }

    public void SetUpHandPos(Transform[] trms)
    {

        for (int i = 0; i < Hands.Length; i++)
        {

            if (i >= Hands.Length) return;

            Hands[i].gameObject.SetActive(true);
            Hands[i].SetParent(trms[i]);
            Hands[i].localPosition = Vector3.zero;

        }

    }

}
