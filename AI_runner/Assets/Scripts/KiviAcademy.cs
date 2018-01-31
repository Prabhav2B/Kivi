using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiviAcademy : Academy {

	public float thresh ;
	public float frequency ;

	public override void AcademyReset()
	{
		thresh = resetParameters["Threshold"];
		frequency = resetParameters["Frequency"];
	}
		
}
