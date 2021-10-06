using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eloi;


namespace Eloi
{
    public class TDD_Oscillation : MonoBehaviour
    {


        private IEnumerator Start()
        {
            EloiBeepUtility.SetOscillatorFull(true, 1, 0.1f, 440);
            yield return new WaitForSeconds(1);
            EloiBeepUtility.SetOscillatorOff();
            E_EnumUtility.Count<OscillatorMono.Note>(out int noteCount);
            E_EnumUtility.Count<OscillatorMono.Octave>(out int octaveCount);
            E_EnumUtility.Count<OscillatorMono.LatinNoteAlias>(out int latinAliasCount);
            E_EnumUtility.Count<OscillatorMono.LatinNote>(out int latinCount);
            for (int n = 0; n < noteCount; n++)
            {
                for (int o = 0; o < octaveCount; o++)
                {
                    yield return new WaitForSeconds(0.5f);
                    EloiBeepUtility.
                        CreateOscillatorForDuration(1,
                        (OscillatorMono.Note)n,
                        (OscillatorMono.Octave)o);

                }

            }
            for (int n = 0; n < latinAliasCount; n++)
            {
                for (int o = 0; o < octaveCount; o++)
                {
                    yield return new WaitForSeconds(0.5f);
                    EloiBeepUtility.
                        CreateOscillatorForDuration(1,
                        (OscillatorMono.LatinNoteAlias)n,
                        (OscillatorMono.Octave)o);

                }

            }
            for (int n = 0; n < latinCount; n++)
            {
                for (int o = 0; o < octaveCount; o++)
                {
                    yield return new WaitForSeconds(0.5f);
                    EloiBeepUtility.
                        CreateOscillatorForDuration(1,
                        (OscillatorMono.LatinNote)n,
                        (OscillatorMono.Octave)o);

                }

            }

        }
    }
}