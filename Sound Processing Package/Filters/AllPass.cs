using System;

namespace Garbe.Sound
{
    /// <summary> Calculate the signal with a high pass filter </summary>
    public sealed class AllPass : SoundObj
    {
        #region Declarations
        float m_gain;
        float[] m_inputDelayBuffer;
        float[] m_outputDelayBuffer;

        int m_pos;
        int m_delay;
        #endregion


        #region Constructor
        /// <summary>
        /// setting the value of gain and delay 
        /// Calling the Reset Function to initialize buffers.
        /// </summary>
        /// <param name="p_gain"></param>
        /// <param name="p_delay"></param>
        public AllPass(float p_gain, int p_delay)
            : base()
        {
            m_gain = p_gain;
            m_delay = p_delay - 1;

            m_inputDelayBuffer = new float[p_delay];
            m_outputDelayBuffer = new float[p_delay];
            this.Reset();
        }
        #endregion
        
        #region Methods
        /// <summary>
        /// Do Processing of the signal 
        /// Input Delayed + Input + Output Delayed
        /// </summary>
        public override void DoProcess()
        {
            float temp_input;
            float temp_output;

            if (m_delay == 0)
            {
                base._output = Input.Output;
            }
            else
            {
                // y[i] := α * y[i-1] + α * (x[i] - x[i-1])
                temp_input = m_inputDelayBuffer[m_pos];
                temp_output = m_outputDelayBuffer[m_pos];
                base._output = m_gain * (base._input.Output + temp_input - temp_output);
                m_inputDelayBuffer[m_pos] = Input.Output;
                m_outputDelayBuffer[m_pos] = base._output;

                if (m_pos == m_delay)
                    m_pos = 0;
                else
                    m_pos++;
            }

        }

        /// <summary>
        /// Initialize Delay Buffers
        /// </summary>
        private void Reset()
        {

            for (int i = 0; i <= m_delay; i++)
            {
                m_inputDelayBuffer[i] = 0;
                m_outputDelayBuffer[i] = 0;
            }
            m_pos = 0;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the expected number of interations to be processed 
        /// </summary>
        public override int Interations
        {
            get { return (base._input.Interations + m_delay + 1); }
        }
        #endregion
        


    }
}