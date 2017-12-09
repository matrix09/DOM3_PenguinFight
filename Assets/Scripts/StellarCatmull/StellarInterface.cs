using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StellarInterface {


    public static float r = 0.5f;

    public static Vector3 Interp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float u)
    {
 
        //Vector3 c0 = b;
        //Vector3 c1 = r * (c - a);
        //Vector3 c2 = r * (2 * a + ((r - 3) / r) * b + ((3 - 2*r)/r) * c - d);
        //Vector3 c3 = r * (-a + ((2-r)/r) * b + ((r - 2)/r) * c + d);
        //return c3 * u * u * u + c2 * u * u + c1 * u + c0;
        return (r * (-a + ((2 - r) / r) * b + ((r - 2) / r) * c + d)) * u * u * u + (r * (2 * a + ((r - 3) / r) * b + ((3 - 2 * r) / r) * c - d)) * u * u + (r * (c - a)) * u + b;
    }

    public static Vector3 Velocity(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float u)
    {

        //Vector3 c0 = b;
        //Vector3 c1 = r * (c - a);
        //Vector3 c2 = r * (2 * a + ((r - 3) / r) * b + ((3 - 2 * r) / r) * c - d);
        //Vector3 c3 = r * (-a + ((2 - r) / r) * b + ((r - 2) / r) * c + d);
        //return 3 * c3 * u * u + 2 * c2 * u + c1;
        return 3 * (r * (-a + ((2 - r) / r) * b + ((r - 2) / r) * c + d)) * u * u + 2 * (r * (2 * a + ((r - 3) / r) * b + ((3 - 2 * r) / r) * c - d)) * u + (r * (c - a));

    }

}


