using UnityEngine;

public abstract class EffectFeedback : Feedback
{
    public ParticleEffect ParticleEffect = null;

    private ParticleEffect _cloneParticle = null;

    public bool IsParticleAlive => _cloneParticle != null;

    public override bool StartFeedback()
    {
        bool result = DoStartFeedback();

        return result;
    }


    public override bool FinishFeedback()
    {
        bool result = DoFinishFeedback();

        return result;
    }

    public override bool DoStartFeedback()
    {
        if (!IsParticleAlive)
            _cloneParticle = Instantiate(ParticleEffect, transform.position, ParticleEffect.transform.rotation);

        _cloneParticle.StartPrticle();

        return true;
    }

    public override bool DoFinishFeedback()
    {
        if (IsParticleAlive)
            _cloneParticle.FinishParticle();

        return true;
    }
}
