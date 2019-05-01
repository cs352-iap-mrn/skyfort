using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTower : Tower
{

    public UpgradeTower(int cost, string name, int health, int focusPriority, int attackSpeed) : base(cost, name, health, focusPriority, attackSpeed)
    {
        modelName = ModelType.Upgrade;
    }

    override
    public void Act(TowerInstance t)
    {
        System.Object data = t.GetData();
        if (data != null && data is Tower)
        {
            if (TechTree.GetAvailableTowers().Contains(data as Tower))
            {
                t.SetData(null);

                StopParticles(t);
            }
            else
            {
                TechTree.ResearchTower(data as Tower);

                StartParticles(t);
            }     
        }

        if (data != null && data is Upgrade)
        {
            

            if (TechTree.GetAvailableUpgrades().Contains(data as Upgrade))
            {
                t.SetData(null);

                StopParticles(t);
            }
            else
            {
                TechTree.ResearchUpgrade(data as Upgrade);

                StartParticles(t);
            }
        }

        if (data == null)
        {
            StopParticles(t);
        }
    }

    private void StopParticles(TowerInstance t)
    {
        GameObject obj = t.GetGameObject();
        if (obj != null)
        {
            ParticleSystem[] psArray = obj.GetComponentsInChildren<ParticleSystem>();
            if (psArray.Length > 0)
            {
                psArray[0].Stop();
            }
        }
    }

    private void StartParticles(TowerInstance t)
    {
        GameObject obj = t.GetGameObject();
        if (obj != null)
        {
            ParticleSystem[] psArray = obj.GetComponentsInChildren<ParticleSystem>();
            if (psArray.Length > 0 && psArray[0].isStopped)
            {
                psArray[0].Play();
            }
        }
    }
}
