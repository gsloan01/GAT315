using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    static World instance;
    static public World Instance { get { return instance; } }

    public List<Body> bodies { get; set; } = new List<Body>();

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        float dt = Time.deltaTime;

        bodies.ForEach(body => body.Step(dt));
        bodies.ForEach(body => Integrator.ExplicitEuler(body, dt));

        bodies.ForEach(body => body.force = Vector2.zero);
        bodies.ForEach(body => body.acceleration = Vector2.zero);
    }
}
