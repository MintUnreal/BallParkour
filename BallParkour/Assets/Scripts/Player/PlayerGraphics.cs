using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphics : PlayerComponentBase
{
    [SerializeField] private List<PlayerPartcle> playerPartcles;

    public void PlayParticle(PlayerParticleType type)
    {
        foreach(PlayerPartcle i in playerPartcles)
        {
            if(i.Type == type)
            {
                i.Play();
                return;
            }
        }

        Debug.LogWarning(type.ToString() + " не найден!");
    }

    //particle
    [System.Serializable]
    private struct PlayerPartcle
    {
        [SerializeField]
        private PlayerParticleType type;
        [SerializeField]
        private ParticleSystem explosionParticle;

        public void Play() => explosionParticle.Play();
        public PlayerParticleType Type => type;

    }

    //particles
    public enum PlayerParticleType
    {
        plasmaExplosion
    }
}
