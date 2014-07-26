using System;

namespace Garbe.Sound
{
    /// <summary> Calculate the signal with echo effects </summary>
    public sealed class Flanging_Effect : SoundObj
    {
        #region Declarations

        float[] m_delayBuffer;
        float[] m_outputDelayBuffer;
        int m_position;
        int m_delay;
        float m_gain;

        #endregion

        #region Constructor

        /// <summary>
        ///  setting the value of the delay if it's not equal to Zero.
        ///  and calling Reset function to Initialize the values of arrays
        /// </summary>
        /// <param name="p_gain">"gain value"</param>
        /// <param name="p_delay">"delay value "</param>
        public Flanging_Effect(float p_gain, int p_delay): base()
        {
            m_gain = p_gain;

            if (p_delay == 0)
                m_delay = 0;
            else
            {
                m_delay = p_delay - 1;
                m_delayBuffer = new float[p_delay];
                m_outputDelayBuffer = new float[p_delay];
                this.Reset();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// DO the signal Processing 
        /// </summary>
        public override void DoProcess()
        {
            float m_temp;
            float m_outTemp;

            if (m_delay == 0)
            {
                base._output = Input.Output;
            }
            else
            {
                m_temp = m_delayBuffer[m_position];
                m_outTemp = m_outputDelayBuffer[m_position];
                base._output = (m_temp) + m_gain * m_outTemp;


                m_delayBuffer[m_position] = Input.Output;
                m_outputDelayBuffer[m_position] = base._output;

                if (m_position == m_delay)//reach to end of buffer
                    m_position = 0;
                else
                    m_position++;
            }
        }

        /// <summary>
        /// Initialize the values of the arrays 
        /// </summary>
        private void Reset()
        {
            for (m_position = 0; m_position <= m_delay; m_position++)
            {
                m_delayBuffer[m_position] = 0;
                m_outputDelayBuffer[m_position] = 0;
            }
            m_position = 0;
        }
        #endregion

        #region Properties
        public int DelayVal
        {
            set { value = m_delay; }
            get { return this.m_delay; }
            
        }
        /// <summary>
        ///  Gets the expected number of interations to be processed 
        /// </summary>
        public override int Interations
        {
            get { return (base._input.Interations + m_delay + 1); }
        }
        #endregion

    }

}

