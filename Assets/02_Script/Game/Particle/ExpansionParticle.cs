using UnityEngine;

public abstract class ExpansionParticle : ExpansionMonoBehaviour
{
    protected ParticleSystem particle = null;

    public bool IsParticle => particle != null;

    protected virtual void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    public void StartPrticle()
    {
        if (!IsParticle) return;

        particle.Play();
    }

    public void FinishParticle()
    {
        if (!IsParticle) return;

        particle.Stop();
    }
}
