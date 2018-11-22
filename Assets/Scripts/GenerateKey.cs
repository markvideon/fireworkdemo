using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateKey : MonoBehaviour {

	private int int_key;
	private KeyCode hard_key;
	private string string_key;

    [SerializeField] private int shared_key = 0;
    [SerializeField] private bool force_shared_key = false;

	// Use this for initialization
	void Start () {
		Random.InitState(System.Environment.TickCount);
	}

	// Update is called once per frame
	void Update () {

		// Magic number to produce animation effect
		if (gameObject.transform.position.y < -30 ) {
			AssignKey ();
		}
	}

	public KeyCode ReturnHardKey() {
		return hard_key;
	}

	public string ReturnString() {
		return string_key;
	}

	void AssignKey() {
		int_key = Random.Range (0, 25);

        if (force_shared_key) {
            int_key = shared_key;
        }

		if (int_key == 0) {
			hard_key = KeyCode.A;
			string_key = "A";
		}
		if (int_key == 1) {
			hard_key = KeyCode.B;
			string_key = "B";
		}
		if (int_key == 2) {
			hard_key = KeyCode.C;
			string_key = "C";
		}
		if (int_key == 3) {
			hard_key = KeyCode.D;
			string_key = "D";
		}
		if (int_key == 4) {
			hard_key = KeyCode.E;
			string_key = "E";
		}
		if (int_key == 5) {
			hard_key = KeyCode.F;
			string_key = "F";
		}
		if (int_key == 6) {
			hard_key = KeyCode.G;
			string_key = "G";
		}
		if (int_key == 7) {
			hard_key = KeyCode.H;
			string_key = "H";
		}
		if (int_key == 8) {
			hard_key = KeyCode.I;
			string_key = "I";
		}
		if (int_key == 9) {
			hard_key = KeyCode.J;
			string_key = "J";
		}
		if (int_key == 10) {
			hard_key = KeyCode.K;
			string_key = "K";
		}
		if (int_key == 11) {
			hard_key = KeyCode.L;
			string_key = "L";
		}
		if (int_key == 12) {
			hard_key = KeyCode.M;
			string_key = "M";
		}
		if (int_key == 13) {
			hard_key = KeyCode.N;
			string_key = "N";
		}
		if (int_key == 14) {
			hard_key = KeyCode.O;
			string_key = "O";
		}
		if (int_key == 15) {
			hard_key = KeyCode.P;
			string_key = "P";
		}
		if (int_key == 16) {
			hard_key = KeyCode.Q;
			string_key = "Q";
		}
		if (int_key == 17) {
			hard_key = KeyCode.R;
			string_key = "R";
		}
		if (int_key == 18) {
			hard_key = KeyCode.S;
			string_key = "S";
		}
		if (int_key == 19) {
			hard_key = KeyCode.T;
			string_key = "T";
		}		
		if (int_key == 20) {
			hard_key = KeyCode.U;
			string_key = "U";
		}
		if (int_key == 21) {
			hard_key = KeyCode.V;
			string_key = "V";
		}
		if (int_key == 22) {
			hard_key = KeyCode.W;
			string_key = "W";
		}
		if (int_key == 23) {
			hard_key = KeyCode.X;
			string_key = "X";
		}
		if (int_key == 24) {
			hard_key = KeyCode.Y;
			string_key = "Y";
		}
		if (int_key == 25) {
			hard_key = KeyCode.Z;
			string_key = "Z";
		}
	}
}
