using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace be.eloistree.generaltoolbox
{
    public class DeveloperMode
    {
        public static bool m_isWorkingWithDeveloperVersion=true;

        public static void SetAsDeveloperMode() =>
                m_isWorkingWithDeveloperVersion = true;
        public static void SetAsClientMode() =>
                m_isWorkingWithDeveloperVersion = false;
        public static void SetDeveloperModeAs(bool value) =>
                m_isWorkingWithDeveloperVersion = value;
        public static void IsInDeveloperMode(out bool isInDevMode) { isInDevMode = m_isWorkingWithDeveloperVersion; }
        public static bool IsInDeveloperMode() { return m_isWorkingWithDeveloperVersion; }
    }
    public class DeveloperModeMono : MonoBehaviour
    {
        public static void SetAsDeveloperMode() => DeveloperMode.SetAsDeveloperMode();
        public static void SetAsClientMode() => DeveloperMode.SetAsClientMode();
        public static void SetDeveloperModeAs(bool value) => DeveloperMode.SetDeveloperModeAs(value);
        public static void IsInDeveloperMode(out bool isInDevMode) 
        { DeveloperMode.IsInDeveloperMode(out isInDevMode); }
        public static bool IsInDeveloperMode() 
        { return DeveloperMode.IsInDeveloperMode(); }

    }
}
