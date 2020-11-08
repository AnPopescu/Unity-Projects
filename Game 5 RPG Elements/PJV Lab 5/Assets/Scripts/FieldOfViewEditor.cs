using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Inamic))]
public class FieldOfViewEditor : Editor
{

	void OnSceneGUI()
	{
		Inamic fow = (Inamic)target;
		Handles.color = Color.white;
		Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);

		//fow.viewAngle += fow.transform.eulerAngles.y;

		//Vector3 viewAngleA  = new Vector3(Mathf.Sin(-fow.viewAngle / 2 * Mathf.Deg2Rad), 0, Mathf.Cos(-fow.viewAngle / 2 * Mathf.Deg2Rad));
		//Vector3 viewAngleB = new Vector3(Mathf.Sin(fow.viewAngle / 2 * Mathf.Deg2Rad), 0, Mathf.Cos(fow.viewAngle / 2 * Mathf.Deg2Rad));
		Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
		Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);


		Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
		Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);

		//Handles.color = Color.red;
		//foreach (Transform visibleTarget in fow.visibleTargets)
		//{
		//	Handles.DrawLine(fow.transform.position, visibleTarget.position);
		//}
	}

}