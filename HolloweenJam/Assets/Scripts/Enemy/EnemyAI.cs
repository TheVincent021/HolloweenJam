using Pathfinding;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    [SerializeField] float speed = 5f;
    [SerializeField] float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker m_seeker;
    Rigidbody2D m_rigidbody;

    void Awake () {
        MakeReferences();
    }

    void Start () {
        InvokeRepeating("GeneratePath", 0f, 0.5f);
    }

    void FixedUpdate () {
        UpdatePath();
    }

    void MakeReferences () {
        m_seeker = GetComponent<Seeker>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void GeneratePath () {
        if (m_seeker.IsDone())
            m_seeker.StartPath(m_rigidbody.position, target.position, OnPathComplete);
    }

    void OnPathComplete (Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    void UpdatePath () {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count) {
            reachedEndOfPath = true;
            return;
        } else {
            reachedEndOfPath = false;
        }

        MoveTowardTarget();
    }

    void MoveTowardTarget () {
        Vector2 direction = (Vector2)path.vectorPath[currentWaypoint] - m_rigidbody.position;
        direction.Normalize();

        Vector2 force = direction * speed * Time.deltaTime;

        m_rigidbody.velocity = force;

        float distance = Vector2.Distance(m_rigidbody.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance) {
            currentWaypoint++;
        }
    }
}
