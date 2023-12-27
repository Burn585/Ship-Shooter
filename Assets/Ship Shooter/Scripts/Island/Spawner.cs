using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Human _prefab;
    [SerializeField] private float _amountPool;

    public event UnityAction HumanDead;
    public event UnityAction HumanBorn;

    private Queue<Human> _humen = new Queue<Human>();
    private float _alifeHuman = 0;

    public float AlifeHuman => _alifeHuman;

    private void Start()
    {
        _humen.Enqueue(_prefab);

        for (int i = 0; i < _amountPool; i++)
        {
            Human human = Instantiate(_prefab, _prefab.transform.position, Quaternion.identity, this.transform);
            human.gameObject.SetActive(false);
            _humen.Enqueue(human);
        }
    }

    public void AddInQueue(Human human)
    {
        _humen.Enqueue(human);
        human.gameObject.SetActive(false);
        _alifeHuman--;
        HumanDead?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Human human;

        if (collision.collider.TryGetComponent<Bullet>(out Bullet bullet))
        {
            for (int i = 0; i < bullet.Bonus; i++)
            {
                if (_humen.Count > 0)
                {
                    human = _humen.Dequeue();
                }
                else
                {
                    human = Instantiate(_prefab, _prefab.transform.position, Quaternion.identity, this.transform);
                }

                human.transform.position = bullet.transform.position;
                human.gameObject.SetActive(true);
                _alifeHuman++;
                HumanBorn?.Invoke();
            }
        }
    }
}