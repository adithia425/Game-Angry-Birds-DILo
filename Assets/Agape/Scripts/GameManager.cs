using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Pelontar Pelontar;
    public TrailController TrailController;
    public List<Burung> Burungs;
    public List<Enemy> Enemies;

    private Burung _shotBird;

    public BoxCollider2D TapCollider;


    private bool _isGameEnded = false;

    void Start()
    {
        for (int i = 0; i < Burungs.Count; i++)
        {
            Burungs[i].OnBirdDestroyed += ChangeBird;
            Burungs[i].OnBirdShot += AssignTrail;

        }

        for (int i = 0; i < Enemies.Count; i++)
        {
            Enemies[i].OnEnemyDestroyed += CheckGameEnd;
        }

        TapCollider.enabled = false;
        Pelontar.InitiateBird(Burungs[0]);
        _shotBird = Burungs[0];
    }
    public void ChangeBird()
    {
        TapCollider.enabled = false;

        if (_isGameEnded)
        {
            return;
        }


        Burungs.RemoveAt(0);

        if (Burungs.Count > 0)
        {
            Pelontar.InitiateBird(Burungs[0]);
            _shotBird = Burungs[0];
        }
    }
    public void CheckGameEnd(GameObject destroyedEnemy)
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i].gameObject == destroyedEnemy)
            {
                Enemies.RemoveAt(i);
                break;
            }
        }

        if (Enemies.Count == 0)
        {
            _isGameEnded = true;
        }
    }
    public void AssignTrail(Burung bird)
    {
        TrailController.SetBird(bird);
        StartCoroutine(TrailController.SpawnTrail());
        TapCollider.enabled = true;

    }
    void OnMouseUp()
    {
        if (_shotBird != null)
        {
            _shotBird.OnTap();
        }
    }


}
