using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{

    public class ToDoMono : MonoBehaviour
    {
        [Header("What to do later ?")]
        [TextArea(4, 10)]
        public string m_taskDescription;
        public bool m_hadBeenDone;
        public string m_creatorName;
        [Header("Basic")]
        public Priority m_priority;
        public Risk m_risk;
        [Header("Time estimation")]
        public MasteringPracticeAroundIt m_masteringPractice = MasteringPracticeAroundIt.D;
        public MasteringKnowedgeAroundIt m_masteringKnowledge = MasteringKnowedgeAroundIt.D;
        [Header("\"Finger estimation\"")]
        public float m_estimatedTime = 4;
        public float m_estimatedPiTimeMax;
        public bool m_firstTime;
        public enum Priority { A, B, C, D }
        public enum Risk { A, B, C, D }
        public enum MasteringPracticeAroundIt { A, B, C, D }
        public enum MasteringKnowedgeAroundIt { A, B, C, D }


        private void Reset()
        {
            m_creatorName = System.Environment.UserName;
            ComputeEstimatedTime();
        }

        private void OnValidate()
        {
            ComputeEstimatedTime();
        }

        private void ComputeEstimatedTime()
        {
            float piCut = (3.14f / 8f);
            float time = m_estimatedTime;
            m_estimatedPiTimeMax = m_estimatedTime;
            int piCutCount = 0;
            switch (m_masteringPractice)
            {
                case MasteringPracticeAroundIt.A:
                    break;
                case MasteringPracticeAroundIt.B:
                    piCutCount += 1;
                    break;
                case MasteringPracticeAroundIt.C:
                    piCutCount += 2;
                    break;
                case MasteringPracticeAroundIt.D:
                    piCutCount += 4;
                    break;
                default:
                    break;
            }
            switch (m_masteringKnowledge)
            {
                case MasteringKnowedgeAroundIt.A:
                    break;
                case MasteringKnowedgeAroundIt.B:

                    piCutCount += 1;
                    break;
                case MasteringKnowedgeAroundIt.C:

                    piCutCount += 2;
                    break;
                case MasteringKnowedgeAroundIt.D:

                    piCutCount += 4;
                    break;
                default:
                    break;
            }
            if (m_firstTime)
                piCutCount *= 2;
            m_estimatedPiTimeMax = m_estimatedTime + (piCutCount * piCut) * m_estimatedTime;
        }
    }
}
