using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Transform target = _points[_currentPointIndex];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        Flip();

        if(transform.position == target.position)
        {
            _currentPointIndex++;

            if (_currentPointIndex >= _points.Length)
                _currentPointIndex = 0;
        }
    }

    private void Flip()
    {
        Transform target = _points[_currentPointIndex];
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (transform.position.x > target.position.x)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;

    }
}
